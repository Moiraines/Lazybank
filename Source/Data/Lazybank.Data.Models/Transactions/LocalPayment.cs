using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazybank.Data.Models
{
    public class LocalPayment : Payment
    {

        public string BeneficiaryBank { get; set; }
    }
}
