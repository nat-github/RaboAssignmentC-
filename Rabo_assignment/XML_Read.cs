using System;
using System.Xml.Linq;

namespace Rabo_assignment
{
   public class XML_Read
    {
        string _reference, _accountnumber, _description;
        double _StartBalance, _Mutation, _EndBalance;
        public string Reference
        {
            get
            {
                return this._reference;
            }
            set
            {
                _reference = value;
            }
        }
        public string AccountNumber
        {
            get
            {
                return this._accountnumber;
            }
            set
            {
                _accountnumber = value;
            }
        }
        public string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                this._description = value;
            }
        }
        public double StartBalance
        {
            get
            {
                return this._StartBalance;
            }
            set
            {
                this._StartBalance = value;
            }
        }
        public double Mutation
        {
            get
            {
                return this._Mutation;
            }
            set
            {
                this._Mutation = value;
            }
        }
        public double EndBalance
        {
            get
            {
                return this._EndBalance;
            }
            set
            {
                this._EndBalance = value;
            }
        }
        DuplicateValues dc = new DuplicateValues();
        Check_EndBalance CE = new Check_EndBalance();
        public void ReadXML(string inputFile)
        {
            try
            {
                Logging.log_message("****XML Validation*****");
                Console.WriteLine("***XML Validation***");
                XDocument doc = XDocument.Load(inputFile);
                var records = doc.Element("records").Elements("record");
                foreach (XElement elem in records)
                {
                    Reference = elem.Attribute("reference").Value;
                    AccountNumber = elem.Element("accountNumber").Value;
                    Description = elem.Element("description").Value;
                    StartBalance = Convert.ToDouble(elem.Element("startBalance").Value.Trim());
                    Mutation = Convert.ToDouble(elem.Element("mutation").Value.Trim());
                    EndBalance = Convert.ToDouble(elem.Element("endBalance").Value.Trim());
                    dc._checkvalue(Reference, Description);
                    CE.computation(Reference, StartBalance, Mutation, EndBalance);
                }
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
            }
 
        }
    }
}
