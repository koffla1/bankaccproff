using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    public class Class1
    {
        private string Fullnameacc;
        private string Passportacc;
        private DateTime Birth;


        public Class1(string fullname, string passport, DateTime birth)
        {
            Fullnameacc = fullname;
            Passportacc = passport;
            Birth = birth;
        }

    }
}
