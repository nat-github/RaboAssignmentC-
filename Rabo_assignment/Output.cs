using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Configuration;
using System.Xml.Linq;
namespace Rabo_assignment
{
    class Output
    {
        //static string _outputXMLFile = ConfigurationSettings.AppSettings["OutputXML_EndBalance"];
        //static string _outputXMLFileDuplicate = ConfigurationSettings.AppSettings["OutputXML_Duplicate"];
        static string _filepath = Environment.CurrentDirectory;
        static string _outputXMLFile = _filepath + "\\Assignment\\EndBalance.xml";
        static string _outputXMLFileDuplicate = _filepath + "\\Assignment\\DuplicateValues.xml";
        XDocument xdoc = XDocument.Load(_outputXMLFile);
        XDocument Ddoc = XDocument.Load(_outputXMLFileDuplicate);
        public void XMLWrite(string _reference,double sum,string text)
        {
            XElement root = new XElement("record");
            root.Add(new XElement("Timestamp",DateTime.Now));
            root.Add(new XElement("Reference", _reference));
            root.Add(new XElement("Sum", sum.ToString()));
            root.Add(new XElement("Message", text));
            xdoc.Element("records").Add(root);
            xdoc.Save(_outputXMLFile);           
        }
        public void DuplicateXML(string _reference, string description)
        {
            XElement root = new XElement("record");
            root.Add(new XElement("Timestamp", DateTime.Now));
            root.Add(new XElement("Reference", _reference));
            root.Add(new XElement("Description", description));
            Ddoc.Element("records").Add(root);
            Ddoc.Save(_outputXMLFileDuplicate);

        }
    }
}
