using RedPanda.DataAccess.Entities;
using System.Data.Entity;

namespace RedPanda.DataAccess.Context {
    public class RedPandaContext : DbContext {
        public RedPandaContext() : base("redPandaDb") {

            Database.SetInitializer<RedPandaContext>(new RedPandaDatabaseInitializer());
        }

        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
       
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Review> Reviews { get; set; }

        //loan delete single not  coscade
    }
}
