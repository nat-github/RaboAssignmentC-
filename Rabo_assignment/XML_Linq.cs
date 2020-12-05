using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Configuration;

namespace Rabo_assignment
{
    class XML_Linq
    {
        static string _filepath = Environment.CurrentDirectory;
        string inputFile = _filepath + "\\Assignment\\records_normal.xml";
        DuplicateValues dc = new DuplicateValues();
        Check_EndBalance CE = new Check_EndBalance();
        public void XML_read()
        {
            try
            {
                XDocument doc = XDocument.Load(inputFile);
                var records = from record in doc.Descendants("records").Elements("record")
                              select new
                              {
                                  reference = record.Attribute("reference").Value,
                                  accountNumber = record.Element("accountNumber").Value,
                                  description = record.Element("description").Value,
                                  startBalance = Convert.ToDouble(record.Element("startBalance").Value.Trim()),
                                  mutation = Convert.ToDouble(record.Element("mutation").Value.Trim()),
                                  endBalance = Convert.ToDouble(record.Element("endBalance").Value.Trim())
                              };
                foreach (var record in records)
                {
                    #region
                    //Console.WriteLine(record.reference);
                    //Console.WriteLine(record.accountNumber);
                    //Console.WriteLine(record.description);
                    //Console.WriteLine(record.startBalance);
                    //Console.WriteLine(record.mutation);
                    //Console.WriteLine(record.endBalance);
                    #endregion
                    dc._checkvalue(record.reference, record.description);
                    CE.computation(record.reference, record.startBalance, record.mutation, record.endBalance);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private static void NewMethod()
        {
            Logging.log_message("****XML Validation*****");
            Console.WriteLine("***XML Validation***");
        }
    }
}
