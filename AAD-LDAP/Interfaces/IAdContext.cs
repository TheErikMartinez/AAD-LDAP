using AAD_LDAP.Models;
using System.DirectoryServices;

namespace AAD_LDAP.Interfaces
{
    public interface IAdContext
    {
        List<User> GetAllUsers();
    }
}
