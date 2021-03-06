﻿// <auto-generated />
using Like.WebApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Like.WebApi.Migrations.LikeContextDbMigrations
{
    [DbContext(typeof(LikeContextDb))]
    [Migration("20210202000306_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("Like.WebApi.Models.LikeArticle", b =>
                {
                    b.Property<int>("IdLike")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdArticle")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdUser")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdLike");

                    b.ToTable("Likes");
                });
#pragma warning restore 612, 618
        }
    }
}
