/**********************************************************************************
 * (C) 2015 Daniel Dorpinghaus
 * 
 * Application: Craigs List View
 * File:        configform.cs
 * Date:        04-26-2016
 * Author:      Daniel Dorpinghaus
 * Description: This class implements the settings form that allows the user to
 *              manipulate the configuration xml file.
 * 
 **********************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CL_View
{
    public partial class configform : Form
    {
        /**************************************************************************
         * WORK FIELDS
         **************************************************************************/


        /**************************************************************************
         * PROPERTIES
         **************************************************************************/


        /**************************************************************************
         * SUBROUTINES
         **************************************************************************/
         /// <summary>
         /// Form constructor.
         /// </summary>
        public configform()
        {
            InitializeComponent();
        }


        /// <summary>
        /// This routine is called when the settings form loads.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void configform_Load(object sender, EventArgs e)
        {

            //SETUP Page
            //Populate the form fields with the xml values.
            numMaxDomains.Value = Program.Configuration.setup.maxdomains;
            numMaxThreads.Value = Program.Configuration.setup.maxthreads;
            foreach(configurationSetupDomain l_ObjDomain in Program.Configuration.setup.domains)
                lstDomains.Items.Add(l_ObjDomain.label, l_ObjDomain.enabled);
            
            //FILTER Page
            txtKeywords.Text = Program.Configuration.filter.keywords;

            //OUTPUT Page
            txtCSVPath.Text = Program.Configuration.output.csvoutputpath;
            chkEnablePDFOutput.Checked = Convert.ToBoolean(Program.Configuration.output.enablepdfoutput);
            txtPDFPath.Text = Program.Configuration.output.pdfoutputpath;
            chkEmailPDF.Checked = Convert.ToBoolean(Program.Configuration.output.enableemailpdf);
            txtEmailPDFTo.Text = Program.Configuration.output.pdfemailrecipient;
        }


        /// <summary>
        /// Update the Max threads in the xml file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numMaxThreads_ValueChanged(object sender, EventArgs e)
        {

            //Set the value.
            Program.Configuration.setup.maxthreads = Convert.ToByte(numMaxThreads.Value);
        }


        /// <summary>
        /// Update the Max Domains in the xml file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numMaxDomains_ValueChanged(object sender, EventArgs e)
        {

            //Attempt to process normally.
            try
            {

                //Set the value.
                Program.Configuration.setup.maxdomains = Convert.ToByte(numMaxDomains.Value);
            }

            //Handle any errors.
            catch(Exception l_ObjException) { Program.Configuration.setup.maxdomains = 255; }
        }


        /// <summary>
        /// Update the domains list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstDomains_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            //Set the value.
            Program.Configuration.setup.domains[e.Index].enabled = Convert.ToBoolean(e.NewValue);
        }


        /// <summary>
        /// This routine saves the xml updates to file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {

            //Save the settings changes.
            Program.SaveConfiguration();

            //Close the form.
            this.Close();
        }


        /// <summary>
        /// Upate the keywords
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtKeywords_TextChanged(object sender, EventArgs e)
        {

            //Set the keywords value.
            Program.Configuration.filter.keywords = txtKeywords.Text;
        }


        /// <summary>
        /// Update the path to the csv file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCSVPath_TextChanged(object sender, EventArgs e)
        {

            //Set the value.
            Program.Configuration.output.csvoutputpath = txtCSVPath.Text;
        }


        /// <summary>
        /// Enable/Disable pdf output.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkEnablePDFOutput_CheckedChanged(object sender, EventArgs e)
        {

            //Set the value.
            Program.Configuration.output.enablepdfoutput = chkEnablePDFOutput.Checked;
        }


        /// <summary>
        /// Update the pdf output path.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPDFPath_TextChanged(object sender, EventArgs e)
        {

            //Set the value.
            Program.Configuration.output.pdfoutputpath = txtPDFPath.Text;
        }


        /// <summary>
        /// Enable/Disable emailing of PDF.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkEmailPDF_CheckedChanged(object sender, EventArgs e)
        {

            //Set the value.
            Program.Configuration.output.enableemailpdf = chkEnablePDFOutput.Checked;
        }


        /// <summary>
        /// Update the pdf email recipient address.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEmailPDFTo_TextChanged(object sender, EventArgs e)
        {

            //Set the value.
            Program.Configuration.output.pdfemailrecipient = txtEmailPDFTo.Text;
        }


        /// <summary>
        /// Browse button opens folder dialog to select csv output folder.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCSVPathBrowse_Click(object sender, EventArgs e)
        {

            //Was the operation cancelled.
            if(fldBrowse.ShowDialog() != DialogResult.Cancel)
            {

                //Set the value.
                txtCSVPath.Text = fldBrowse.SelectedPath;
            }
        }


        /// <summary>
        /// Browse button opens folder dialog to select pdf output folder.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPDFPathBrowse_Click(object sender, EventArgs e)
        {

            //Was the operation cancelled.
            if (fldBrowse.ShowDialog() != DialogResult.Cancel)
            {

                //Set the value.
                txtPDFPath.Text = fldBrowse.SelectedPath;
            }
        }

        private void tabSetup_Click(object sender, EventArgs e)
        {

        }
    }
}
