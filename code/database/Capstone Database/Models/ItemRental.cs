using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Database.Models
{
    [Table("ItemRental")]
    public class ItemRental
    {
        public int itemRentalId { get; set; }
        public int stockId { get; set; }
        public int memberId { get; set; }

        [Required]
        [StringLength(30)]
        public string status { get; set; }


        public virtual Member Member { get; set; }
        public virtual Stock Stock { get; set; }
    }
}
