﻿// <auto-generated />
using System;
using Azmon.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AzmonNew.Persistence.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20220425080812_packs")]
    partial class packs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AzmonNew.Domain.Entities.Questions.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("QuestionPacksId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("QuestionPacksId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            InsertTime = new DateTime(2022, 4, 25, 12, 38, 11, 909, DateTimeKind.Local).AddTicks(2888),
                            IsRemoved = false,
                            Name = "C#"
                        });
                });

            modelBuilder.Entity("AzmonNew.Domain.Entities.Questions.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("QuestionText")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("level")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("QuestionText")
                        .IsUnique()
                        .HasFilter("[QuestionText] IS NOT NULL");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("AzmonNew.Domain.Entities.Questions.QuestionImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Src")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionImages");
                });

            modelBuilder.Entity("AzmonNew.Domain.Entities.Questions.QuestionOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isTrue")
                        .HasColumnType("bit");

                    b.Property<string>("text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionOptions");
                });

            modelBuilder.Entity("AzmonNew.Domain.Entities.Questions.QuestionPacks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("QuestionCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("QuestionPacks");
                });

            modelBuilder.Entity("AzmonNew.Domain.Entities.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<long>("NationalCode")
                        .HasColumnType("bigint");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("QuestionQuestionPacks", b =>
                {
                    b.Property<int>("QuestionPacksId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionsId")
                        .HasColumnType("int");

                    b.HasKey("QuestionPacksId", "QuestionsId");

                    b.HasIndex("QuestionsId");

                    b.ToTable("QuestionQuestionPacks");
                });

            modelBuilder.Entity("AzmonNew.Domain.Entities.Questions.Category", b =>
                {
                    b.HasOne("AzmonNew.Domain.Entities.Questions.QuestionPacks", null)
                        .WithMany("Categories")
                        .HasForeignKey("QuestionPacksId");
                });

            modelBuilder.Entity("AzmonNew.Domain.Entities.Questions.Question", b =>
                {
                    b.HasOne("AzmonNew.Domain.Entities.Questions.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("AzmonNew.Domain.Entities.Questions.QuestionImage", b =>
                {
                    b.HasOne("AzmonNew.Domain.Entities.Questions.Question", null)
                        .WithMany("QuestionImages")
                        .HasForeignKey("QuestionId");
                });

            modelBuilder.Entity("AzmonNew.Domain.Entities.Questions.QuestionOption", b =>
                {
                    b.HasOne("AzmonNew.Domain.Entities.Questions.Question", "Question")
                        .WithMany("Options")
                        .HasForeignKey("QuestionId");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("AzmonNew.Domain.Entities.Questions.QuestionPacks", b =>
                {
                    b.HasOne("AzmonNew.Domain.Entities.Users.User", null)
                        .WithMany("Packs")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("QuestionQuestionPacks", b =>
                {
                    b.HasOne("AzmonNew.Domain.Entities.Questions.QuestionPacks", null)
                        .WithMany()
                        .HasForeignKey("QuestionPacksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AzmonNew.Domain.Entities.Questions.Question", null)
                        .WithMany()
                        .HasForeignKey("QuestionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AzmonNew.Domain.Entities.Questions.Question", b =>
                {
                    b.Navigation("Options");

                    b.Navigation("QuestionImages");
                });

            modelBuilder.Entity("AzmonNew.Domain.Entities.Questions.QuestionPacks", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("AzmonNew.Domain.Entities.Users.User", b =>
                {
                    b.Navigation("Packs");
                });
#pragma warning restore 612, 618
        }
    }
}
