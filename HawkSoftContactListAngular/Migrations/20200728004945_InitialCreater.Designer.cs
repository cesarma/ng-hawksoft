﻿// <auto-generated />
using HawkSoftContacts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HawkSoftContactListAngular.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200728004945_InitialCreater")]
    partial class InitialCreater
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HawkSoftDomain.ContactsHawksoft", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsersHawksoftUserId")
                        .HasColumnType("int");

                    b.Property<string>("Zip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactId");

                    b.HasIndex("UsersHawksoftUserId");

                    b.ToTable("ContactsHawksoft");

                    b.HasData(
                        new
                        {
                            ContactId = 1,
                            Address1 = "Address1",
                            Address2 = "Address2",
                            City = "Portland",
                            Email = "john.dohe@hotmail.com",
                            FirstName = "John",
                            LastName = "Dhoe",
                            State = "Oregon",
                            UsersHawksoftUserId = 1,
                            Zip = "45678"
                        },
                        new
                        {
                            ContactId = 2,
                            Address1 = "Address1",
                            Address2 = "Address2",
                            City = "Portland",
                            Email = "john.dohe@hotmail.com",
                            FirstName = "Cesar",
                            LastName = "Martinez",
                            State = "Oregon",
                            UsersHawksoftUserId = 1,
                            Zip = "45678"
                        },
                        new
                        {
                            ContactId = 3,
                            Address1 = "Address1",
                            Address2 = "Address2",
                            City = "Portland",
                            Email = "john.dohe@hotmail.com",
                            FirstName = "Oscar",
                            LastName = "De La Renta",
                            State = "Oregon",
                            UsersHawksoftUserId = 1,
                            Zip = "45678"
                        });
                });

            modelBuilder.Entity("HawkSoftDomain.UsersHawksoft", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("UsersHawksoft");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "email@email.com",
                            FirstName = "User1",
                            LastName = "LastName"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "email@email.com",
                            FirstName = "User2",
                            LastName = "LastName"
                        },
                        new
                        {
                            UserId = 3,
                            Email = "email@email.com",
                            FirstName = "User3",
                            LastName = "LastName"
                        });
                });

            modelBuilder.Entity("HawkSoftDomain.ContactsHawksoft", b =>
                {
                    b.HasOne("HawkSoftDomain.UsersHawksoft", null)
                        .WithMany("Contacts")
                        .HasForeignKey("UsersHawksoftUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}