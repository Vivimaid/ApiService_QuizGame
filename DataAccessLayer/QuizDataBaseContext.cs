using System;
using System.Collections.Generic;
using FIA41_HoeffkenV_ApiService_QuizGame.Models;
using Microsoft.EntityFrameworkCore;

namespace FIA41_HoeffkenV_ApiService_QuizGame.DataAccessLayer;

public partial class QuizDataBaseContext : DbContext
{
    public QuizDataBaseContext()
    {
    }

    public QuizDataBaseContext(DbContextOptions<QuizDataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Highscore> Highscores { get; set; }

    public virtual DbSet<KpQuestionsCategoery> KpQuestionsCategoeries { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Datasource=QuizDataBase.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasOne(d => d.Question).WithMany(p => p.Answers)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Highscore>(entity =>
        {
            entity.ToTable("Highscore");
        });

        modelBuilder.Entity<KpQuestionsCategoery>(entity =>
        {
            entity.ToTable("kp_Questions_Categoeries");

            entity.HasOne(d => d.Categories).WithMany(p => p.KpQuestionsCategoeries)
                .HasForeignKey(d => d.CategoriesId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Question).WithMany(p => p.KpQuestionsCategoeries)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
