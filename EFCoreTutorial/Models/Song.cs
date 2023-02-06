using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreTutorial.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Artist")]
        public int ArtistId { get; set; }

        [ForeignKey("Genre")]
        public int GenreId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = null!;
        public virtual Artist Artist { get; set; } = null!;

        public virtual Genre Genre { get; set; }
    }
}
