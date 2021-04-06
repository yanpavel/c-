using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebtestAddressbook
{
    public class ContactData : IEquatable <ContactData>, IComparable<ContactData>
    {
        private string allPhones;        
        private string allEmails;
        private string allInfosInProfile;

        public ContactData(string firstName)
        {
            FirstName = firstName;
        }


        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
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

            return FirstName + LastName == other.LastName + other.FirstName;
        }
        public override int GetHashCode()
        {
            return FirstName.GetHashCode() + LastName.GetHashCode();

        }

        public override string ToString()
        {
            return "name=" + FirstName + " " + LastName;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            // если firstname равно, то сравниваем lastname
            if (FirstName.CompareTo(other.FirstName) == 0)
            {
                return LastName.CompareTo(other.LastName);
            }
            return FirstName.CompareTo(other.FirstName);
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ID { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Email { get; set; }

        public string Email1 { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }
        public string AllPhones { 
            get 
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return Cleanup(HomePhone) + Cleanup(MobilePhone) + Cleanup(WorkPhone).Trim();
                }
            }
            set
            {
                allPhones = value;
            }    
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
                    return CleanupEmail(Email1) + CleanupEmail(Email2) + CleanupEmail(Email3).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }



        public string AllInfosInProfile
        {
            get
            {
                if (allInfosInProfile != null)
                {
                    return allInfosInProfile;
                }
                else
                {
                    return Cleanup(AllInfosInProfile);
                }
            }
            set
            {
                allInfosInProfile = value;
            }
        }

  
        private string Cleanup(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return phone.Replace (" ", ""). Replace("-","").Replace("(", "").Replace(")", "") + "\r\n";
        }

        private string CleanupEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }
    }

}