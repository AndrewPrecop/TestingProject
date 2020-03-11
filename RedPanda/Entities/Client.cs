using System.Collections.Generic;

namespace RedPanda.DataAccess.Entities {
    public class Client : BaseEntity {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public IList<Loan> Loans { get; set; }
        public Address Address { get; set; }
    }
}