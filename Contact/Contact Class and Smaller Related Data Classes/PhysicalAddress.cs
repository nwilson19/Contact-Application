using System;
using System.Collections.Generic;
using System.Text;

namespace Nate.ContactApp
{
    public class PhysicalAddress
    {
        private string line1;
        private string line2;
        private string city;
        private string state;
        private string postalCode;

        public string Line1
        {
            get => line1;
            set => line1 = value;
        }

        public string Line2
        {
            get => line2;
            set => line2 = value;
        }

        public string City
        {
            get => city;
            set => city = value;
        }

        public string State
        {
            get => state;
            set => state = value;
        }

        public string PostalCode
        {
            get => postalCode;
            set => postalCode = value;
        }

        public PhysicalAddress()
        {
            line1 = null;
            line2 = null;
            city = null;
            state = null;
            postalCode = null;
        }

    }
}
