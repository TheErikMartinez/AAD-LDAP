namespace AAD_LDAP.Models
{
    public class ExternalUser
    {
        public string UserName { get; set; }
        public string Department { get; set; }
        public int Employeeid { get; set; }
        public string Mail { get; set; }
        public bool Tiltott { get; set; }
        public string Displayname { get; set; }
    }
}
