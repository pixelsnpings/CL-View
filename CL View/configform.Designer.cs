namespace CL_View
{
    partial class configform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(configform));
            this.ConfigurationTabs = new System.Windows.Forms.TabControl();
            this.tabSetup = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.numMaxDomains = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numMaxThreads = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lstDomains = new System.Windows.Forms.CheckedListBox();
            this.tabFilter = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKeywords = new System.Windows.Forms.TextBox();
            this.tabOutput = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCSVPathBrowse = new System.Windows.Forms.Button();
            this.txtCSVPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtEmailPDFTo = new System.Windows.Forms.TextBox();
            this.btnPDFPathBrowse = new System.Windows.Forms.Button();
            this.chkEmailPDF = new System.Windows.Forms.CheckBox();
            this.txtPDFPath = new System.Windows.Forms.TextBox();
            this.chkEnablePDFOutput = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.fldBrowse = new System.Windows.Forms.FolderBrowserDialog();
            this.ConfigurationTabs.SuspendLayout();
            this.tabSetup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxDomains)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxThreads)).BeginInit();
            this.tabFilter.SuspendLayout();
            this.tabOutput.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConfigurationTabs
            // 
            this.ConfigurationTabs.Controls.Add(this.tabSetup);
            this.ConfigurationTabs.Controls.Add(this.tabFilter);
            this.ConfigurationTabs.Controls.Add(this.tabOutput);
            resources.ApplyResources(this.ConfigurationTabs, "ConfigurationTabs");
            this.ConfigurationTabs.Name = "ConfigurationTabs";
            this.ConfigurationTabs.SelectedIndex = 0;
            // 
            // tabSetup
            // 
            this.tabSetup.Controls.Add(this.label3);
            this.tabSetup.Controls.Add(this.numMaxDomains);
            this.tabSetup.Controls.Add(this.label2);
            this.tabSetup.Controls.Add(this.numMaxThreads);
            this.tabSetup.Controls.Add(this.label1);
            this.tabSetup.Controls.Add(this.lstDomains);
            resources.ApplyResources(this.tabSetup, "tabSetup");
            this.tabSetup.Name = "tabSetup";
            this.tabSetup.UseVisualStyleBackColor = true;
            this.tabSetup.Click += new System.EventHandler(this.tabSetup_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // numMaxDomains
            // 
            resources.ApplyResources(this.numMaxDomains, "numMaxDomains");
            this.numMaxDomains.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numMaxDomains.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxDomains.Name = "numMaxDomains";
            this.numMaxDomains.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxDomains.ValueChanged += new System.EventHandler(this.numMaxDomains_ValueChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // numMaxThreads
            // 
            resources.ApplyResources(this.numMaxThreads, "numMaxThreads");
            this.numMaxThreads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxThreads.Name = "numMaxThreads";
            this.numMaxThreads.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaxThreads.ValueChanged += new System.EventHandler(this.numMaxThreads_ValueChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lstDomains
            // 
            this.lstDomains.FormattingEnabled = true;
            resources.ApplyResources(this.lstDomains, "lstDomains");
            this.lstDomains.Name = "lstDomains";
            this.lstDomains.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstDomains_ItemCheck);
            // 
            // tabFilter
            // 
            this.tabFilter.Controls.Add(this.label4);
            this.tabFilter.Controls.Add(this.txtKeywords);
            resources.ApplyResources(this.tabFilter, "tabFilter");
            this.tabFilter.Name = "tabFilter";
            this.tabFilter.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txtKeywords
            // 
            resources.ApplyResources(this.txtKeywords, "txtKeywords");
            this.txtKeywords.Name = "txtKeywords";
            this.txtKeywords.TextChanged += new System.EventHandler(this.txtKeywords_TextChanged);
            // 
            // tabOutput
            // 
            this.tabOutput.Controls.Add(this.groupBox2);
            this.tabOutput.Controls.Add(this.groupBox1);
            resources.ApplyResources(this.tabOutput, "tabOutput");
            this.tabOutput.Name = "tabOutput";
            this.tabOutput.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCSVPathBrowse);
            this.groupBox2.Controls.Add(this.txtCSVPath);
            this.groupBox2.Controls.Add(this.label5);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // btnCSVPathBrowse
            // 
            resources.ApplyResources(this.btnCSVPathBrowse, "btnCSVPathBrowse");
            this.btnCSVPathBrowse.Name = "btnCSVPathBrowse";
            this.btnCSVPathBrowse.UseVisualStyleBackColor = true;
            this.btnCSVPathBrowse.Click += new System.EventHandler(this.btnCSVPathBrowse_Click);
            // 
            // txtCSVPath
            // 
            resources.ApplyResources(this.txtCSVPath, "txtCSVPath");
            this.txtCSVPath.Name = "txtCSVPath";
            this.txtCSVPath.TextChanged += new System.EventHandler(this.txtCSVPath_TextChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtEmailPDFTo);
            this.groupBox1.Controls.Add(this.btnPDFPathBrowse);
            this.groupBox1.Controls.Add(this.chkEmailPDF);
            this.groupBox1.Controls.Add(this.txtPDFPath);
            this.groupBox1.Controls.Add(this.chkEnablePDFOutput);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // txtEmailPDFTo
            // 
            resources.ApplyResources(this.txtEmailPDFTo, "txtEmailPDFTo");
            this.txtEmailPDFTo.Name = "txtEmailPDFTo";
            this.txtEmailPDFTo.TextChanged += new System.EventHandler(this.txtEmailPDFTo_TextChanged);
            // 
            // btnPDFPathBrowse
            // 
            resources.ApplyResources(this.btnPDFPathBrowse, "btnPDFPathBrowse");
            this.btnPDFPathBrowse.Name = "btnPDFPathBrowse";
            this.btnPDFPathBrowse.UseVisualStyleBackColor = true;
            this.btnPDFPathBrowse.Click += new System.EventHandler(this.btnPDFPathBrowse_Click);
            // 
            // chkEmailPDF
            // 
            resources.ApplyResources(this.chkEmailPDF, "chkEmailPDF");
            this.chkEmailPDF.Name = "chkEmailPDF";
            this.chkEmailPDF.UseVisualStyleBackColor = true;
            this.chkEmailPDF.CheckedChanged += new System.EventHandler(this.chkEmailPDF_CheckedChanged);
            // 
            // txtPDFPath
            // 
            resources.ApplyResources(this.txtPDFPath, "txtPDFPath");
            this.txtPDFPath.Name = "txtPDFPath";
            this.txtPDFPath.TextChanged += new System.EventHandler(this.txtPDFPath_TextChanged);
            // 
            // chkEnablePDFOutput
            // 
            resources.ApplyResources(this.chkEnablePDFOutput, "chkEnablePDFOutput");
            this.chkEnablePDFOutput.Name = "chkEnablePDFOutput";
            this.chkEnablePDFOutput.UseVisualStyleBackColor = true;
            this.chkEnablePDFOutput.CheckedChanged += new System.EventHandler(this.chkEnablePDFOutput_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnApply
            // 
            resources.ApplyResources(this.btnApply, "btnApply");
            this.btnApply.Name = "btnApply";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // configform
            // 
            this.AcceptButton = this.btnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.ConfigurationTabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "configform";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.configform_Load);
            this.ConfigurationTabs.ResumeLayout(false);
            this.tabSetup.ResumeLayout(false);
            this.tabSetup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxDomains)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxThreads)).EndInit();
            this.tabFilter.ResumeLayout(false);
            this.tabFilter.PerformLayout();
            this.tabOutput.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl ConfigurationTabs;
        private System.Windows.Forms.TabPage tabSetup;
        private System.Windows.Forms.TabPage tabFilter;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabPage tabOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox lstDomains;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numMaxDomains;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numMaxThreads;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtKeywords;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCSVPathBrowse;
        private System.Windows.Forms.TextBox txtCSVPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkEmailPDF;
        private System.Windows.Forms.CheckBox chkEnablePDFOutput;
        private System.Windows.Forms.Button btnPDFPathBrowse;
        private System.Windows.Forms.TextBox txtPDFPath;
        private System.Windows.Forms.TextBox txtEmailPDFTo;
        private System.Windows.Forms.FolderBrowserDialog fldBrowse;
    }
}