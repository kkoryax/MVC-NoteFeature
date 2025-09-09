using Microsoft.EntityFrameworkCore;
using NoteFeature.Models.NoteModel;

namespace NoteFeature.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
    }
}
