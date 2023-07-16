﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using test2;

#nullable disable

namespace test2.Migrations
{
    [DbContext(typeof(DatabaseDataContex))]
    [Migration("20230404080425_third4")]
    partial class third4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0-preview.2.23128.3");

            modelBuilder.Entity("ModuleStudent", b =>
                {
                    b.Property<int>("ModulestudentsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentModulesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ModulestudentsId", "StudentModulesId");

                    b.HasIndex("StudentModulesId");

                    b.ToTable("ModuleStudent");
                });

            modelBuilder.Entity("test2.Models.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Code")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Credit")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Dbmodules");
                });

            modelBuilder.Entity("test2.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RegNo")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Dbstudnets");
                });

            modelBuilder.Entity("test2.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Dbusers");
                });

            modelBuilder.Entity("ModuleStudent", b =>
                {
                    b.HasOne("test2.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("ModulestudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("test2.Models.Module", null)
                        .WithMany()
                        .HasForeignKey("StudentModulesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}