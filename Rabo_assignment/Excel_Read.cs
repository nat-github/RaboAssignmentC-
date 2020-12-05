using System;
using System.IO;
using System.Collections.Generic;
using System.Data.OleDb;

namespace Rabo_assignment
{
    public class Excel_Read
    {
        OleDbConnection con_input;
        OleDbCommand objCmdSelect;
        OleDbDataReader reader;
        List<string> _listReference = new List<string>();
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
        public void _inputFile(String Filename)
        {
            Logging.log_message(DateTime.Now.ToString());
            Logging.log_message("****XL Validation*****");
            Console.WriteLine("****XL Validation*****");
            try
            {
                con_input = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Filename + "; Extended Properties=" + (char)34 + "Excel 8.0;HDR=YES;" + (char)34);
                con_input.Open();
                Console.WriteLine("Connection success");
                objCmdSelect = new OleDbCommand("SELECT * FROM [Input$]", con_input);
                reader = objCmdSelect.ExecuteReader();
                int _recCount = 0;
                while(reader.Read())
                {
                    Reference = reader.GetValue(0).ToString();
                    AccountNumber = reader.GetValue(1).ToString();
                    Description = reader.GetValue(2).ToString();
                    StartBalance = Convert.ToDouble(reader.GetValue(3).ToString().Trim());
                    Mutation = Convert.ToDouble(reader.GetValue(4).ToString().Trim());
                    EndBalance = Convert.ToDouble(reader.GetValue(5).ToString().Trim());
                    dc._checkvalue(Reference, Description);
                    CE.computation(Reference,StartBalance, Mutation,EndBalance);
                    _recCount++;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
