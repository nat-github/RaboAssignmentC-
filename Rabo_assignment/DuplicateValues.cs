using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabo_assignment
{
    public class DuplicateValues
    {
        List<string> listxl = new List<string>();
        Output out_put = new Output();
        public void _checkvalue(string _reference,string _description)
        {            
            if (listxl.Contains(_reference))
            {
                Logging.log_message("Duplicate value: " + _reference);
                Logging.log_message("Description: " + _description);
                out_put.DuplicateXML(_reference, _description);
            }
            else
            {
                listxl.Add(_reference);
                Logging.log_message("value: " + _reference);
                Logging.log_message("Description: " + _description);
            }
        }
    }
}
