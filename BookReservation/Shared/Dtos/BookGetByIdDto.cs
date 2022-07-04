using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservation.Shared.Dtos
{
    public class BookGetByIdDto : BaseDto
    {
        public string Name { get; set; }
        public string PublishDate { get; set; }
        public short Count { get; set; }

    }
}
