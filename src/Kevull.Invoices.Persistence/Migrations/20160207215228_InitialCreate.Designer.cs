using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Kevull.Invoices.Persistence;

namespace Kevull.Invoices.Persistence.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20160207215228_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("Kevull.Invoices.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ContactTypeId");

                    b.Property<int>("CustomerId");

                    b.Property<string>("Description");

                    b.Property<string>("Value");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Kevull.Invoices.Entities.ContactType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Kevull.Invoices.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 80);

                    b.Property<string>("FiscalIdentifier")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("PostalCode")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("Region")
                        .HasAnnotation("MaxLength", 80);

                    b.Property<bool>("SendMailing");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Kevull.Invoices.Entities.Contact", b =>
                {
                    b.HasOne("Kevull.Invoices.Entities.ContactType")
                        .WithMany()
                        .HasForeignKey("ContactTypeId");

                    b.HasOne("Kevull.Invoices.Entities.Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");
                });
        }
    }
}
