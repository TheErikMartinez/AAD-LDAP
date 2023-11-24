using System.Diagnostics;
using System.DirectoryServices;
using AAD_LDAP.Interfaces;
using AAD_LDAP.Models;

namespace AAD_LDAP.Context
{
    public class AdContext : IAdContext
    {
        DirectoryEntry ad = new DirectoryEntry("LDAP://OU=Users,OU=Hauni Hungaria,DC=HUNGARIA,DC=KOERBER,DC=DE");

        public List<User> GetAllUsers()
        {
            SearchResultCollection results;
            DirectorySearcher ds = new DirectorySearcher(ad);

            ds.Filter = "(&(objectCategory=User))";

            ds.PropertiesToLoad.Add("displayName");
            ds.PropertiesToLoad.Add("sAMAccountName");
            ds.PropertiesToLoad.Add("department");
            ds.PropertiesToLoad.Add("mail");
            ds.PropertiesToLoad.Add("extensionAttribute5");
            ds.PropertiesToLoad.Add("manager");

            results = ds.FindAll();

            List<User> users = new List<User>();
            

            foreach (SearchResult sr in results)
            {
                    users.Add(BuildUser(sr));
            }
            return users;
        }

        public User GetAUser(string userName)
        {
            DirectorySearcher ds = new DirectorySearcher(ad);
            SearchResult sr;

            ds.Filter = "(&(objectCategory=User)(sAMAccountName=" + userName + "))";

            sr = ds.FindOne();

            return BuildUser(sr);
        }

        public User BuildUser(SearchResult sr)
        {
            User us = new User();

            us.name = sr.Properties.Contains("displayName") ? sr.Properties["displayName"][0].ToString() : string.Empty;
            us.sAMAccountName = sr.Properties.Contains("sAMAccountName") ? sr.Properties["sAMAccountName"][0].ToString() : string.Empty;
            us.department = sr.Properties.Contains("department") ? sr.Properties["department"][0].ToString() : string.Empty;
            us.mail = sr.Properties.Contains("mail") ? sr.Properties["mail"][0].ToString() : string.Empty;
            us.extensionAttribute = sr.Properties.Contains("extensionattribute5") ? sr.Properties["extensionattribute5"][0].ToString() : string.Empty;
            us.manager = sr.Properties.Contains("manager") ? sr.Properties["manager"][0].ToString() : string.Empty;

            return us;
        }
    }

}
