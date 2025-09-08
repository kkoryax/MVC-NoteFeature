using System.ComponentModel.DataAnnotations;

namespace NoteFeature.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "กรุณาใส่ชื่อเรื่อง")]
        [StringLength(100, ErrorMessage = "ชื่อเรื่องต้องไม่เกิน 100 ตัวอักษร")]
        [Display(Name = "ชื่อเรื่อง")]
        public string Title { get; set; }
        [Required(ErrorMessage = "กรุณาใส่เนื้อหา")]
        [StringLength(2000, ErrorMessage = "เนื้อหาต้องไม่เกิน 2000 ตัวอักษร")]
        [Display(Name = "เนื้อหา")]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
    }
}
