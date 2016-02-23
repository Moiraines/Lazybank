namespace Lazybank.Web.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Lazybank.Data.Models;
    using Lazybank.Web.ViewModels;

    public class DropdownListGenerator
    {
        public static List<SelectListItem> CurrencyGenerator()
        {
            List<SelectListItem> currencies = new List<SelectListItem>();
            foreach (var currency in Enum.GetValues(typeof(CurrencyType)))
            {
                currencies.Add(
                new SelectListItem
                {
                    Value = currency.ToString(),
                    Text = currency.ToString()
                });
            }

            return currencies;
        }

        public static List<SelectListItem> CustomerNamesGenerator(ICollection<IndividualViewModel> individuals)
        {
            List<SelectListItem> customerNames = new List<SelectListItem>();
            foreach (var customer in individuals)
            {

                customerNames.Add(
                new SelectListItem
                {
                    Value = customer.Name,
                    Text = customer.Name
                });
            }

            return customerNames;
        }

        public static List<SelectListItem> AccountNumbersGenerator(ICollection<IndividualViewModel> individuals)
        {
            List<SelectListItem> accounts = new List<SelectListItem>();
            foreach (var customer in individuals)
            {
                foreach (var account in customer.Accounts)
                {
                    accounts.Add(
                        new SelectListItem
                        {
                            Value = account.Number,
                            Text = account.Number
                        });
                }
            }
            return accounts;
        }
    }
}
