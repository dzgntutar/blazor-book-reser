using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservation.Data.Entities
{
    public class ReservedBook : BaseEntity
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime ReservedDate{ get; set; }
        public DateTime ReservedFinishDate{ get; set; }

        public  Book Book { get; set; }
        public  User User { get; set; }

    }
}
