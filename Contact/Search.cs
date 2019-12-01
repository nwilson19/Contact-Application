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

            if (parameter.Contains(lastSearchString) && lastSearchString != string.Empty)
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
            contact.FirstName.Contains(parameter) ||
            contact.LastName.Contains(parameter) ||
            contact.Email.Address.Contains(parameter) ||
            contact.Cell.Number.Contains(parameter) ||
            contact.Home.Number.Contains(parameter) ||
            contact.Work.Number.Contains(parameter))
            select contact;

            return searchData.ToList();
        }
    }
}
