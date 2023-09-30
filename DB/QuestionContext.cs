using Microsoft.EntityFrameworkCore;

namespace DB
{
    /// <summary>
    /// Question Db - Code First
    /// Database Design (Code-First Approach):
    /// </summary>
    public class QuestionContext :DbContext
    {
        public QuestionContext()
        {
        }

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="options">parameters</param>
        public QuestionContext(DbContextOptions<QuestionContext> options) : base (options) 
        {
        }
        
        /// <summary>
        /// User Table
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// Question Table
        /// </summary>
        public DbSet<Question> Questions { get; set; }
        /// <summary>
        /// Answer Table
        /// </summary>
        public DbSet<Answer> Answers { get; set; }
        /// <summary>
        /// Question Tag Table
        /// </summary>
        public DbSet<QuestionTag> QuestionTags { get; set; }
        /// <summary>
        /// User Answers
        /// </summary>
        public DbSet<UserAnswer> UserAnswers { get; set; }

        /// <summary>
        /// On Model Creating - Tables Name in DB
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Question>().ToTable("Question");
            modelBuilder.Entity<Answer>().ToTable("Answer");
            modelBuilder.Entity<QuestionTag>().ToTable("QuestionTag");
            modelBuilder.Entity<UserAnswer>().ToTable("UserAnswer");
        }
    }
}