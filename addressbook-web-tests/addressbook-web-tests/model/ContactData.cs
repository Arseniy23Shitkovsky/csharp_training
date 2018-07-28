using System;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string _firstname;
        private string _lastname;

        public ContactData(string firstname)
        {
            {
                _firstname = firstname;
                _lastname = "";
            }
        }

        public ContactData(string firstname, string lastname)
        {
            {
                _firstname = firstname;
                _lastname = lastname;
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

            if (_firstname == other.Firstname)
            {
                if (_lastname == other.Lastname)
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
            return Firstname.CompareTo(other.Firstname);
            
        }        

        public string Firstname
        {
            get
            {
                return _firstname;
            }
            set
            {
                _firstname = value;
            }
        }

        public string Lastname
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value;
            }
        }
    }
}
