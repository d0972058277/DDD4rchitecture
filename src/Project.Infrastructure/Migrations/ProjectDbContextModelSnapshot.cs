﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.Infrastructure;

#nullable disable

namespace Project.Infrastructure.Migrations
{
    [DbContext(typeof(ProjectDbContext))]
    partial class ProjectDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Architecture.Domain.EventBus.Inbox.IntegrationEventEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreationTimestamp")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("State")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)")
                        .HasDefaultValue("Received");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Inbox", (string)null);
                });

            modelBuilder.Entity("Architecture.Domain.EventBus.Outbox.IntegrationEventEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreationTimestamp")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("State")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)")
                        .HasDefaultValue("Raised");

                    b.Property<Guid>("TransactionId")
                        .HasColumnType("char(36)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("TransactionId");

                    b.ToTable("Outbox", (string)null);
                });

            modelBuilder.Entity("Project.Domain.SomethingContext.Models.SomethingAggregate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("SomethingAggregate", (string)null);
                });

            modelBuilder.Entity("Project.Domain.SomethingContext.Models.SomethingAggregate", b =>
                {
                    b.OwnsOne("Project.Domain.SomethingContext.Models.SomethingEntity", "Entity", b1 =>
                        {
                            b1.Property<Guid>("SomethingAggregateId")
                                .HasColumnType("char(36)");

                            b1.Property<Guid>("Id")
                                .HasColumnType("char(36)")
                                .HasColumnName("EntityId");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("longtext")
                                .HasColumnName("EntityName");

                            b1.HasKey("SomethingAggregateId");

                            b1.ToTable("SomethingAggregate");

                            b1.WithOwner()
                                .HasForeignKey("SomethingAggregateId");
                        });

                    b.OwnsMany("Project.Domain.SomethingContext.Models.SomethingValueObject", "ValueObjects", b1 =>
                        {
                            b1.Property<long>("_id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint");

                            b1.Property<bool>("Boolean")
                                .HasColumnType("tinyint(1)");

                            b1.Property<DateTime>("DateTime")
                                .HasColumnType("datetime(6)");

                            b1.Property<int>("Number")
                                .HasColumnType("int");

                            b1.Property<Guid>("SomethingAggregateId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("String")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("_id");

                            b1.HasIndex("SomethingAggregateId");

                            b1.ToTable("SomethingAggregate_ValueObject", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("SomethingAggregateId");
                        });

                    b.Navigation("Entity")
                        .IsRequired();

                    b.Navigation("ValueObjects");
                });
#pragma warning restore 612, 618
        }
    }
}
