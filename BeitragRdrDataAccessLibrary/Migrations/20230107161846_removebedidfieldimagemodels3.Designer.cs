﻿// <auto-generated />
using System;
using BeitragRdrDataAccessLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BeitragRdrDataAccessLibrary.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230107161846_removebedidfieldimagemodels3")]
    partial class removebedidfieldimagemodels3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("BeitragRdr.Models.Beitrag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Beitrags");
                });

            modelBuilder.Entity("BeitragRdr.Models.ImageModels.ImageModelFacebook", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("base64data")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ImageModelFacebook");
                });

            modelBuilder.Entity("BeitragRdr.Models.ImageModels.ImageModelInstagram", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("base64data")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ImageModelInstagram");
                });

            modelBuilder.Entity("BeitragRdr.Models.ImageModels.ImageModelPintr", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("base64data")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ImageModelPintr");
                });

            modelBuilder.Entity("BeitragRdr.Models.SubModels.BeitragFace", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedByUserId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedUserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("beitragFaces");
                });

            modelBuilder.Entity("BeitragRdr.Models.SubModels.BeitragInsta", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedByUserId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedUserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("beitragInstas");
                });

            modelBuilder.Entity("BeitragRdr.Models.SubModels.BeitragPintr", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedByUserId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedUserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("beitragPintrs");
                });

            modelBuilder.Entity("BeitragRdr.Models.Tags", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("BeitragTags", b =>
                {
                    b.Property<int>("BeitragsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("tagsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BeitragsId", "tagsId");

                    b.HasIndex("tagsId");

                    b.ToTable("BeitragTags");
                });

            modelBuilder.Entity("BeitragRdr.Models.ImageModels.ImageModelFacebook", b =>
                {
                    b.HasOne("BeitragRdr.Models.SubModels.BeitragFace", "BeitragFace")
                        .WithOne("Image")
                        .HasForeignKey("BeitragRdr.Models.ImageModels.ImageModelFacebook", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BeitragFace");
                });

            modelBuilder.Entity("BeitragRdr.Models.ImageModels.ImageModelInstagram", b =>
                {
                    b.HasOne("BeitragRdr.Models.SubModels.BeitragInsta", "BeitragInsta")
                        .WithOne("Image")
                        .HasForeignKey("BeitragRdr.Models.ImageModels.ImageModelInstagram", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BeitragInsta");
                });

            modelBuilder.Entity("BeitragRdr.Models.ImageModels.ImageModelPintr", b =>
                {
                    b.HasOne("BeitragRdr.Models.SubModels.BeitragPintr", "BeitragPintr")
                        .WithOne("Image")
                        .HasForeignKey("BeitragRdr.Models.ImageModels.ImageModelPintr", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BeitragPintr");
                });

            modelBuilder.Entity("BeitragRdr.Models.SubModels.BeitragFace", b =>
                {
                    b.HasOne("BeitragRdr.Models.Beitrag", "Beitrag")
                        .WithOne("beitragFace")
                        .HasForeignKey("BeitragRdr.Models.SubModels.BeitragFace", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Beitrag");
                });

            modelBuilder.Entity("BeitragRdr.Models.SubModels.BeitragInsta", b =>
                {
                    b.HasOne("BeitragRdr.Models.Beitrag", "Beitrag")
                        .WithOne("beitragInsta")
                        .HasForeignKey("BeitragRdr.Models.SubModels.BeitragInsta", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Beitrag");
                });

            modelBuilder.Entity("BeitragRdr.Models.SubModels.BeitragPintr", b =>
                {
                    b.HasOne("BeitragRdr.Models.Beitrag", "Beitrag")
                        .WithOne("beitragPintr")
                        .HasForeignKey("BeitragRdr.Models.SubModels.BeitragPintr", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Beitrag");
                });

            modelBuilder.Entity("BeitragTags", b =>
                {
                    b.HasOne("BeitragRdr.Models.Beitrag", null)
                        .WithMany()
                        .HasForeignKey("BeitragsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeitragRdr.Models.Tags", null)
                        .WithMany()
                        .HasForeignKey("tagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BeitragRdr.Models.Beitrag", b =>
                {
                    b.Navigation("beitragFace")
                        .IsRequired();

                    b.Navigation("beitragInsta")
                        .IsRequired();

                    b.Navigation("beitragPintr")
                        .IsRequired();
                });

            modelBuilder.Entity("BeitragRdr.Models.SubModels.BeitragFace", b =>
                {
                    b.Navigation("Image");
                });

            modelBuilder.Entity("BeitragRdr.Models.SubModels.BeitragInsta", b =>
                {
                    b.Navigation("Image");
                });

            modelBuilder.Entity("BeitragRdr.Models.SubModels.BeitragPintr", b =>
                {
                    b.Navigation("Image");
                });
#pragma warning restore 612, 618
        }
    }
}
