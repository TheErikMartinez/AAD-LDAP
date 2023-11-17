using System.Diagnostics;
using System.DirectoryServices;
using AAD_LDAP.Interfaces;
using AAD_LDAP.Models;

namespace AAD_LDAP.Context
{
    public class AdContext : IAdContext
    {
        DirectoryEntry ad = new DirectoryEntry("LDAP://OU=Users,OU=Hauni Hungaria,DC=HUNGARIA,DC=KOERBER,DC=DE");
       // DirectorySearcher ds = new DirectorySearcher(ad);

        //public AdContext()
        //{
        //    string str = "LDAP://OU=Users,OU=Hauni Hungaria,DC=HUNGARIA,DC=KOERBER,DC=DE";
        //    //ad = new DirectoryEntry(str);
        //    DirectoryEntry ad = new DirectoryEntry();
        //    ad.Path = str;
        //}

        public List<User> GetAllUsers()
        {
            SearchResultCollection results;
            DirectorySearcher ds = new DirectorySearcher(ad);

            //ds = new DirectorySearcher(ad);
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
                    User us = new User();

                    us.name = sr.Properties.Contains("displayName") ? sr.Properties["displayName"][0].ToString() : string.Empty;
                    us.sAMAccountName = sr.Properties.Contains("sAMAccountName") ? sr.Properties["sAMAccountName"][0].ToString() : string.Empty;
                    us.department = sr.Properties.Contains("department") ? sr.Properties["department"][0].ToString() : string.Empty;
                    us.mail = sr.Properties.Contains("mail") ? sr.Properties["mail"][0].ToString() : string.Empty;
                    us.extensionAttribute = sr.Properties.Contains("extensionattribute5") ? sr.Properties["extensionattribute5"][0].ToString() : string.Empty;
                    us.manager = sr.Properties.Contains("manager") ? sr.Properties["manager"][0].ToString() : string.Empty;

                    users.Add(us);
            }
            return users;
        }

        private void GetAUser(string userName)
        {
            DirectorySearcher ds = null;
            SearchResult sr;

            // Build User Searcher
     //       ds = BuildUserSearcher(ad);
            // Set the filter to look for a specific user
     //        ds.Filter = "(&(objectCategory=User)(objectClass=person)(name=" + userName + "))";

            sr = ds.FindOne();

            //if (sr != null)
            //{
            //    Debug.WriteLine(sr.GetPropertyValue("name"));
            //    Debug.WriteLine(sr.GetPropertyValue("mail"));
            //    Debug.WriteLine(sr.GetPropertyValue("givenname"));
            //    Debug.WriteLine(sr.GetPropertyValue("sn"));
            //    Debug.WriteLine(sr.GetPropertyValue("userPrincipalName"));
            //    Debug.WriteLine(sr.GetPropertyValue("distinguishedName"));
            //}
        }
    }

}
