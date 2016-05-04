/**********************************************************************************
 * (C) 2015 Daniel Dorpinghaus
 * 
 * Application: Craigs List View
 * File:        Program.cs
 * Date:        04-26-2016
 * Author:      Daniel Dorpinghaus
 * Description: This class implements the mainline program code for this search
 *              search engine.
 * 
 **********************************************************************************/
using CL_View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CL_View
{
    static class Program
    {
        /**************************************************************************
         * WORK FIELDS
         **************************************************************************/
        private static configuration m_ObjConfiguration;
        private static ArrayList m_ObjSearchResults = new ArrayList();

        /**************************************************************************
         * PROPERTIES
         **************************************************************************/
        public static configuration Configuration { get { return m_ObjConfiguration; } set { } }


        /**************************************************************************
         * SUBROUTINES
         **************************************************************************/
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //Initialize the application.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Load the xml configuration.
            LoadConfiguration();
            
            //Check for the result.
            configform l_ObjSettingsForm = new configform();
            if (l_ObjSettingsForm.ShowDialog() != DialogResult.Cancel)
            {

                //Perform the search.
                Search();
            }

            //Start the message handling loop.
            Application.Run();
        }

        
        /// <summary>
        /// This routne loads the configuration XML file from disk.
        /// </summary>
        public static void LoadConfiguration()
        {

            //Instantiate the xml deserializer.
            XmlSerializer l_ObjXMLSerializer = new XmlSerializer(typeof(configuration));

            //Open the config.xml file via file stream.
            FileStream l_ObjFileStream = new FileStream(@"..\..\config.xml", FileMode.Open, FileAccess.Read);
            
            //Deserialize the configuration object.
            m_ObjConfiguration = (configuration)l_ObjXMLSerializer.Deserialize(l_ObjFileStream);

            //Close the output stream.
            l_ObjFileStream.Close();
        }


        /// <summary>
        /// This routne loads the configuration XML file from disk.
        /// </summary>
        public static void SaveConfiguration()
        {

            //Instantiate the xml deserializer.
            XmlSerializer l_ObjXMLSerializer = new XmlSerializer(typeof(configuration));

            //Open the config.xml file via file stream.
            FileStream l_ObjFileStream = new FileStream(@"..\..\config.xml", FileMode.Create, FileAccess.Write);

            //Deserialize the configuration object.
            l_ObjXMLSerializer.Serialize(l_ObjFileStream, m_ObjConfiguration);

            //Close the output stream.
            l_ObjFileStream.Close();
        }




        /// <summary>
        /// This routine performs an advanced search on craigslist.org.
        /// </summary>
        private static void Search()
        {
            int l_IntAssignedDomains = 0;
            ArrayList l_ObjSearchThreads = new ArrayList();

            //Select the list of domains to search.
            ArrayList l_ObjDomains = RetrieveDomainsToSearch();

            //If we have fewer domains to search than threads, than we'll simply
            //run them all now.
            if(Configuration.setup.maxthreads >= Configuration.setup.maxdomains)
            {

                //Create a thread for each domain.
                foreach (configurationSetupDomain l_ObjCurrentDomain in l_ObjDomains)
                {

                    //Set the last use time for the current domain.
                    l_ObjCurrentDomain.lastquery = DateTime.Now.ToString();

                    //Create the new search thread.
                    AsyncSearch l_ObjSearchThread = new AsyncSearch(l_ObjCurrentDomain.link, Configuration.filter.keywords);

                    //Add it to the list.
                    l_ObjSearchThreads.Add(l_ObjSearchThread);

                    //Kick off the thread.
                    l_ObjSearchThread.Launch();

                    //Set the number of assigned domains.
                    l_IntAssignedDomains++;
                }

                //Wait for the search to complete.
                while (!SearchComplete(l_ObjSearchThreads, l_IntAssignedDomains)) { Application.DoEvents(); }
            }
            
            //We have more domains than permitted threads.
            else
            {


                //Create a thread for each domain.
                for(l_IntAssignedDomains = 0; l_IntAssignedDomains < Configuration.setup.maxthreads; l_IntAssignedDomains++)
                {

                    //Set the last use time for the current domain.
                    ((configurationSetupDomain)l_ObjDomains[l_IntAssignedDomains]).lastquery = DateTime.Now.ToString();

                    //Create the new search thread.
                    AsyncSearch l_ObjSearchThread = new AsyncSearch(((configurationSetupDomain)l_ObjDomains[l_IntAssignedDomains]).link, Configuration.filter.keywords);

                    //Add it to the list.
                    l_ObjSearchThreads.Add(l_ObjSearchThread);

                    //Kick off the thread.
                    l_ObjSearchThread.Launch();
                }

                //Now loop continuously, checking the thread count and domain count.
                while (!SearchComplete(l_ObjSearchThreads, l_IntAssignedDomains))
                {

                    //Allow the operating system to think.
                    Application.DoEvents();
                    
                    //Check the thread count vs the domain count. If we have a free thread, and
                    //we still have domains to search, que it up.
                    if(GetActiveThreadCount(l_ObjSearchThreads) < Configuration.setup.maxthreads 
                        && l_IntAssignedDomains < Configuration.setup.maxdomains)
                    {

                        //Set the last use time for the current domain.
                        ((configurationSetupDomain)l_ObjDomains[l_IntAssignedDomains]).lastquery = DateTime.Now.ToString();

                        //Create the new search thread.
                        AsyncSearch l_ObjSearchThread = new AsyncSearch(((configurationSetupDomain)l_ObjDomains[l_IntAssignedDomains]).link, Configuration.filter.keywords);
                        
                        //Create a new thread.
                        l_ObjSearchThreads.Add(l_ObjSearchThread);

                        //Kick off the thread.
                        l_ObjSearchThread.Launch();

                        //Set the number of assigned domains.
                        l_IntAssignedDomains++;
                    }
                }
            }

            //Clear any previous search.
            m_ObjSearchResults.Clear();

            //Now we must merge all of the search results.
            foreach(AsyncSearch l_ObjSearch in l_ObjSearchThreads)
            {

                //Add each result.
                foreach (AsyncSearchResult l_ObjResult in l_ObjSearch.Results)
                    m_ObjSearchResults.Add(l_ObjResult);
            }

            //Save the new use dates.
            SaveConfiguration();

            int i = 0;
        }


        /// <summary>
        /// This routine determines if the search is complete.
        /// </summary>
        /// <param name="p_ObjSearchThreads"></param>
        /// <param name="p_IntAssignedDomains"></param>
        /// <returns></returns>
        private static bool SearchComplete(ArrayList p_ObjSearchThreads, int p_IntAssignedDomains)
        {
            bool l_BlnResult = true; //Default result is true/search complete.
            bool l_BlnIncomplete = false; //Set to true if we find any incomplete searches.

            //Loop through all search threads. If we find one that is not complete return false.
            foreach(AsyncSearch l_ObjCurrentSearch in p_ObjSearchThreads)
            {

                //Check for incomplete thread.
                if(l_ObjCurrentSearch.Status < 3)
                {

                    //Set the flag.
                    l_BlnIncomplete = true;

                    //End the loop.
                    break;
                }
            }

            //Determine if the search is complete.
            if (l_BlnIncomplete || p_IntAssignedDomains < Configuration.setup.maxdomains) l_BlnResult = false;

            //Return the result.
            return l_BlnResult;
        }


        /// <summary>
        /// This routine counts all active threads.
        /// </summary>
        /// <param name="p_ObjSearchThreads"></param>
        /// <returns></returns>
        private static int GetActiveThreadCount(ArrayList p_ObjSearchThreads)
        {
            int l_IntResult = 0; //Default result is zero.

            //Loop through all thread objects and count the active ones.
            foreach(AsyncSearch l_ObjThread in p_ObjSearchThreads)
            {

                //Count all active threads.
                if (l_ObjThread.Status < 3) l_IntResult++;
            }

            //Return the result.
            return l_IntResult;
        }


        /// <summary>
        /// This routine returns the list of domains to search.
        /// </summary>
        /// <returns></returns>
        private static ArrayList RetrieveDomainsToSearch()
        {
            ArrayList l_ObjResult = new ArrayList();
            ArrayList l_ObjCompleteList = new ArrayList(Configuration.setup.domains);

            //Sort the domain list by their last query dates.
            l_ObjCompleteList.Sort(new configurationSetupDomainComparer());

            //Grab the selected domains.
            l_ObjResult.AddRange(l_ObjCompleteList.GetRange(0, Configuration.setup.maxdomains));
            
            //Return the result.
            return l_ObjResult;
        } 
    }
}
