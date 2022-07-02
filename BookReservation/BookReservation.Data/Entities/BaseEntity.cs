using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReservation.Data.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }   
        public DateTime? UpdateDate { get; set; }
        public int CreateBy { get; set; }
        public int? UpdateBy { get; set; }
        public bool IsActive { get; set; }
    }
}
