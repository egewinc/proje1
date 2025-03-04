﻿// <auto-generated />
using Ege.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ege.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250304083820_AddAracDetayRelations")]
    partial class AddAracDetayRelations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("Ege.Models.AracDetay", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("arac_ıd")
                        .HasColumnType("INTEGER");

                    b.Property<string>("degisenParca")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("hp")
                        .HasColumnType("INTEGER");

                    b.Property<int>("koltukSay")
                        .HasColumnType("INTEGER");

                    b.Property<int>("motorH")
                        .HasColumnType("INTEGER");

                    b.Property<string>("renk")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("tork")
                        .HasColumnType("INTEGER");

                    b.Property<int>("tramerKaydı")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("arac_ıd")
                        .IsUnique();

                    b.ToTable("AracDetay");
                });

            modelBuilder.Entity("Ege.Models.Araclar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Fiyat")
                        .HasColumnType("TEXT");

                    b.Property<string>("Marka")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Yil")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Araclar");
                });

            modelBuilder.Entity("Ege.Models.Kullanicilar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Ad")
                        .HasColumnType("TEXT");

                    b.Property<int>("AracId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Yas")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AracId");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("Ege.Models.AracDetay", b =>
                {
                    b.HasOne("Ege.Models.Araclar", "Arac")
                        .WithOne("AracDetay")
                        .HasForeignKey("Ege.Models.AracDetay", "arac_ıd")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Arac");
                });

            modelBuilder.Entity("Ege.Models.Kullanicilar", b =>
                {
                    b.HasOne("Ege.Models.Araclar", "Arac")
                        .WithMany("Kullanicilar")
                        .HasForeignKey("AracId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Arac");
                });

            modelBuilder.Entity("Ege.Models.Araclar", b =>
                {
                    b.Navigation("AracDetay")
                        .IsRequired();

                    b.Navigation("Kullanicilar");
                });
#pragma warning restore 612, 618
        }
    }
}
