using Microsoft.EntityFrameworkCore;

namespace MoodBot.Models
{
    public class SpeechContext : DbContext
    {
        public SpeechContext(DbContextOptions<SpeechContext> options)
            : base(options)
        {
        }

        public DbSet<SpeechItem> TodoItems { get; set; }
    }
}