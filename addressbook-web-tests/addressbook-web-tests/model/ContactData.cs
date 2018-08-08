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
                if(AllPhones != null)
                {
                   return AllPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                AllPhones = value;
            } 
        }

        private string CleanUp(string phone)
        {
            if(phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "")  + "\r\n";
        }

        public string AllEmails
        {
            get
            {
                if (AllEmails != null)
                {
                    return AllEmails;
                }
                else
                {
                    return ((Email + "\r\n") + (Email2 + "\r\n") + (Email3 + "\r\n")).Trim();
                }
            }
            set
            {
                AllPhones = value;
            }
        }              
    }
}
