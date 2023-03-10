// <auto-generated />
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
    [Migration("20230105102245_tagslistbeitrag")]
    partial class tagslistbeitrag
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

                    b.Property<int>("beitragFaceId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("beitragInstaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("beitragPintrId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("beitragFaceId");

                    b.HasIndex("beitragInstaId");

                    b.HasIndex("beitragPintrId");

                    b.ToTable("Beitrags");
                });

            modelBuilder.Entity("BeitragRdr.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
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

                    b.ToTable("Images");
                });

            modelBuilder.Entity("BeitragRdr.Models.SubModels.BeitragFace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedByUserId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.Property<int>("ImageId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedUserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.ToTable("beitragFaces");
                });

            modelBuilder.Entity("BeitragRdr.Models.SubModels.BeitragInsta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedByUserId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.Property<int>("ImageId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedUserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.ToTable("beitragInstas");
                });

            modelBuilder.Entity("BeitragRdr.Models.SubModels.BeitragPintr", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedByUserId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.Property<int>("ImageId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedUserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.ToTable("beitragPintrs");
                });

            modelBuilder.Entity("BeitragRdr.Models.Tags", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tag")
                        .IsRequired()
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

            modelBuilder.Entity("BeitragRdr.Models.Beitrag", b =>
                {
                    b.HasOne("BeitragRdr.Models.SubModels.BeitragFace", "beitragFace")
                        .WithMany()
                        .HasForeignKey("beitragFaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeitragRdr.Models.SubModels.BeitragInsta", "beitragInsta")
                        .WithMany()
                        .HasForeignKey("beitragInstaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeitragRdr.Models.SubModels.BeitragPintr", "beitragPintr")
                        .WithMany()
                        .HasForeignKey("beitragPintrId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("beitragFace");

                    b.Navigation("beitragInsta");

                    b.Navigation("beitragPintr");
                });

            modelBuilder.Entity("BeitragRdr.Models.SubModels.BeitragFace", b =>
                {
                    b.HasOne("BeitragRdr.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");
                });

            modelBuilder.Entity("BeitragRdr.Models.SubModels.BeitragInsta", b =>
                {
                    b.HasOne("BeitragRdr.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");
                });

            modelBuilder.Entity("BeitragRdr.Models.SubModels.BeitragPintr", b =>
                {
                    b.HasOne("BeitragRdr.Models.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");
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
#pragma warning restore 612, 618
        }
    }
}
