using System.ComponentModel.DataAnnotations;

namespace NoteFeature.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "ชื่อเรื่อง")]
        public string Title { get; set; }
        [Display(Name = "เนื้อหา")]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
