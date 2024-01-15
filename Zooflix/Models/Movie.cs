using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zooflix.Models
{
    [Table("Movies")]
    public class Movie
    {
        public int Id { get; set; }

        [Column("mov_name")]
        [Required]
        public string? Name { get; set; }

        [Column("mov_description")]
        [Required]
        public string? Description { get; set; }

        [Column("mov_date")]
        [Required]
        public int CreatedDate { get; set; }

        [Column("mov_cat")]
        [Required]
        public string? Category { get; set; }

        [Column("mov_rate")]
        [Required]
        public int Rate { get; set; }

        [Column("mov_price")]
        [Required]
        public int Price { get; set; }

        public virtual ICollection<Star>? Stars { get; set;}
    }
}
