using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace GummiBear.Models
{
    [Table("Items")]
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Cost { get; set; }
        public string Description { get; set; }
        public virtual Review Review { get; set; }
    }
}
