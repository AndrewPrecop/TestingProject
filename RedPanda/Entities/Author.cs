using System.Collections.Generic;

namespace RedPanda.DataAccess.Entities {
    public class Author: BaseEntity {
        public string Name { get; set; }
        public IList<Book> Books { get; set; }
    }
}
