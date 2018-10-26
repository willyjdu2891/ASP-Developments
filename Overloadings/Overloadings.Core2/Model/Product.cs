using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using System.Threading.Tasks;

namespace Overloadings.Core.Model
{
    public class Product
    {
        public string ID { get; set; }
        [StringLength(20)]
        [DisplayName("Product name")]
        [MaxLength(50)]
        [MinLength(4)]
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public float Price { get; set; }

        public Product(){

            this.ID = Guid.NewGuid().ToString();
        }

    }
}
