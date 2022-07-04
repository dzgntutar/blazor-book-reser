using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservation.Shared.Dtos
{
    public class BookGetAllDto : BaseDto
    {
        public string Name { get; set; }
        public string PublishDate { get; set; }
        public int Type { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public short Count { get; set; }
    }
}
