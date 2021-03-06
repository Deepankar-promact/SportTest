﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportTest.DomainModel.DbContext;

namespace SportTest.Web.Migrations
{
    [DbContext(typeof(SportsDbContext))]
    [Migration("20190430073132_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SportTest.DomainModel.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<DateTime?>("UpdatedDateTime");

                    b.Property<int>("UserRole");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("SportTest.DomainModel.Models.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<DateTime>("TestDate");

                    b.Property<int>("TestType");

                    b.Property<DateTime?>("UpdatedDateTime");

                    b.HasKey("Id");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("SportTest.DomainModel.Models.TestDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AtheleteId");

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<double>("Distance");

                    b.Property<int>("TestId");

                    b.Property<DateTime?>("UpdatedDateTime");

                    b.HasKey("Id");

                    b.HasIndex("AtheleteId");

                    b.HasIndex("TestId");

                    b.ToTable("TestDetails");
                });

            modelBuilder.Entity("SportTest.DomainModel.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDateTime");

                    b.Property<string>("Name");

                    b.Property<int>("RoleId");

                    b.Property<DateTime?>("UpdatedDateTime");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SportTest.DomainModel.Models.TestDetail", b =>
                {
                    b.HasOne("SportTest.DomainModel.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("AtheleteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SportTest.DomainModel.Models.Test", "Test")
                        .WithMany("TestDetails")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SportTest.DomainModel.Models.User", b =>
                {
                    b.HasOne("SportTest.DomainModel.Models.Role", "UserRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
