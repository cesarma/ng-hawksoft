using HawkSoftDomain;
using Microsoft.EntityFrameworkCore;

namespace HawkSoftContacts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<UsersHawksoft> User { get; set; }
        public DbSet<ContactsHawksoft> Contact { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersHawksoft>().ToTable("UsersHawksoft");
            modelBuilder.Entity<ContactsHawksoft>().ToTable("ContactsHawksoft");
            modelBuilder.Entity<HawkSoftDomain.UsersHawksoft>().HasData(
         new HawkSoftDomain.UsersHawksoft { UserId = 1, FirstName = "User1", LastName = "LastName", Email = "email@email.com" },
         new HawkSoftDomain.UsersHawksoft { UserId = 2, FirstName = "User2", LastName = "LastName", Email = "email@email.com" },
         new HawkSoftDomain.UsersHawksoft { UserId = 3, FirstName = "User3", LastName = "LastName", Email = "email@email.com" }
);

            modelBuilder.Entity<HawkSoftDomain.ContactsHawksoft>().HasData(
     new HawkSoftDomain.ContactsHawksoft { ContactId=1, Zip = "45678",FirstName = "John", LastName = "Dhoe", City = "Portland", State = "Oregon", Address1 = "Address1", Address2 = "Address2", Email = "john.dohe@hotmail.com", UsersHawksoftUserId = 1 },
     new HawkSoftDomain.ContactsHawksoft { ContactId =2, Zip = "45678",FirstName = "Cesar", LastName = "Martinez", City = "Portland", State = "Oregon", Address1 = "Address1", Address2 = "Address2", Email = "john.dohe@hotmail.com", UsersHawksoftUserId = 1 },
     new HawkSoftDomain.ContactsHawksoft { ContactId =3, Zip="45678",FirstName = "Oscar", LastName = "De La Renta", City = "Portland", State = "Oregon", Address1 = "Address1", Address2 = "Address2", Email = "john.dohe@hotmail.com", UsersHawksoftUserId = 1 }
 );

        }
    }
}   
