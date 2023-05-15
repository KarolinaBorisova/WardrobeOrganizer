﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WardrobeOrganizer.Infrastructure.Data;

#nullable disable

namespace WardrobeOrganizer.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230515122207_memberURl")]
    partial class memberURl
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("WardrobeOrganizer.Infrastructure.Data.Clothing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryClothing")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int?>("SizeHeight")
                        .HasColumnType("int");

                    b.Property<int>("StorageId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StorageId");

                    b.ToTable("Clothes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryClothing = 0,
                            Name = "Тениска",
                            Size = "М",
                            StorageId = 1,
                            Url = "http://unblast.com/wp-content/uploads/2019/04/Kids-T-Shirt-Mockup-1.jpg"
                        });
                });

            modelBuilder.Entity("WardrobeOrganizer.Infrastructure.Data.Family", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Families");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Borisovi",
                            UserId = "1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Popovi",
                            UserId = "2"
                        });
                });

            modelBuilder.Entity("WardrobeOrganizer.Infrastructure.Data.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ClothesSize")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int?>("FamilyId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double?>("FootLengthCm")
                        .HasColumnType("float");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ShoeSizeEu")
                        .HasColumnType("int");

                    b.Property<int?>("StorageId")
                        .HasColumnType("int");

                    b.Property<double?>("UserHeight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.HasIndex("StorageId")
                        .IsUnique()
                        .HasFilter("[StorageId] IS NOT NULL");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("WardrobeOrganizer.Infrastructure.Data.Outerwear", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryOuterwear")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int?>("SizeHeight")
                        .HasColumnType("int");

                    b.Property<int>("StorageId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StorageId");

                    b.ToTable("Outerwear");
                });

            modelBuilder.Entity("WardrobeOrganizer.Infrastructure.Data.Shoes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryShoes")
                        .HasColumnType("int");

                    b.Property<int>("Centimetres")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("SizeEu")
                        .HasColumnType("int");

                    b.Property<int>("StorageId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StorageId");

                    b.ToTable("Shoes");
                });

            modelBuilder.Entity("WardrobeOrganizer.Infrastructure.Data.Storage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("FamilyId")
                        .HasColumnType("int");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.ToTable("Storages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Дестки гардероб",
                            Place = "В детската стая"
                        });
                });

            modelBuilder.Entity("WardrobeOrganizer.Infrastructure.Data.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("FamilyId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("FamilyId")
                        .IsUnique()
                        .HasFilter("[FamilyId] IS NOT NULL");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "08b47f54-f9f7-48e4-97e1-5871d0f06859",
                            Email = "dani@abv.bg",
                            EmailConfirmed = false,
                            FirstName = "Yordan",
                            LastName = "Borisov",
                            LockoutEnabled = false,
                            NormalizedEmail = "DANI@ABV.BG",
                            NormalizedUserName = "DANI@ABV.BG",
                            PasswordHash = "AQAAAAEAACcQAAAAEOe73w8UL8gb13fDBedWuGmS+BE7c3Ut72BaaEefEyqgNIGsvFYOLqDUxOxJ94o+Vw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "52b0d7a1-51ef-4e38-9249-60de6a277848",
                            TwoFactorEnabled = false,
                            UserName = "dani@abv.bg"
                        },
                        new
                        {
                            Id = "2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c46b2776-0194-4d6b-9050-8460c427f189",
                            Email = "karolina@abv.bg",
                            EmailConfirmed = false,
                            FirstName = "Karolina",
                            LastName = "Borisova",
                            LockoutEnabled = false,
                            NormalizedEmail = "KAROLINA@ABV.BG",
                            NormalizedUserName = "KAROLINA@ABV.BG",
                            PasswordHash = "AQAAAAEAACcQAAAAEJerqDQE6Jo+4I7c6ZC+saaVFaXpNUsiFTbflajqRbEBt134TN0aKAIykB9Q9UslWw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "65973fe1-2467-4169-9b73-5047beccf40d",
                            TwoFactorEnabled = false,
                            UserName = "karolina@abv.bg"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WardrobeOrganizer.Infrastructure.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WardrobeOrganizer.Infrastructure.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WardrobeOrganizer.Infrastructure.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WardrobeOrganizer.Infrastructure.Data.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WardrobeOrganizer.Infrastructure.Data.Clothing", b =>
                {
                    b.HasOne("WardrobeOrganizer.Infrastructure.Data.Storage", "Storage")
                        .WithMany("Clothes")
                        .HasForeignKey("StorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Storage");
                });

            modelBuilder.Entity("WardrobeOrganizer.Infrastructure.Data.Member", b =>
                {
                    b.HasOne("WardrobeOrganizer.Infrastructure.Data.Family", "Family")
                        .WithMany("Members")
                        .HasForeignKey("FamilyId");

                    b.HasOne("WardrobeOrganizer.Infrastructure.Data.Storage", "Storage")
                        .WithOne("Member")
                        .HasForeignKey("WardrobeOrganizer.Infrastructure.Data.Member", "StorageId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Family");

                    b.Navigation("Storage");
                });

            modelBuilder.Entity("WardrobeOrganizer.Infrastructure.Data.Outerwear", b =>
                {
                    b.HasOne("WardrobeOrganizer.Infrastructure.Data.Storage", "Storage")
                        .WithMany("Outerwear")
                        .HasForeignKey("StorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Storage");
                });

            modelBuilder.Entity("WardrobeOrganizer.Infrastructure.Data.Shoes", b =>
                {
                    b.HasOne("WardrobeOrganizer.Infrastructure.Data.Storage", "Storage")
                        .WithMany("Shoes")
                        .HasForeignKey("StorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Storage");
                });

            modelBuilder.Entity("WardrobeOrganizer.Infrastructure.Data.Storage", b =>
                {
                    b.HasOne("WardrobeOrganizer.Infrastructure.Data.Family", "Family")
                        .WithMany("Storages")
                        .HasForeignKey("FamilyId");

                    b.Navigation("Family");
                });

            modelBuilder.Entity("WardrobeOrganizer.Infrastructure.Data.User", b =>
                {
                    b.HasOne("WardrobeOrganizer.Infrastructure.Data.Family", "Family")
                        .WithOne("User")
                        .HasForeignKey("WardrobeOrganizer.Infrastructure.Data.User", "FamilyId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Family");
                });

            modelBuilder.Entity("WardrobeOrganizer.Infrastructure.Data.Family", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("Storages");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WardrobeOrganizer.Infrastructure.Data.Storage", b =>
                {
                    b.Navigation("Clothes");

                    b.Navigation("Member");

                    b.Navigation("Outerwear");

                    b.Navigation("Shoes");
                });
#pragma warning restore 612, 618
        }
    }
}
