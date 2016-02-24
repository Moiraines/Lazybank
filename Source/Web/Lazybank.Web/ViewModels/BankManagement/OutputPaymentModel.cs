using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lazybank.Web.ViewModels
{
    public class OutputPaymentModel
    {
        public UserForPaymentsViewModel User { get; set; }

        public TransferPaymentInputViewModel TransferPayment { get; set; }
    }
}