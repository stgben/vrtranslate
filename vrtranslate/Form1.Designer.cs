namespace vrtranslate
{
    partial class Form1
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
            this.browseTextFile = new System.Windows.Forms.Button();
            this.convertToXml = new System.Windows.Forms.Button();
            this.textFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveXMLOutputFile = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // browseTextFile
            // 
            this.browseTextFile.Location = new System.Drawing.Point(607, 136);
            this.browseTextFile.Name = "browseTextFile";
            this.browseTextFile.Size = new System.Drawing.Size(84, 23);
            this.browseTextFile.TabIndex = 2;
            this.browseTextFile.Text = "Browse...";
            this.browseTextFile.UseVisualStyleBackColor = true;
            this.browseTextFile.Click += new System.EventHandler(this.browseTextFile_Click);
            // 
            // convertToXml
            // 
            this.convertToXml.Location = new System.Drawing.Point(497, 162);
            this.convertToXml.Name = "convertToXml";
            this.convertToXml.Size = new System.Drawing.Size(104, 23);
            this.convertToXml.TabIndex = 3;
            this.convertToXml.Text = "Convert";
            this.convertToXml.UseVisualStyleBackColor = true;
            this.convertToXml.Click += new System.EventHandler(this.convertToXml_Click);
            // 
            // textFileName
            // 
            this.textFileName.Location = new System.Drawing.Point(402, 136);
            this.textFileName.Name = "textFileName";
            this.textFileName.Size = new System.Drawing.Size(199, 20);
            this.textFileName.TabIndex = 4;
            this.textFileName.Tag = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(399, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select File to Convert to XML";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // saveXMLOutputFile
            // 
            this.saveXMLOutputFile.FileOk += new System.ComponentModel.CancelEventHandler(this.saveXMLOutputFile_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 385);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textFileName);
            this.Controls.Add(this.convertToXml);
            this.Controls.Add(this.browseTextFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button browseTextFile;
        private System.Windows.Forms.Button convertToXml;
        private System.Windows.Forms.TextBox textFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog saveXMLOutputFile;
    }
}

