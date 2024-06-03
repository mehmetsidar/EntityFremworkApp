﻿// <auto-generated />
using System;
using EntityFremworkApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityFremworkApp.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240531113152_AddTableOgretmen")]
    partial class AddTableOgretmen
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("EntityFremworkApp.Data.Kurs", b =>
                {
                    b.Property<int>("KursId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Baslik")
                        .HasColumnType("TEXT");

                    b.Property<int?>("OgretmenId")
                        .HasColumnType("INTEGER");

                    b.HasKey("KursId");

                    b.HasIndex("OgretmenId");

                    b.ToTable("Kurslar");
                });

            modelBuilder.Entity("EntityFremworkApp.Data.KursKayit", b =>
                {
                    b.Property<int>("KayitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("KayitTarihi")
                        .HasColumnType("TEXT");

                    b.Property<int>("KursId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OgrenciId")
                        .HasColumnType("INTEGER");

                    b.HasKey("KayitId");

                    b.HasIndex("KursId");

                    b.HasIndex("OgrenciId");

                    b.ToTable("KursKayitleri");
                });

            modelBuilder.Entity("EntityFremworkApp.Data.Ogrenci", b =>
                {
                    b.Property<int>("OgrenciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Eposta")
                        .HasColumnType("TEXT");

                    b.Property<string>("OgrencSoyadi")
                        .HasColumnType("TEXT");

                    b.Property<string>("OgrenciAd")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefon")
                        .HasColumnType("TEXT");

                    b.HasKey("OgrenciId");

                    b.ToTable("Ogrenciler");
                });

            modelBuilder.Entity("EntityFremworkApp.Data.Ogretmen", b =>
                {
                    b.Property<int>("OgretmenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Ad")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BaslamaTarihi")
                        .HasColumnType("TEXT");

                    b.Property<string>("Eposta")
                        .HasColumnType("TEXT");

                    b.Property<string>("Soyad")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefon")
                        .HasColumnType("TEXT");

                    b.HasKey("OgretmenId");

                    b.ToTable("Ogretmenler");
                });

            modelBuilder.Entity("EntityFremworkApp.Data.Kurs", b =>
                {
                    b.HasOne("EntityFremworkApp.Data.Ogretmen", "Ogretmen")
                        .WithMany("Kurslar")
                        .HasForeignKey("OgretmenId");

                    b.Navigation("Ogretmen");
                });

            modelBuilder.Entity("EntityFremworkApp.Data.KursKayit", b =>
                {
                    b.HasOne("EntityFremworkApp.Data.Kurs", "Kurs")
                        .WithMany("KursKayitleri")
                        .HasForeignKey("KursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFremworkApp.Data.Ogrenci", "Ogrenci")
                        .WithMany("KursKayitleri")
                        .HasForeignKey("OgrenciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kurs");

                    b.Navigation("Ogrenci");
                });

            modelBuilder.Entity("EntityFremworkApp.Data.Kurs", b =>
                {
                    b.Navigation("KursKayitleri");
                });

            modelBuilder.Entity("EntityFremworkApp.Data.Ogrenci", b =>
                {
                    b.Navigation("KursKayitleri");
                });

            modelBuilder.Entity("EntityFremworkApp.Data.Ogretmen", b =>
                {
                    b.Navigation("Kurslar");
                });
#pragma warning restore 612, 618
        }
    }
}
