﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ScheduleService.Infrastructure.Data;

#nullable disable

namespace ScheduleService.Infrastructure.Migrations
{
    [DbContext(typeof(ScheduleServiceDbContext))]
    partial class ScheduleServiceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ScheduleService.Domain.Entities.Schedule", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("EndAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("QuizId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("StartAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("StatusId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("ScheduleService.Domain.Entities.ScheduleDetail", b =>
                {
                    b.Property<string>("ScheduleId")
                        .HasColumnType("text");

                    b.Property<string>("ParticipantId")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ScheduleId", "ParticipantId");

                    b.ToTable("ScheduleDetails");
                });

            modelBuilder.Entity("ScheduleService.Domain.Entities.ScheduleStatus", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ScheduleStatuses");
                });

            modelBuilder.Entity("ScheduleService.Domain.Entities.Schedule", b =>
                {
                    b.HasOne("ScheduleService.Domain.Entities.ScheduleStatus", "Status")
                        .WithMany("Schedule")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("ScheduleService.Domain.ValueObjects.Schedule.MaxParticipant", "MaxParticipant", b1 =>
                        {
                            b1.Property<string>("ScheduleId")
                                .HasColumnType("text");

                            b1.Property<int>("Value")
                                .HasColumnType("integer")
                                .HasColumnName("MaxParticipant");

                            b1.HasKey("ScheduleId");

                            b1.ToTable("Schedules");

                            b1.WithOwner()
                                .HasForeignKey("ScheduleId");
                        });

                    b.Navigation("MaxParticipant")
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("ScheduleService.Domain.Entities.ScheduleDetail", b =>
                {
                    b.HasOne("ScheduleService.Domain.Entities.Schedule", "Schedule")
                        .WithMany("ScheduleDetails")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("ScheduleService.Domain.Entities.Schedule", b =>
                {
                    b.Navigation("ScheduleDetails");
                });

            modelBuilder.Entity("ScheduleService.Domain.Entities.ScheduleStatus", b =>
                {
                    b.Navigation("Schedule");
                });
#pragma warning restore 612, 618
        }
    }
}
