/**********************************************************************************
 * (C) 2015 Daniel Dorpinghaus
 * 
 * Application: Craigs List View
 * File:        AsyncSearch.cs
 * Date:        05-01-2016
 * Author:      Daniel Dorpinghaus
 * Description: This file implements all of the classes required to manipulate the
 *              settings stored in the config.xml file. This class was auto-gen'd
 *              in Visual Studio.
 **********************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_View
{


    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class configuration
    {

        private configurationAbout aboutField;

        private configurationSetup setupField;

        private configurationFilter filterField;

        private configurationOutput outputField;

        /// <remarks/>
        public configurationAbout about
        {
            get
            {
                return this.aboutField;
            }
            set
            {
                this.aboutField = value;
            }
        }

        /// <remarks/>
        public configurationSetup setup
        {
            get
            {
                return this.setupField;
            }
            set
            {
                this.setupField = value;
            }
        }

        /// <remarks/>
        public configurationFilter filter
        {
            get
            {
                return this.filterField;
            }
            set
            {
                this.filterField = value;
            }
        }

        /// <remarks/>
        public configurationOutput output
        {
            get
            {
                return this.outputField;
            }
            set
            {
                this.outputField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class configurationAbout
    {

        private string titleField;

        private string descriptionField;

        private string versionField;

        /// <remarks/>
        public string title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }

        /// <remarks/>
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        public string version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class configurationSetup
    {

        private byte maxthreadsField;

        private byte maxdomainsField;

        private configurationSetupDomain[] domainsField;

        /// <remarks/>
        public byte maxthreads
        {
            get
            {
                return this.maxthreadsField;
            }
            set
            {
                this.maxthreadsField = value;
            }
        }

        /// <remarks/>
        public byte maxdomains
        {
            get
            {
                return this.maxdomainsField;
            }
            set
            {
                this.maxdomainsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("domain", IsNullable = false)]
        public configurationSetupDomain[] domains
        {
            get
            {
                return this.domainsField;
            }
            set
            {
                this.domainsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class configurationSetupDomain
    {

        private string linkField;

        private string labelField;

        private bool enabledField;

        private string lastqueryField;

        /// <remarks/>
        public string link
        {
            get
            {
                return this.linkField;
            }
            set
            {
                this.linkField = value;
            }
        }

        /// <remarks/>
        public string label
        {
            get
            {
                return this.labelField;
            }
            set
            {
                this.labelField = value;
            }
        }

        /// <remarks/>
        public bool enabled
        {
            get
            {
                return this.enabledField;
            }
            set
            {
                this.enabledField = value;
            }
        }

        /// <remarks/>
        public string lastquery
        {
            get
            {
                return this.lastqueryField;
            }
            set
            {
                this.lastqueryField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class configurationFilter
    {

        private string keywordsField;

        /// <remarks/>
        public string keywords
        {
            get
            {
                return this.keywordsField;
            }
            set
            {
                this.keywordsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class configurationOutput
    {

        private bool enablepdfoutputField;

        private string pdfoutputpathField;

        private bool enableemailpdfField;

        private string pdfemailrecipientField;

        private string csvoutputpathField;

        /// <remarks/>
        public bool enablepdfoutput
        {
            get
            {
                return this.enablepdfoutputField;
            }
            set
            {
                this.enablepdfoutputField = value;
            }
        }

        /// <remarks/>
        public string pdfoutputpath
        {
            get
            {
                return this.pdfoutputpathField;
            }
            set
            {
                this.pdfoutputpathField = value;
            }
        }

        /// <remarks/>
        public bool enableemailpdf
        {
            get
            {
                return this.enableemailpdfField;
            }
            set
            {
                this.enableemailpdfField = value;
            }
        }

        /// <remarks/>
        public string pdfemailrecipient
        {
            get
            {
                return this.pdfemailrecipientField;
            }
            set
            {
                this.pdfemailrecipientField = value;
            }
        }

        /// <remarks/>
        public string csvoutputpath
        {
            get
            {
                return this.csvoutputpathField;
            }
            set
            {
                this.csvoutputpathField = value;
            }
        }
    }

    
    public class configurationSetupDomainComparer : IComparer
    {
        public int Compare(object x, object y)
        {

            configurationSetupDomain loanX = x as configurationSetupDomain;
            configurationSetupDomain loanY = y as configurationSetupDomain;

            if (x == y) return 0;
            if (loanX.lastquery == "Never") return 1;
            if (loanY.lastquery == "Never") return -1;

            if ((DateTime.Parse(loanX.lastquery).Ticks - DateTime.Parse(loanY.lastquery).Ticks) < 0) return 1;
            else if ((DateTime.Parse(loanX.lastquery).Ticks - DateTime.Parse(loanY.lastquery).Ticks) > 0) return -1;
            else return 0;
        }
    }
}
