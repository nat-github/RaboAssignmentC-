using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabo_assignment
{
    public class Check_EndBalance
    {
        double sum;
        string _CendBalance = "End Balance is correct";
        string _WendBalance = "End Balance is incorrect";
        Output out_write = new Output();

        public void computation(string _reference, double _startBalance,double _mutation,double _endbalance)
        {
            sum = _startBalance + _mutation;
            if ( Math.Round(sum,2) ==_endbalance)
            {
                Logging.log_message("Correct End Balance");
                Logging.log_message("Reference: " + _reference);
                Logging.log_message("Start Balance: " + _startBalance);
                Logging.log_message("Mutation: " + _mutation);
                Logging.log_message("End Balance: " + _endbalance);
                out_write.XMLWrite(_reference , sum, _CendBalance);               
            }
            else
            {
                Logging.log_message("Incorrect End Balance");
                Logging.log_message("Reference: " + _reference);
                Logging.log_message("Start Balance: " + _startBalance);
                Logging.log_message("Mutation: " + _mutation);
                Logging.log_message("End Balance: " + _endbalance);
                out_write.XMLWrite(_reference, sum, _WendBalance);
            }

        }
    }
}
