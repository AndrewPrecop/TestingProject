using System.Collections.Generic;

namespace RedPanda.DataAccess.Entities {
    public class Book : BaseEntity {
        public string Title { get; set; }
        public IList<Review> Reviews { get; set; }
        public IList<Loan> Loans { get; set; }
    }
}
