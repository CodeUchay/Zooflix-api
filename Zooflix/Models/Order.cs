using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zooflix.Models
{
    public class Order
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        [Column("ord_user_id")]
       
        public int UserId { get; set; }

        [ForeignKey("Movie")]
        [Column("ord_mov_id")]

        public int MovieId { get; set; }

        [Required]
        public DateTime? Ord_date { get; set; }

        public virtual Movie? Movie { get; set; }

    }
}