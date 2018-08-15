using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions; 


namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public string Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        private string allPhones;

        private string allEmails;

        public ContactData(string firstname, string lastname)
        {            
                Firstname = firstname;
                Lastname = lastname;            
        }

        public ContactData()
        {

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

            if (Firstname == other.Firstname)
            {
                if (Lastname == other.Lastname)
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

        public string AllPhones
        {
            get
            {
                if(allPhones != null)
                {
                   return allPhones;
                }
                else
                {
                    return (PhoneCleanUp(HomePhone) + PhoneCleanUp(MobilePhone) + PhoneCleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            } 
        }

        private string PhoneCleanUp(string phone)
        {
            if(phone == null || phone == "")
            {
                return "";
            }

            return Regex.Replace(phone, "[-() ]", "")  + "\r\n";
        }

        private string EmailCleanUp(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }

            return email + "\r\n";
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (EmailCleanUp(Email) + EmailCleanUp(Email2) + EmailCleanUp(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }              
    }
}
