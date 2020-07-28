using System.Collections.Generic;

namespace HawkSoftDomain
{
    public class UsersHawksoft
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<ContactsHawksoft> Contacts { get; set; }
    }
}
