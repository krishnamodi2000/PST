﻿// <auto-generated />
using System;
using LMS.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LMS.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20220220174315_Issue")]
    partial class Issue
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LMS.Models.Books.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Author ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"), 1L, 1);

                    b.Property<string>("AuthorFName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Author First Name");

                    b.Property<string>("AuthorLName")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Author Surname");

                    b.HasKey("AuthorId");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("LMS.Models.Books.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Book ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"), 1L, 1);

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("BookAuthorID")
                        .HasColumnType("int");

                    b.Property<string>("BookTitle")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Book Title");

                    b.Property<int?>("IssueId")
                        .HasColumnType("int");

                    b.Property<int?>("PublicationId")
                        .HasColumnType("int");

                    b.HasKey("BookId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("IssueId");

                    b.HasIndex("PublicationId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("LMS.Models.Books.Issue", b =>
                {
                    b.Property<int>("IssueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Issue ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IssueId"), 1L, 1);

                    b.Property<int?>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("Book Id");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Issue Date");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Return Date");

                    b.Property<bool>("ReturnStatus")
                        .HasColumnType("bit")
                        .HasColumnName("Return Satus");

                    b.HasKey("IssueId");

                    b.HasIndex("BookId");

                    b.HasIndex("MemberId")
                        .IsUnique()
                        .HasFilter("[MemberId] IS NOT NULL");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("LMS.Models.Books.Publication", b =>
                {
                    b.Property<int>("PulicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Publication ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PulicationId"), 1L, 1);

                    b.Property<string>("PublicationName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Publication Name");

                    b.HasKey("PulicationId");

                    b.ToTable("Publication");
                });

            modelBuilder.Entity("LMS.Models.Member.MemberDesignation", b =>
                {
                    b.Property<int>("DesgnationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Designation ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DesgnationId"), 1L, 1);

                    b.Property<string>("DesgnationTitle")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Designation Title");

                    b.HasKey("DesgnationId");

                    b.ToTable("Designations");
                });

            modelBuilder.Entity("LMS.Models.Member.Members", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Member ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberId"), 1L, 1);

                    b.Property<int?>("IssueId")
                        .HasColumnType("int");

                    b.Property<int?>("MemberDesignationId")
                        .HasColumnType("int");

                    b.Property<string>("MemberFName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Member First Name");

                    b.Property<string>("MemberLName")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Member Surname");

                    b.Property<string>("MemberPhoneNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Member Phone Number");

                    b.HasKey("MemberId");

                    b.HasIndex("IssueId");

                    b.HasIndex("MemberDesignationId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("LMS.Models.Books.Book", b =>
                {
                    b.HasOne("LMS.Models.Books.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("LMS.Models.Books.Issue", "Issue")
                        .WithMany()
                        .HasForeignKey("IssueId");

                    b.HasOne("LMS.Models.Books.Publication", "Publication")
                        .WithMany()
                        .HasForeignKey("PublicationId");

                    b.Navigation("Author");

                    b.Navigation("Issue");

                    b.Navigation("Publication");
                });

            modelBuilder.Entity("LMS.Models.Books.Issue", b =>
                {
                    b.HasOne("LMS.Models.Books.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.HasOne("LMS.Models.Member.Members", "Members")
                        .WithOne()
                        .HasForeignKey("LMS.Models.Books.Issue", "MemberId");

                    b.Navigation("Book");

                    b.Navigation("Members");
                });

            modelBuilder.Entity("LMS.Models.Member.Members", b =>
                {
                    b.HasOne("LMS.Models.Books.Issue", "Issue")
                        .WithMany()
                        .HasForeignKey("IssueId");

                    b.HasOne("LMS.Models.Member.MemberDesignation", "MemberDesignation")
                        .WithMany()
                        .HasForeignKey("MemberDesignationId");

                    b.Navigation("Issue");

                    b.Navigation("MemberDesignation");
                });
#pragma warning restore 612, 618
        }
    }
}
