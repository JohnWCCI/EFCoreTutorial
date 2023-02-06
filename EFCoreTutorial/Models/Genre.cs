using System.ComponentModel.DataAnnotations;

namespace EFCoreTutorial.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string GenreName { get; set; } = null!;
        public virtual ICollection<Genre> Genres { get; set; } = null!;
    }
}
