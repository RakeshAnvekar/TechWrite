﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechWriteServer.DbContext;

#nullable disable

namespace TechWriteServer.Migrations
{
    [DbContext(typeof(TechWriteAppDbContext))]
    [Migration("20241228072115_addedIsActiveClmToTag")]
    partial class addedIsActiveClmToTag
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TechWriteServer.Models.Blog.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BlogId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsTranding")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PublishedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BlogId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("TechWriteServer.Models.Blog.BlogComment", b =>
                {
                    b.Property<Guid>("BlogCommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BlogCommentId");

                    b.HasIndex("BlogId");

                    b.ToTable("blogComments");
                });

            modelBuilder.Entity("TechWriteServer.Models.Tag.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TagId"));

                    b.Property<int?>("BlogId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TagId");

                    b.HasIndex("BlogId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("TechWriteServer.Models.User.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserEmailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPhoneNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int");

                    b.Property<bool?>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TechWriteServer.Models.User.UserType", b =>
                {
                    b.Property<int>("UserTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserTypeId"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserTypeId");

                    b.ToTable("UserTypes");

                    b.HasData(
                        new
                        {
                            UserTypeId = 1001,
                            Type = "Admin"
                        },
                        new
                        {
                            UserTypeId = 2002,
                            Type = "User"
                        },
                        new
                        {
                            UserTypeId = 3003,
                            Type = "Visitor"
                        });
                });

            modelBuilder.Entity("TechWriteServer.Models.Blog.BlogComment", b =>
                {
                    b.HasOne("TechWriteServer.Models.Blog.Blog", null)
                        .WithMany("BlogComments")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TechWriteServer.Models.Tag.Tag", b =>
                {
                    b.HasOne("TechWriteServer.Models.Blog.Blog", null)
                        .WithMany("Tags")
                        .HasForeignKey("BlogId");
                });

            modelBuilder.Entity("TechWriteServer.Models.Blog.Blog", b =>
                {
                    b.Navigation("BlogComments");

                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
