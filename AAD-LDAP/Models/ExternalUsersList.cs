using Newtonsoft.Json;

namespace AAD_LDAP.Models
{
    public class ExternalUsersList
    {
        [JsonProperty("Items")]
        public List<ExternalUser> extUsers { get; set; }
    }
}
