using System;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public string _Firstname;
        private string _Lastname;

        public ContactData(string firstname)
        {
            {
                _Firstname = firstname;
                _Lastname = "";
            }
        }

        public ContactData(string firstname, string lastname)
        {
            {
                _Firstname = firstname;
                _Lastname = lastname;
            }
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            if (_Firstname == other.Firstname)
            {
                if (_Lastname == other.Lastname)
                {
                    return true;
                }
            }           

            return false;       
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode() + Lastname.GetHashCode();            
        }       

        public override string ToString()
        {
            return "firstname=" + Firstname;
           
        }        

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            if (Firstname.CompareTo(other.Firstname) == 0)
            {
                return Lastname.CompareTo(other.Lastname);
            }

            else
            {
                return Firstname.CompareTo(other.Firstname);
            }            
        }        

        public string Firstname { get; set; }                   

        public string Lastname { get; set; }

        public string Id { get;set; }
        
    }
}
