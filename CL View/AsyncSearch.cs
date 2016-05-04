/**********************************************************************************
 * (C) 2015 Daniel Dorpinghaus
 * 
 * Application: Craigs List View
 * File:        AsyncSearch.cs
 * Date:        04-26-2016
 * Author:      Daniel Dorpinghaus
 * Description: This class implements an asyncronous search on craigslist for a
 *              given set of key words.
 * 
 **********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Threading;
using System.Xml;
using System.Collections;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Net;
using System.IO;

namespace CL_View
{
    class AsyncSearch
    {
        /**************************************************************************
         * WORK FIELDS 
         **************************************************************************/
        private int m_IntStatus = -1; //-1 = Not Initialized, 0 = Ready, 1 = Query In Progress, 2 = Preparing Results, 3 = Complete, 4 = Error
        private String m_StrDomain = "";
        private String m_StrKeywords = "";
        private Thread m_ObjThread;
        private ArrayList m_ObjSearchResults = null;


        /**************************************************************************
         * PROPERTIES
         **************************************************************************/
        public int Status { get { return m_IntStatus; } set { } }
        public String Domain { get { return m_StrDomain; } set { } }
        public String Keywords { get { return m_StrKeywords; } set { } }
        public ArrayList Results { get { return m_ObjSearchResults; } set { } }


        /**************************************************************************
         * SUBROUTINES 
         **************************************************************************/
        /// <summary>
        /// This routine initializes the thread and its parameters for the search.
        /// </summary>
        /// <param name="l_StrDomain">The craigslist domain to search.</param>
        /// <param name="l_StrKeywords">The keywords to search for.</param>
        public AsyncSearch(String l_StrDomain, String l_StrKeywords)
        {

            //Copy the input parameters.
            m_StrDomain = l_StrDomain;
            m_StrKeywords = HttpUtility.UrlDecode(l_StrKeywords);

            //Initialize the thread object.
            m_ObjThread = new Thread(this.AsyncTask);

            //Initialize the results list object.
            m_ObjSearchResults = new ArrayList();

            //Set the object status.
            m_IntStatus = 0;
        }

        
        /// <summary>
        /// This routine is executed as a seporate thread. We use it to perform the search.
        /// </summary>
        /// <param name="p_ObjParm"></param>
        private void AsyncTask(object p_ObjParm)
        {

            //First determine if we're in the ready status.
            if (m_IntStatus == 0)
            {

                try
                {

                    //Set the status to 1 (Query In Progress).
                    m_IntStatus = 1;

                    //Create the Xml docuemtn object.
                    XmlDocument l_ObjDocument = new XmlDocument();

                    //Perform the query.
                    l_ObjDocument.Load(String.Format("{0}search/cpg?query={1}&format=rss", m_StrDomain, m_StrKeywords));

                    //Configure the namespaces so we can work with their elements.
                    NameTable l_ObjNameTable = (NameTable)l_ObjDocument.NameTable;
                    XmlNamespaceManager l_ObjNamespaceMgr = new XmlNamespaceManager(l_ObjNameTable);
                    l_ObjNamespaceMgr.AddNamespace("rdf", "http://www.w3.org/1999/02/22-rdf-syntax-ns#");
                    l_ObjNamespaceMgr.AddNamespace("item", "http://purl.org/rss/1.0/");
                    l_ObjNamespaceMgr.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");

                    //Omit irelavent elements.
                    XmlNodeList l_ObjResultItems = l_ObjDocument.DocumentElement.SelectNodes("//rdf:RDF/item:item", l_ObjNamespaceMgr);

                    //Set the status to 2 (Preparing Results).
                    m_IntStatus = 2;

                    //Now we'll begin creating the result objects.
                    foreach(XmlNode l_ObjItem in l_ObjResultItems)
                    {

                        try
                        {
                            String l_StrTitle = l_ObjItem.ChildNodes[0].InnerText;
                            String l_StrLink = l_ObjItem.ChildNodes[1].InnerText;
                            String l_StrDescription = l_ObjItem.ChildNodes[2].InnerText;
                            String l_StrPostingDate = l_ObjItem.ChildNodes[3].InnerText;


                            String l_StrAdPageSource = RetrievePageSource(l_StrLink);
                            String l_StrContactLink = RetrieveContactPage(l_StrAdPageSource);
                            String l_StrContactPageInfo = RetrievePageSource("http:" + m_StrDomain.Substring(0, m_StrDomain.Length - 1) + l_StrContactLink);

                            //Grab the extended information for the current posting.

                            String l_StrEmailAddress = RetrieveEmailAddress(l_StrContactPageInfo);
                            String l_StrPostingID = RetrievePostingID(l_StrContactPageInfo);
                            String l_StrPhoneNumber = RetrievePhoneNumber(l_StrContactPageInfo, l_StrPostingID);


                            //Build a new result object and add it to the list.
                            AddResultItem(l_StrTitle, l_StrLink, l_StrDescription, l_StrPostingDate, l_StrPostingID, l_StrEmailAddress, l_StrPhoneNumber);

                        }
                        catch (Exception l_ObjException) { }
                    }

                    //Set the completed status.
                    m_IntStatus = 3;
                }

                //Handle any exceptions.
                catch (Exception l_ObjException)
                {

                    //Write a message to the output window.
                    System.Diagnostics.Debug.Print(l_ObjException.Message);

                    //Set the status indicator to 4 (Error)
                    m_IntStatus = 4;
                }
            }
        }


        /// <summary>
        /// This routine launches the thread that executes the search.
        /// </summary>
        public void Launch()
        {

            //Only launch the thread if the status is zero.
            if (m_IntStatus == 0) m_ObjThread.Start();
        }


        /// <summary>
        /// this routine creates a single result object and adds it to the result list.
        /// </summary>
        /// <param name="p_StrTitle"></param>
        /// <param name="p_StrLink"></param>
        /// <param name="p_StrDescription"></param>
        /// <param name="p_ObjPostingDate"></param>
        private void AddResultItem(String p_StrTitle, String p_StrLink, String p_StrDescription, String p_StrPostingDate, String l_StrPostingID, String l_StrEmailAddress, String l_StrPhoneNumber)
        {

            //Convert the date string to a DateTime object.
            char[] l_ChrDil = { 'T' };
            DateTime l_ObjPostingDate = DateTime.Parse( p_StrPostingDate.Split(l_ChrDil)[0]);

            //Create and add the new result object.
            m_ObjSearchResults.Add(new AsyncSearchResult(p_StrTitle, p_StrLink, p_StrDescription, l_ObjPostingDate, l_StrPostingID, l_StrEmailAddress, l_StrPhoneNumber));
        }


        /// <summary>
        /// This routine loads the html for a specified URL.
        /// </summary>
        /// <param name="p_StrURL"></param>
        /// <returns></returns>
        public String RetrievePageSource(String p_StrURL)
        {
            String l_StrResult = null; //Default result is null.

            //Attempt to process normally.
            try
            {

                //Send the http request.
                HttpWebRequest l_ObjRequest = (HttpWebRequest)WebRequest.Create(p_StrURL);
                HttpWebResponse l_ObjResponse = (HttpWebResponse)l_ObjRequest.GetResponse();
                
                //Did we get a response?
                if (l_ObjResponse.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = l_ObjResponse.GetResponseStream();
                    StreamReader readStream = null;

                    //Get a reference to the data stream, accounting for the character encoding.
                    if (l_ObjResponse.CharacterSet == null) readStream = new StreamReader(receiveStream);
                    else readStream = new StreamReader(receiveStream, Encoding.GetEncoding(l_ObjResponse.CharacterSet));

                    //Read the data.
                    l_StrResult = readStream.ReadToEnd();

                    //Close the streams.
                    l_ObjResponse.Close();
                    readStream.Close();
                }
            }

            //Handle any errors.
            catch (Exception l_ObjException) { }

            //Return the result.
            return l_StrResult;
        }


        /// <summary>
        /// This routine takes the web page of a craigslist ad and returns the
        /// link to the poster's contact information.
        /// </summary>
        /// <param name="p_StrHtml"></param>
        /// <returns></returns>
        public String RetrieveContactPage(String p_StrHtml)
        {
            String l_StrResult = "";
            String l_StrLinkLine = "";

            //Attempt to process normally.
            try
            {

                //Split the string into lines.
                String[] l_StrLines = p_StrHtml.Split(new char[] { '\r', '\n' });

                //Grab the line with the reply link in it.
                foreach (String l_StrLine in l_StrLines)
                {

                    //Check for the key word.
                    if (l_StrLine.Contains("replylink"))
                    {

                        //Save the line.
                        l_StrLinkLine = l_StrLine;

                        //End the loop once found.
                        break;
                    }
                }

                //Now that we have the line we need to break out the link.
                Regex l_ObjRegEx = new Regex("(?<=\")[\\/]+[^\"]*(?=\")");
                l_StrResult = l_ObjRegEx.Match(l_StrLinkLine).Value;
            }

            //Handle any errors.
            catch (Exception l_ObjException) { }

            //Return the result.
            return l_StrResult;
        }


        /// <summary>
        /// This routine returns the email address found in the input string.
        /// </summary>
        /// <param name="p_StrHtml"></param>
        /// <returns></returns>
        public String RetrieveEmailAddress(String l_StrHtml)
        {
            String l_StrResult = "";

            //Attempt to process normally.
            try
            {

                //Grab the ID from the title line.
                Regex l_ObjRegEx = new Regex(@"(?<=>)\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*(?=<)");
                l_StrResult = l_ObjRegEx.Match(l_StrHtml).Value;
            }

            //Handle any errors.
            catch (Exception l_ObjException) { int x = 0; }

            //Return the result.
            return l_StrResult;
        }


        /// <summary>
        /// This routine returns the phone number found in the input string.
        /// </summary>
        /// <param name="p_StrHtml"></param>
        /// <returns></returns>
        public String RetrievePhoneNumber(String p_StrHtml, String l_StrPostingID)
        {
            String l_StrResult = ""; //Default result is empty.
            Regex l_ObjRegEx = new Regex(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}");

            //Attempt to process normally.
            try
            {

                //Concatinate all matches into one comma delimited string.
                MatchCollection l_ObjMatches = l_ObjRegEx.Matches(p_StrHtml);
                foreach (Match l_ObjMatch in l_ObjMatches)
                {

                    //Sometimes the phone number will match the posting ID. Exclude them.
                    if (l_ObjMatch.Value != l_StrPostingID) l_StrResult += l_ObjMatch.Value + ",";
                }

                //Clip the trailing comma.
                l_StrResult = l_StrResult.Substring(0, l_StrResult.Length - 1);
            }

            //Handle any errors.
            catch (Exception l_ObjException) { }

            //Return the result.
            return l_StrResult.Split(new char[] { ',' })[0];
        }


        /// <summary>
        /// This routine returns the posting ID.
        /// </summary>
        /// <param name="l_StrHtml"></param>
        /// <returns></returns>
        public String RetrievePostingID(String l_StrHtml)
        {
            String l_StrResult = "";
            String l_StrTitleLine = "";

            //Attempt to process normally.
            try
            {

                //Break the html into lines.
                String[] l_StrLines = l_StrHtml.Split(new char[] { '\n' });

                //Loop through each line to fthe title.
                foreach (String l_StrLine in l_StrLines)
                {

                    //Find the title.
                    if (l_StrLine.Contains("<title>"))
                    {

                        //Grab the Title Line.
                        l_StrTitleLine = l_StrLine;

                        //End the loop;
                        break;
                    }
                }

                //Grab the ID from the title line.
                Regex l_ObjRegEx = new Regex(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}");
                l_StrResult = l_ObjRegEx.Match(l_StrTitleLine).Value;
            }

            //Handle any errors.
            catch (Exception l_ObjException) { }

            //Return the result.
            return l_StrResult;
        }
    }
}
