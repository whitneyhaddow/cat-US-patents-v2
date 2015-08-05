using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

//read from, and connect to, XML file to get/add patent objects
namespace Haddow_Whitney_Lab2_CP3
{
    class PatentDB
    {
        private const string path = "Patents.xml";

        //read XML file for patent info
        public static SortedList<int, Patent> GetPatents()
        {
            XmlDocument doc = new XmlDocument();

            //if file doesn't exist, create it
            if (!File.Exists("Patents.xml"))
                doc.Save("Patents.xml");

            SortedList<int, Patent> patents = new SortedList<int, Patent>();

            XmlReaderSettings readerSettings = new XmlReaderSettings(); 
            readerSettings.IgnoreWhitespace = true;
            readerSettings.IgnoreComments = true;

            XmlReader readXml = null; 

            try
            {
                readXml = XmlReader.Create(path, readerSettings);

                if (readXml.ReadToDescendant("Patent")) //read to first Patent node
                {
                    do 
                    {
                        Patent patent = new Patent();
                        patent.Number = Convert.ToInt32(readXml["Number"]);
                        readXml.ReadStartElement("Patent");
                        patent.AppNumber = readXml.ReadElementContentAsString();
                        patent.Description = readXml.ReadElementContentAsString();
                        patent.FilingDate = DateTime.Parse(readXml.ReadElementContentAsString());
                        patent.Inventor = readXml.ReadElementContentAsString();
                        patent.Inventor2 = readXml.ReadElementContentAsString();

                        int key = patent.Number; //assign key to value

                        patents.Add(key, patent); //add key-value pair to list
                    }
                    while (readXml.ReadToNextSibling("Patent")); 
                }
            }
            catch (XmlException ex)
            {
                MessageBox.Show(ex.Message, "Xml Error");
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "IO Exception");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Occurred");
            }
            finally
            {
                if (readXml != null)
                    readXml.Close();
            }

            return patents;

        } //END GET PATENTS


        //save any new patents to XML file
        public static void SavePatents(SortedList<int, Patent> patents)
        {
            XmlWriterSettings writerSettings = new XmlWriterSettings(); 
            writerSettings.Indent = true;
            writerSettings.IndentChars = ("    ");
            XmlWriter writeXml = null; 

            try
            {
                writeXml = XmlWriter.Create(path, writerSettings);

                writeXml.WriteStartDocument(); 
                writeXml.WriteStartElement("Patents");

                IList<Patent> patentValues = patents.Values;
                foreach (Patent patent in patentValues) //write each object in list to Xml file
                {
                    writeXml.WriteStartElement("Patent");
                    writeXml.WriteAttributeString("Number", patent.Number.ToString());
                    writeXml.WriteElementString("AppNumber", patent.AppNumber);
                    writeXml.WriteElementString("Description", patent.Description);
                    string datestring = patent.FilingDate.ToString("yyyy-MM-dd"); 
                    writeXml.WriteElementString("FilingDate", datestring);
                    writeXml.WriteElementString("Inventor", patent.Inventor);
                    writeXml.WriteElementString("Inventor2", patent.Inventor2);
                    writeXml.WriteEndElement();
                }

                writeXml.WriteEndElement(); //close tag of root element
            }
            catch (XmlException ex)
            {
                MessageBox.Show(ex.Message, "Xml Error");
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "IO Exception");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Occurred");
            }
            finally
            {
                if (writeXml != null)
                    writeXml.Close();
            }

        } //END SAVE PATENTS

    } //END CLASS
}
