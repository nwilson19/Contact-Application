using System;
using System.Collections.Generic;
using System.Linq;

namespace Nate.ContactApp
{
    public static class Search
    {
        private static string lastSearchString = string.Empty;
        private static List<Contact> lastSearch;

        public static List<Contact> Filter(List<Contact> ContactList, string parameter)
        {

            var results = new List<Contact>();

            if (parameter.Contains(lastSearchString, StringComparison.InvariantCultureIgnoreCase) && lastSearchString != string.Empty)
                if (parameter == lastSearchString)
                    results = lastSearch;
                else
                    results = searchAllFields(lastSearch, parameter);
            else
                results = searchAllFields(ContactList, parameter);

            lastSearch = results;
            lastSearchString = parameter;

            return results;
        }

        private static List<Contact> searchAllFields(List<Contact> database, string parameter)
        {
            var searchData =
            from contact in database
            where contact.IsActiveRecord && (
            contact.FirstName.Contains(parameter, StringComparison.InvariantCultureIgnoreCase) ||
            contact.LastName.Contains(parameter, StringComparison.InvariantCultureIgnoreCase) ||
            contact.Email.Address.Contains(parameter, StringComparison.InvariantCultureIgnoreCase) ||
            contact.Cell.Number.Contains(parameter, StringComparison.InvariantCultureIgnoreCase) ||
            contact.Home.Number.Contains(parameter, StringComparison.InvariantCultureIgnoreCase) ||
            contact.Work.Number.Contains(parameter, StringComparison.InvariantCultureIgnoreCase))
            select contact;

            return searchData.ToList();
        }
    }
}
