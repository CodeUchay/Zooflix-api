using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zooflix.Models
{
    [Table("Stars")]

    public class Star
    {
        public int Id { get; set; }

        [ForeignKey("Movie")]
        [Column("star_mov_id")]
        public int MovieId { get; set; }

        [Column("star_first_name")]
        [Required]
        public string? Firstname { get; set; }

        [Column("star_last_name")]
        [Required]
        public string? Lastname { get; set; }

       // public  ICollection<Movie>? Movie { get; set; }

    }
}
