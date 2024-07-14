﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SWD_IMS.src.Infrastructure.Context;

#nullable disable

namespace SWD_IMS.Migrations
{
    [DbContext(typeof(SwdImsContext))]
    partial class SwdImsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SWD_IMS.src.Domain.Entities.Models.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AppliedAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverLetter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JobPositionId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JobPositionId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("SWD_IMS.src.Domain.Entities.Models.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("InternId")
                        .HasColumnType("int");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<int>("TrainingProgramId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("InternId");

                    b.HasIndex("TrainingProgramId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("SWD_IMS.src.Domain.Entities.Models.Intern", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Experience")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Major")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("University")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Interns");
                });

            modelBuilder.Entity("SWD_IMS.src.Domain.Entities.Models.Interview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quiz")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.ToTable("Interviews");
                });

            modelBuilder.Entity("SWD_IMS.src.Domain.Entities.Models.JobPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("JobPosition");
                });

            modelBuilder.Entity("SWD_IMS.src.Domain.Entities.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            RoleId = 2,
                            Name = "Mentor"
                        },
                        new
                        {
                            RoleId = 3,
                            Name = "Intern"
                        },
                        new
                        {
                            RoleId = 4,
                            Name = "HRManager"
                        });
                });

            modelBuilder.Entity("SWD_IMS.src.Domain.Entities.Models.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrainingProgramId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TrainingProgramId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("SWD_IMS.src.Domain.Entities.Models.TaskIntern", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("InternId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDone")
                        .HasColumnType("bit");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InternId");

                    b.HasIndex("TaskId");

                    b.ToTable("TaskInterns");
                });

            modelBuilder.Entity("SWD_IMS.src.Domain.Entities.Models.TrainingProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("MentorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("StartDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("MentorId");

                    b.ToTable("TrainingPrograms");
                });

            modelBuilder.Entity("SWD_IMS.src.Domain.Entities.Models.TrainingProgramIntern", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("InternId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Percentage")
                        .HasColumnType("float");

                    b.Property<int>("TrainingProgramId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("InternId");

                    b.HasIndex("TrainingProgramId");

                    b.ToTable("TrainingProgramInterns");
                });

            modelBuilder.Entity("SWD_IMS.src.Domain.Entities.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "SWD_IMS@gmail.com",
                            FullName = "Admin",
                            Password = "00000000",
                            Phone = "0000000000",
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("SWD_IMS.src.Domain.Entities.Models.Application", b =>
                {
                    b.HasOne("SWD_IMS.src.Domain.Entities.Models.JobPosition", "JobPosition")
                        .WithMany("Applications")
                        .HasForeignKey("JobPositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobPosition");
                });

            modelBuilder.Entity("SWD_IMS.src.Domain.Entities.Models.Feedback", b =>
                {
                    b.HasOne("SWD_IMS.src.Domain.Entities.Models.Intern", "Intern")
                        .WithMany("Feedbacks")
                        .HasForeignKey("InternId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SWD_IMS.src.Domain.Entities.Models.TrainingProgram", "TrainingProgram")
                        .WithMany("Feedbacks")
                        .HasForeignKey("TrainingProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Intern");

                    b.Navigation("TrainingProgram");
                });

            modelBuilder.Entity("SWD_IMS.src.Domain.Entities.Models.Interview", b =>
                {
                    b.HasOne("SWD_IMS.src.Domain.Entities.Models.Application", "Application")
                        .WithMany("Interviews")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");
                });

            modelBuilder.Entity("SWD_IMS.src.Domain.Entities.Models.JobPosition", b =>
                {
                    b.HasOne("SWD_IMS.src.Domain.Entities.Models.User", "HRManager")
                        .WithMany("JobPositions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HRManager");
                });

            modelBuilder.Entity("SWD_IMS.src.Domain.Entities.Models.Task", b =>
                {
                    b.HasOne("SWD_IMS.src.Domain.Entities.Models.TrainingProgram", "TrainingProgram")
                        .WithMany("Tasks")
                        .HasForeignKey("TrainingProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TrainingProgram");
                });

            modelBuilder.Entity("SWD_IMS.src.Domain.Entities.Models.TaskIntern", b =>
                {
                    b.HasOne("SWD_IMS.src.Domain.Entities.Models.Intern", "Intern")
                        .WithMany("TaskInterns")
                        .HasForeignKey("InternId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SWD_IMS.src.Domain.Entities.Models.Task", "Task")
                        .WithMany("TaskInterns")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Intern");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("SWD_IMS.src.Domain.Entities.Models.TrainingProgram", b =>
                {
                    b.HasOne("SWD_IMS.src.Domain.Entities.Models.User", "Mentor")
                        .WithMany("TrainingPrograms")
                        .HasForeignKey("MentorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mentor");
                });

            modelBuilder.Entity("SWD_IMS.src.Domain.Entities.Models.TrainingProgramIntern", b =>
                {
                    b.HasOne("SWD_IMS.src.Domain.Entities.Models.Intern", null)
                        .WithMany("TrainingProgramInterns")
                        .HasForeignKey("InternId");

                    b.HasOne("SWD_IMS.src.Domain.Entities.Models.TrainingProgram", "TrainingProgram")
                        .WithMany("TrainingProgramInterns")
                        .HasForeignKey("TrainingProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TrainingProgram");
                });

            modelBuilder.Entity("SWD_IMS.src.Domain.Entities.Models.User", b =>
                {
                    b.HasOne("SWD_IMS.src.Domain.Entities.Models.Role", "Role")
                        .WithMany("UserId")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("SWD_IMS.src.Domain.Entities.Models.Application", b =>
                {
                    b.Navigation("Interviews");
                });

            modelBuilder.Entity("SWD_IMS.src.Domain.Entities.Models.Intern", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("TaskInterns");

                    b.Navigation("TrainingProgramInterns");
                });

            modelBuilder.Entity("SWD_IMS.src.Domain.Entities.Models.JobPosition", b =>
                {
                    b.Navigation("Applications");
                });

            modelBuilder.Entity("SWD_IMS.src.Domain.Entities.Models.Role", b =>
                {
                    b.Navigation("UserId");
                });

            modelBuilder.Entity("SWD_IMS.src.Domain.Entities.Models.Task", b =>
                {
                    b.Navigation("TaskInterns");
                });

            modelBuilder.Entity("SWD_IMS.src.Domain.Entities.Models.TrainingProgram", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("Tasks");

                    b.Navigation("TrainingProgramInterns");
                });

            modelBuilder.Entity("SWD_IMS.src.Domain.Entities.Models.User", b =>
                {
                    b.Navigation("JobPositions");

                    b.Navigation("TrainingPrograms");
                });
#pragma warning restore 612, 618
        }
    }
}
