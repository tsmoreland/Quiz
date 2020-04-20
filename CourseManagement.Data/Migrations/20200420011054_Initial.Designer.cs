﻿// <auto-generated />
using System;
using DevQuiz.CourseManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DevQuiz.CourseManagement.Data.Migrations
{
    [DbContext(typeof(CourseContext))]
    [Migration("20200420011054_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("CourseManagement")
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DevQuiz.CourseManagement.Domain.Model.Answer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("DevQuiz.CourseManagement.Domain.Model.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("DevQuiz.CourseManagement.Domain.Model.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(2048)")
                        .HasMaxLength(2048);

                    b.Property<Guid>("CourseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("Content");

                    b.HasIndex("CourseId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("DevQuiz.CourseManagement.Domain.Model.Answer", b =>
                {
                    b.HasOne("DevQuiz.CourseManagement.Domain.Model.Question", "Question")
                        .WithMany("AnswerModels")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DevQuiz.CourseManagement.Domain.Model.Question", b =>
                {
                    b.HasOne("DevQuiz.CourseManagement.Domain.Model.Course", "Course")
                        .WithMany("QuestionModels")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}