using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

/**
 * --- DataElement: Holds the raw voltage recording that this entire table is made of.
 *          * The index field describes the element's position within a column. The first element
 *          has an index equal to 0, and the final element has an index equal to the number of rows.
 *          * The value field is the voltage recording itself. Pretty self explanatory
 * ---  ColData: Describes a single column of elements
 *          * The index indicates which column number we are looking at. Time column excluded.
 *          * colElements is a list of all of the DataElements found within the column.
 *          
 * ---  TextToXml: 
 *          * The general idea here is to take in a text file with a specific format, and output
 *          that information into a more versatile and easier format to work with: XML.
 *          
 *          
 **/
namespace vrtranslate
{

    class XmlOutput
    {
        class DataElement
        {
            public int index { get; set; }
            public double value { get; set; }
        }

        class ColData
        {
            public List<DataElement> colElements { get; set; }
            public int index { get; set; }
        }

        public static void TextToXml(string inDirectory, string inFile, string outDirectory, string outFileName)
        {
            List<string> electrodeNames = new List<string>();

            List<double> timeSlices = new List<double>();
            List<ColData> colDataSet = new List<ColData>();

            string directory = inDirectory;
            string fileName = inFile;
            StreamReader reader = new StreamReader(directory + fileName);

            // Header line looks like "T[s]\tName\tName\tName"
            // Read the header, skip over the T[s] portion. Then put the names into a list
            // At the same time, use the header electrode names to determine the number
            // of columns in the file
            int columnCount = 0;
            foreach (string name in reader.ReadLine().Split('\t'))
            {
                if (name == "T[s]")
                    continue;
                electrodeNames.Add(name);
                columnCount++;
            }

            // Empty line between header and data. Skip over empty line
            reader.ReadLine();

            /**
             * For every column in the file (found by counting header names),
             * generate a new ColData object to put into the overall data set
             **/
            for (int i = 0; i < columnCount; i++)
            {
                ColData column = new ColData();
                column.index = i;
                column.colElements = new List<DataElement>();

                colDataSet.Add(column);
            }


            /**
             * Each data row looks like "Time\tValue\tValue\tValue"
             * Pull out time, then get data
            **/

            // RowIndex quite simply keeps track of what row is being read in the file. We need
            // this to determine where to place the data within the column element list.
            int rowIndex = 0;

            // Loop through all of the rows in the file
            while (!reader.EndOfStream)
            {
                // read in the row
                string row = reader.ReadLine();

                // find where the time value ends and data entries begin
                int indexOfFirstTab = row.IndexOf('\t');

                // store the time, from front of row
                double time = Convert.ToDouble(row.Substring(0, indexOfFirstTab));
                timeSlices.Add(time);

                // All of the row's data go into rowValues. 
                List<string> rowValues = new List<string>();

                // Just need to separate the different values from the string cluster
                // holding all of the data
                foreach (string reading in row.Substring(indexOfFirstTab + 1).Split('\t'))
                {
                    rowValues.Add(reading);
                }

                // Place one piece of data in each column for this particular row
                for (int i = 0; i < columnCount; i++)
                {
                    colDataSet[i].colElements.Add(new DataElement());
                    colDataSet[i].colElements[rowIndex].value = Convert.ToDouble(rowValues[i]);
                }

                rowIndex++;
            }




            //write xml data
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            XmlNode fileNameNode = doc.CreateElement("File_Name");
            XmlAttribute fileNameAttribute = doc.CreateAttribute("value");
            fileNameAttribute.Value = fileName;
            fileNameNode.Attributes.Append(fileNameAttribute);
            doc.AppendChild(fileNameNode);

            /**
             * int electrodeIndex = 0;
             * int timeSliceIndex = 0;
             * foreach(column in colDataSet)
             *  add electrode name node
             *  foreach(dataelement in column)
             *      add time in to file
             *      value = dataelement.value
             **/
            int electrodeIndex = 0;

            foreach (ColData column in colDataSet)
            {
                int timeSliceIndex = 0;
                // electrode node
                XmlNode electrodeNode = doc.CreateElement("Electrode");
                XmlAttribute electrodeAttribute = doc.CreateAttribute("id");
                electrodeAttribute.Value = electrodeNames[electrodeIndex];
                electrodeNode.Attributes.Append(electrodeAttribute);
                fileNameNode.AppendChild(electrodeNode);

                foreach (DataElement element in column.colElements)
                {
                    XmlNode timeSliceNode = doc.CreateElement("Time");
                    XmlAttribute timeSliceAttribute = doc.CreateAttribute("id");
                    timeSliceAttribute.Value = timeSlices[timeSliceIndex].ToString();
                    timeSliceNode.Attributes.Append(timeSliceAttribute);

                    timeSliceNode.AppendChild(doc.CreateTextNode(element.value.ToString()));
                    electrodeNode.AppendChild(timeSliceNode);

                    timeSliceIndex++;
                }

                electrodeIndex++;
            }

            outFileName = fileName.Substring(0, fileName.LastIndexOf("."));
            doc.Save(outDirectory + outFileName + ".xml");
        }
    }
}
