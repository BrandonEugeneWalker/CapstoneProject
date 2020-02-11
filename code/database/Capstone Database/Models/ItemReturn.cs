using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Database.Models
{
    [Table("ItemReturn")]
    public class ItemReturn
    {
        public int itemReturnId { get; set; }
        public int memberId { get; set; }
        public int stockId { get; set; }
        public int employeeId { get; set; }

        [Required]
        [StringLength(10)]
        public string itemCondition { get; set; }

        [Required]
        [StringLength(30)]
        public string description { get; set; }
       

        public virtual Member Member { get; set; }
        public virtual Stock Stock { get; set; }
        public virtual  Employee Employee { get; set; }
    }
}
