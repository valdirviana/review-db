﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReviewDB.Infra.Data;

namespace ReviewDB.Infra.Migrations
{
    [DbContext(typeof(ReviewDBContext))]
    [Migration("20180928225659_originaltitlerequired")]
    partial class originaltitlerequired
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReviewDB.Domain.Entities.MovieAggregate.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Adult");

                    b.Property<string>("Homepage")
                        .HasMaxLength(250);

                    b.Property<string>("ImdbId")
                        .HasMaxLength(12);

                    b.Property<string>("OriginalTitle")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Overview")
                        .HasMaxLength(1500);

                    b.Property<double>("Popularity");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<int>("TmdbId");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
