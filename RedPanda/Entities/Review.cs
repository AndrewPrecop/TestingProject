namespace RedPanda.DataAccess.Entities {
    public class Review : BaseEntity {
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}