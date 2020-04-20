//
// Copyright © 2020 Terry Moreland
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), 
// to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
// and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// 

using DevQuiz.CourseManagement.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace DevQuiz.CourseManagement.Data
{
    public class CourseContext : DbContext
    {
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<Answer> Answers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server = (localdb)\mssqllocaldb; Database = DevQuizApp; Trusted_Connection = True; ");

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("CourseManagement");

            var answerEntity = modelBuilder.Entity<Answer>();
            answerEntity.HasKey(nameof(Answer.Id));
            answerEntity
                .HasOne(a => a.Question)
                .WithMany("AnswerModels")
                .HasForeignKey(a => a.QuestionId)
                .IsRequired();

            var questionEntity = modelBuilder.Entity<Question>();
            questionEntity.HasKey(q => q.Id);
            questionEntity.HasMany<Answer>("AnswerModels");
            questionEntity.HasIndex(q => q.Content);
            questionEntity.Ignore(q => q.Answers);
            questionEntity.Property(q => q.Content).HasMaxLength(2048).IsRequired();
            questionEntity
                .HasOne(q => q.Course)
                .WithMany("QuestionModels")
                .HasForeignKey(q => q.CourseId)
                .IsRequired();

            var courseEntity = modelBuilder.Entity<Course>();
            courseEntity.HasKey(c => c.Id);
            courseEntity.HasIndex(c => c.Name);
            courseEntity.Property(c => c.Name).HasMaxLength(256).IsRequired();
            courseEntity.Ignore(c => c.Questions);
            courseEntity.HasMany<Question>("QuestionModels");

            base.OnModelCreating(modelBuilder);
        }
    }
}
