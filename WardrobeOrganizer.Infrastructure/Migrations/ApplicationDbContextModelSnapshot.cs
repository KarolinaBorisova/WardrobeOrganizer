﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WardrobeOrganizer.Infrastructure.Data;

#nullable disable

namespace WardrobeOrganizer.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.HasData(
                        new
                        {
                            Id = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                            ConcurrencyStamp = "6cd9a3a6-f3af-4221-a4fa-55ab79c61574",
                            Name = "Administrator",
                            NormalizedName = "Administrator"
                        },
                        new
                        {
                            Id = "4070bb9e-78f6-4a73-b170-714f59bbc6e5",
                            ConcurrencyStamp = "c2048b8e-ad2b-4899-ac4a-d96131640252",
                            Name = "User",
                            NormalizedName = "USER"
                        });
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

                    b.HasData(
                        new
                        {
                            UserId = "0",
                            RoleId = "a18be9c0-aa65-4af8-bd17-00bd9344e575"
                        },
                        new
                        {
                            UserId = "1",
                            RoleId = "4070bb9e-78f6-4a73-b170-714f59bbc6e5"
                        },
                        new
                        {
                            UserId = "2",
                            RoleId = "4070bb9e-78f6-4a73-b170-714f59bbc6e5"
                        });
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

            modelBuilder.Entity("WardrobeOrganizer.Infrastructure.Data.Accessories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("SizeAge")
                        .HasColumnType("int");

                    b.Property<int>("StorageId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("StorageId");

                    b.ToTable("Accessories");
                });

            modelBuilder.Entity("WardrobeOrganizer.Infrastructure.Data.Clothes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

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

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("StorageId");

                    b.ToTable("Clothes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Tshirt",
                            ImagePath = "/images/1.jpg",
                            IsActive = true,
                            Name = "Тениска",
                            Size = "М",
                            StorageId = 1,
                            UserId = "1"
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

            modelBuilder.Entity("WardrobeOrganizer.Infrastructure.Data.House", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("FamilyId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.ToTable("Houses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Simeonsovkso shode 85",
                            FamilyId = 1,
                            IsActive = true,
                            Name = "Home"
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

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ShoeSizeEu")
                        .HasColumnType("int");

                    b.Property<double?>("UserHeight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("WardrobeOrganizer.Infrastructure.Data.Outerwear", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

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

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("StorageId");

                    b.ToTable("Outerwear");
                });

            modelBuilder.Entity("WardrobeOrganizer.Infrastructure.Data.Shoes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Centimetres")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("SizeEu")
                        .HasColumnType("int");

                    b.Property<int>("StorageId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("StorageId");

                    b.ToTable("Shoes");
                });

            modelBuilder.Entity("WardrobeOrganizer.Infrastructure.Data.Storage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("HouseId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("HouseId");

                    b.ToTable("Storages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HouseId = 1,
                            IsActive = true,
                            Name = "Дестки гардероб"
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

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

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
                            Id = "0",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "62ca2204-88a0-424f-a654-93807d995a26",
                            Email = "admin@abv.bg",
                            EmailConfirmed = false,
                            FirstName = "Master",
                            IsActive = true,
                            LastName = "Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ABV.BG",
                            NormalizedUserName = "ADMIN@ABV.BG",
                            PasswordHash = "AQAAAAEAACcQAAAAELL7ZZDxORUz+jd0KxlbDKfESdOtgupHg+2+MvxNVlQmhvwTLrs7pAMMVMp14wJ9Nw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "3179e719-d76d-4f8a-9803-27ee2fe38d01",
                            TwoFactorEnabled = false,
                            UserName = "admin@abv.bg"
                        },
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6cf90aba-018d-452d-a621-9c9b8643724c",
                            Email = "dani@abv.bg",
                            EmailConfirmed = false,
                            FamilyId = 1,
                            FirstName = "Yordan",
                            IsActive = true,
                            LastName = "Borisov",
                            LockoutEnabled = false,
                            NormalizedEmail = "DANI@ABV.BG",
                            NormalizedUserName = "DANI@ABV.BG",
                            PasswordHash = "AQAAAAEAACcQAAAAEKOVsFT+cUiBBCX0NRSpHFZu18Yaxw1YG4v1xMn0kGW6d14Arwzrc7bixR1IRezIlw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f35b2298-ccee-4139-8d42-4425807b749a",
                            TwoFactorEnabled = false,
                            UserName = "dani@abv.bg"
                        },
                        new
                        {
                            Id = "2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ee1ae12d-b00b-4956-b24c-b7a67ed6b32e",
                            Email = "karolina@abv.bg",
                            EmailConfirmed = false,
                            FamilyId = 2,
                            FirstName = "Karolina",
                            IsActive = true,
                            LastName = "Borisova",
                            LockoutEnabled = false,
                            NormalizedEmail = "KAROLINA@ABV.BG",
                            NormalizedUserName = "KAROLINA@ABV.BG",
                            PasswordHash = "AQAAAAEAACcQAAAAELXDhlNAWWg+etF/BeRQHUqX6iFYdiiUT1aogBnT8Mw0UU5lD7yNDgFknsUKUFn54w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d7381c98-19b7-4d9f-9423-fd3dad5290fc",
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

            modelBuilder.Entity("WardrobeOrganizer.Infrastructure.Data.Accessories", b =>
                {
                    b.HasOne("WardrobeOrganizer.Infrastructure.Data.Member", "Member")
                        .WithMany("Accessories")
                        .HasForeignKey("MemberId");

                    b.HasOne("WardrobeOrganizer.Infrastructure.Data.Storage", "Storage")
                        .WithMany("Accessories")
                        .HasForeignKey("StorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Storage");
                });

            modelBuilder.Entity("WardrobeOrganizer.Infrastructure.Data.Clothes", b =>
                {
                    b.HasOne("WardrobeOrganizer.Infrastructure.Data.Member", "Member")
                        .WithMany("Clothes")
                        .HasForeignKey("MemberId");

                    b.HasOne("WardrobeOrganizer.Infrastructure.Data.Storage", "Storage")
                        .WithMany("Clothes")
                        .HasForeignKey("StorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Storage");
                });

            modelBuilder.Entity("WardrobeOrganizer.Infrastructure.Data.House", b =>
                {
                    b.HasOne("WardrobeOrganizer.Infrastructure.Data.Family", "Family")
                        .WithMany("Houses")
                        .HasForeignKey("FamilyId");

                    b.Navigation("Family");
                });

            modelBuilder.Entity("WardrobeOrganizer.Infrastructure.Data.Member", b =>
                {
                    b.HasOne("WardrobeOrganizer.Infrastructure.Data.Family", "Family")
                        .WithMany("Members")
                        .HasForeignKey("FamilyId");

                    b.Navigation("Family");
                });

            modelBuilder.Entity("WardrobeOrganizer.Infrastructure.Data.Outerwear", b =>
                {
                    b.HasOne("WardrobeOrganizer.Infrastructure.Data.Member", "Member")
                        .WithMany("Outerwear")
                        .HasForeignKey("MemberId");

                    b.HasOne("WardrobeOrganizer.Infrastructure.Data.Storage", "Storage")
                        .WithMany("Outerwear")
                        .HasForeignKey("StorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Storage");
                });

            modelBuilder.Entity("WardrobeOrganizer.Infrastructure.Data.Shoes", b =>
                {
                    b.HasOne("WardrobeOrganizer.Infrastructure.Data.Member", "Member")
                        .WithMany("Shoes")
                        .HasForeignKey("MemberId");

                    b.HasOne("WardrobeOrganizer.Infrastructure.Data.Storage", "Storage")
                        .WithMany("Shoes")
                        .HasForeignKey("StorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Storage");
                });

            modelBuilder.Entity("WardrobeOrganizer.Infrastructure.Data.Storage", b =>
                {
                    b.HasOne("WardrobeOrganizer.Infrastructure.Data.House", "House")
                        .WithMany("Storages")
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");
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
                    b.Navigation("Houses");

                    b.Navigation("Members");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WardrobeOrganizer.Infrastructure.Data.House", b =>
                {
                    b.Navigation("Storages");
                });

            modelBuilder.Entity("WardrobeOrganizer.Infrastructure.Data.Member", b =>
                {
                    b.Navigation("Accessories");

                    b.Navigation("Clothes");

                    b.Navigation("Outerwear");

                    b.Navigation("Shoes");
                });

            modelBuilder.Entity("WardrobeOrganizer.Infrastructure.Data.Storage", b =>
                {
                    b.Navigation("Accessories");

                    b.Navigation("Clothes");

                    b.Navigation("Outerwear");

                    b.Navigation("Shoes");
                });
#pragma warning restore 612, 618
        }
    }
}
