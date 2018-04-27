using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GummiBear.Models
{
    [Table("Items")]
    public class Item
    {
        public Item()
        {
            this.Reviews = new HashSet<Review>();
        }

        [Key]
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Cost { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
