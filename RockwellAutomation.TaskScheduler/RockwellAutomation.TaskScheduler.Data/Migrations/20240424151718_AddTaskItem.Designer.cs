﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RockwellAutomation.TaskScheduler.Data;

#nullable disable

namespace RockwellAutomation.TaskScheduler.Data.Migrations
{
    [DbContext(typeof(RockwellTaskSchedulerDbContext))]
    [Migration("20240424151718_AddTaskItem")]
    partial class AddTaskItem
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RockwellAutomation.TaskScheduler.Data.Entity.ExecutionTaskItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Headers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaskItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TaskItemId");

                    b.ToTable("ExecutionTaskItem", (string)null);
                });

            modelBuilder.Entity("RockwellAutomation.TaskScheduler.Data.Entity.TaskItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CronExpression")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("WebUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TaskItem", (string)null);
                });

            modelBuilder.Entity("RockwellAutomation.TaskScheduler.Data.Entity.ExecutionTaskItem", b =>
                {
                    b.HasOne("RockwellAutomation.TaskScheduler.Data.Entity.TaskItem", "TaskItem")
                        .WithMany()
                        .HasForeignKey("TaskItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TaskItem");
                });
#pragma warning restore 612, 618
        }
    }
}
