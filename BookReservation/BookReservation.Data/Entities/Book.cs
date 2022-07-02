using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservation.Data.Entities
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public string PublishDate { get; set; }
        public int Type { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public short Count { get; set; }

        public ICollection<User> Users { get; set; }
        public List<ReservedBook> ReservedBooks { get; set; }
    }
}
