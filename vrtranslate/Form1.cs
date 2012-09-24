using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace vrtranslate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void browseTextFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Select File to Convert";
            fdlg.InitialDirectory = @"C:\";
            fdlg.Filter = "Text (*.txt)|*.txt | DAT (*.dat)|*.dat";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                textFileName.Text = fdlg.FileName;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void convertToXml_Click(object sender, EventArgs e)
        {
            string inDirectory, filename;
            int indexOfLastBackslash = textFileName.Text.LastIndexOf("\\");
            inDirectory = textFileName.Text.Substring(0, indexOfLastBackslash);
            inFilename = textFileName.Text.Substring(indexOfLastBackslash+1);

            string fileLocationAndName;

            //XmlOutput.TextToXml(directory, filename);
        }

        private string saveXMLOutputFile_FileOk(object sender, CancelEventArgs e)
        {
            saveXMLOutputFile.InitialDirectory = (string)sender;
            string filename = saveXMLOutputFile.FileName;
            return filename;
        }

    }
}
