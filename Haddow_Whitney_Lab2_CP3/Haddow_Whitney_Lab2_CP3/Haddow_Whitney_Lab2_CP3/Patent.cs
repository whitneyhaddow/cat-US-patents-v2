using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haddow_Whitney_Lab2_CP3
{
    public class Patent
    {
        public Patent() { } //default constructor

        public Patent(int number, string appNumber, string description, DateTime filingDate, string inventor, string inventor2)
        {
            Number = number;
            AppNumber = appNumber;
            Description = description;
            FilingDate = filingDate;
            Inventor = inventor;
            Inventor2 = inventor2;
        }

        public int Number { get; set; }

        public string AppNumber { get; set; }

        public string Description { get; set; }

        public DateTime FilingDate { get; set; }

        public string Inventor { get; set; }

        public string Inventor2 { get; set; }

    } //END CLASS
}
