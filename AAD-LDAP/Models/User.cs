using System.ComponentModel.DataAnnotations;

namespace AAD_LDAP.Models
{
    public class User
    {
        public string name {  get; set; }
        public string sAMAccountName { get; set; }
        public string department { get; set; }
        [EmailAddress]
        public string mail { get; set; }
        public string extensionAttribute { get; set; }
        public string manager { get; set; }
    }
}
