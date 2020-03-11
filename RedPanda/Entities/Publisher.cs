using System.Collections.Generic;

namespace RedPanda.DataAccess.Entities {

    public class Publisher : BaseEntity {
        public string Name { get; set; }
        public string Code { get; set; }
        public IList<Book> Books { get; set; }
    }
}
