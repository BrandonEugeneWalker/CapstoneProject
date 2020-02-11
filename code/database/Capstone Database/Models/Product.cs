using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Database.Models
{
    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Stocks = new HashSet<Stock>();
        }
        public int productId { get; set; }

        [Required]
        [StringLength(30)]
        public string name { get; set; }

        [Required]
        [StringLength(300)]
        public string description { get; set; }

        [Required]
        [StringLength(30)]
        public string type { get; set; }

        [Required]
        [StringLength(30)]
        public string category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
