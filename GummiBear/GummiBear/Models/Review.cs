using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GummiBear.Models
{
    [Table("Reviews")]
    public class Review
    {
        public Review()
        {
            this.Items = new HashSet<Item>();
        }

        [Key]
        public int ReviewId { get; set; }
        public string Author { get; set; }
        public string content { get; set; }
        public string rating { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}