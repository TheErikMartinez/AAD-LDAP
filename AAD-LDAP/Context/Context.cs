using System.Diagnostics;
using System.DirectoryServices;

namespace AAD_LDAP.Context
{
    public class AdContext
    {
        DirectoryEntry ad = new DirectoryEntry("LDAP://OU=Users,OU=Hauni Hungaria,DC=HUNGARIA,DC=KOERBER,DC=DE");
       // DirectorySearcher ds = new DirectorySearcher(ad);

        public void GetAllUsers()
        {
            SearchResultCollection results;
            DirectorySearcher ds = null;

            ds = new DirectorySearcher(ad);
            ds.Filter = "(&(objectCategory=User))";

            results = ds.FindAll();

           // foreach (SearchResult sr in results)
           // {
           //     Debug.WriteLine(sr.Properties["name"][0].ToString());
           // }
        }
    }

}
