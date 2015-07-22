using System;
using System.IO;
using System.Xml;

namespace ICCProfReader
{
    public class Work
    {
        public ICCProfile iccProfile;

        //get icc profile from file
        public void GetProfile(string path)
        {
            try
            {
                iccProfile = new ICCProfile(File.ReadAllBytes(path));
            }
            catch (FileNotFoundException ex)
            { Console.WriteLine(ex.Message); }
        }

        //get color type, number of color components and profile description
        public void GetData()
        {
            iccProfile.GetAll();
        }

        public void PrintToJSON()
        {
            try
            {
                StreamWriter sw = new StreamWriter("out.json");
                sw.WriteLine("{");
                sw.WriteLine("\"Type\":\"" + iccProfile.ClrType.ToString() + "\",");
                sw.WriteLine("\"Number of components\":\"" + iccProfile.NumComponents + "\",");
                sw.WriteLine("\"Description\":\"" + iccProfile.Description + "\"");
                sw.WriteLine("}");
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void PrintToXML()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement xmlRoot = xmlDoc.CreateElement("ICCProfile");
            XmlElement[] xmlList = { xmlDoc.CreateElement("Type"), xmlDoc.CreateElement("Number_of_components"), xmlDoc.CreateElement("Description") };
            xmlList[0].AppendChild(xmlDoc.CreateTextNode(iccProfile.ClrType.ToString()));
            xmlList[1].AppendChild(xmlDoc.CreateTextNode(iccProfile.NumComponents));
            xmlList[2].AppendChild(xmlDoc.CreateTextNode(iccProfile.Description));
            foreach (XmlElement xe in xmlList)
            {
                xmlRoot.AppendChild(xe);
            }
            xmlDoc.AppendChild(xmlRoot);
            xmlDoc.Save("out.xml");
        }

        public void PrintToConsole()
        {
            Console.WriteLine("Type: {0}\nNumber of components: {1}\nDescription: {2}",
                iccProfile.ClrType.ToString(),
                iccProfile.NumComponents,
                iccProfile.Description);
        }
    }

}
