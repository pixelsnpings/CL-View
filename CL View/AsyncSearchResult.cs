/**********************************************************************************
 * (C) 2015 Daniel Dorpinghaus
 * 
 * Application: Craigs List View
 * File:        AsyncSearchResult.cs
 * Date:        04-26-2016
 * Author:      Daniel Dorpinghaus
 * Description: This class implements a data structure used to store and manipulate
 *              a single search result.
 * 
 **********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_View
{
    class AsyncSearchResult
    {
        /**************************************************************************
         * WORK FIELDS 
         **************************************************************************/
        private String m_StrTitle = "";
        private String m_StrLink = "";
        private DateTime m_ObjPostingDate;
        private String m_StrDescription = "";
        private String m_StrPostingID = "";
        private String m_StrEmailAddress = "";
        private String m_StrPhoneNumber = "";


        /**************************************************************************
         * PROPERTIES
         **************************************************************************/
        public String Title { get { return m_StrTitle; } set { } }
        public String Link { get { return m_StrLink; } set { } }
        public DateTime PostingDate { get { return m_ObjPostingDate; } set { } }
        public String Description { get { return m_StrDescription; } set { } }
        public String PostingID { get { return m_StrPostingID; } set { } }
        public String EmailAddress { get { return m_StrEmailAddress; } set { } }
        public String PhoneNumber { get { return m_StrPhoneNumber; } set { } }


        /**************************************************************************
         * SUBROUTINES 
         **************************************************************************/
        /// <summary>
        /// This routine initializes this object with data..
        /// </summary>
        /// <param name="p_StrTitle"></param>
        /// <param name="p_StrLink"></param>
        /// <param name="p_StrDescription"></param>
        /// <param name="p_ObjPostingDate"></param>
        public AsyncSearchResult(String p_StrTitle, String p_StrLink, String p_StrDescription, DateTime p_ObjPostingDate, String p_StrPostingID, String p_StrEmailAddress, String p_StrPhoneNumber)
        {

            //Copy the values.
            m_StrTitle = p_StrTitle;
            m_StrLink = p_StrLink;
            m_StrDescription = p_StrDescription;
            m_ObjPostingDate = p_ObjPostingDate;
            m_StrPostingID = p_StrPostingID;
            m_StrEmailAddress = p_StrEmailAddress;
            m_StrPhoneNumber = p_StrPhoneNumber;
        }
    }
}
