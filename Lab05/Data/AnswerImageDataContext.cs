using Microsoft.EntityFrameworkCore;
using Lab05.Models;

namespace Lab05.Data
{
    public class AnswerImageDataContext : DbContext
    {
        public AnswerImageDataContext(DbContextOptions<AnswerImageDataContext> options) : base(options)
        {

        }
        public DbSet<AnswerImage> AnswerImages
        {
            get;
            set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnswerImage>().ToTable("AnswerImage");
        }
            
    }
}
