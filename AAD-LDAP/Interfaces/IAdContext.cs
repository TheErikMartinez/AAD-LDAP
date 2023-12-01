using AAD_LDAP.Models;
using System.DirectoryServices;

namespace AAD_LDAP.Interfaces
{
    public interface IAdContext
    {
        List<User> GetAllUsers();
        User GetAUser(string userName);
        User BuildUser(SearchResult sr);
    }
}
