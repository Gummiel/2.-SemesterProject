using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatNow.Model
{
    class Payment
    {
        public int accountNo { get; set; }

        public Payment(int accountNo)
        {
            this.accountNo = accountNo;
        }
    }
}
