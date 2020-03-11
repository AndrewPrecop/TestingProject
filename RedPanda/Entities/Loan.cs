using System;

namespace RedPanda.DataAccess.Entities {
    public class Loan : BaseEntity {

        public DateTime LoanDate { get; set; }
        public double Tax { get; set; }
        public double DelayPenalty { get; set; }
        public Client Client { get; set; }
    }
}