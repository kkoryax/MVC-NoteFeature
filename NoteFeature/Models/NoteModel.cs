using System.ComponentModel.DataAnnotations;

namespace NoteFeature.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "please give a title name")]
        [StringLength(100, ErrorMessage = "title must not exceed 100 characters")]
        [Display(Name = "title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "please give a content")]
        [StringLength(2000, ErrorMessage = "content must not exceed 2000 characters")]
        [Display(Name = "content")]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}
