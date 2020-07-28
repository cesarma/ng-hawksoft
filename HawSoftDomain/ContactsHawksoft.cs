﻿using System.ComponentModel.DataAnnotations;

namespace HawkSoftDomain
{
    public class ContactsHawksoft
    {

        [Key]
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public int UsersHawksoftUserId { get; set; }
    }
}
