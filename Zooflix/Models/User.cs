using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zooflix.Models
{
    [Table("User")]
    public class User
    {

        public int Id { get; set; }

        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        [Required]
        public string? Email { get; set; }

        public string? Password { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }
    }
}
