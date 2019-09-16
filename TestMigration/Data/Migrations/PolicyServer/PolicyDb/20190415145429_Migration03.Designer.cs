﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PolicyServer1.EntityFramework.Storage.Datas;

namespace TestMigration.Data.Migrations.PolicyServer.PolicyDb
{
    [DbContext(typeof(PolicyDbContext))]
    [Migration("20190415145429_Migration03")]
    partial class Migration03
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PolicyServer1.EntityFramework.Storage.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("ClientName")
                        .HasMaxLength(200);

                    b.Property<string>("ClientUri");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<bool>("Enabled");

                    b.Property<DateTime?>("LastAccessed");

                    b.Property<int?>("PolicyId");

                    b.Property<DateTime?>("Updated");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.HasIndex("PolicyId")
                        .IsUnique()
                        .HasFilter("[PolicyId] IS NOT NULL");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("PolicyServer1.EntityFramework.Storage.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime?>("LastAccessed");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("PolicyId");

                    b.Property<DateTime?>("Updated");

                    b.HasKey("Id");

                    b.HasIndex("PolicyId", "Name")
                        .IsUnique();

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("PolicyServer1.EntityFramework.Storage.Entities.Policy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<string>("Hash");

                    b.Property<DateTime?>("LastAccessed");

                    b.Property<DateTime>("LastPolicyChangeDate");

                    b.Property<DateTime?>("Updated");

                    b.HasKey("Id");

                    b.ToTable("Policy");
                });

            modelBuilder.Entity("PolicyServer1.EntityFramework.Storage.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("LastAccessed");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("PolicyId");

                    b.Property<DateTime?>("Updated");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("PolicyId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("PolicyServer1.EntityFramework.Storage.Entities.RoleIdentity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Identity")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleIdentity");
                });

            modelBuilder.Entity("PolicyServer1.EntityFramework.Storage.Entities.RolePermission", b =>
                {
                    b.Property<int>("RoleId");

                    b.Property<int>("PermissionId");

                    b.Property<bool>("IsRevoked");

                    b.HasKey("RoleId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId", "PermissionId")
                        .IsUnique();

                    b.ToTable("RolePermission");
                });

            modelBuilder.Entity("PolicyServer1.EntityFramework.Storage.Entities.RoleRole", b =>
                {
                    b.Property<int>("RoleId");

                    b.Property<int>("ParentId");

                    b.HasKey("RoleId", "ParentId");

                    b.HasIndex("ParentId");

                    b.HasIndex("RoleId", "ParentId")
                        .IsUnique();

                    b.ToTable("RoleRole");
                });

            modelBuilder.Entity("PolicyServer1.EntityFramework.Storage.Entities.RoleSubject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleId");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleSubject");
                });

            modelBuilder.Entity("PolicyServer1.EntityFramework.Storage.Entities.Client", b =>
                {
                    b.HasOne("PolicyServer1.EntityFramework.Storage.Entities.Policy", "Policy")
                        .WithOne()
                        .HasForeignKey("PolicyServer1.EntityFramework.Storage.Entities.Client", "PolicyId");
                });

            modelBuilder.Entity("PolicyServer1.EntityFramework.Storage.Entities.Permission", b =>
                {
                    b.HasOne("PolicyServer1.EntityFramework.Storage.Entities.Policy", "Policy")
                        .WithMany("Permissions")
                        .HasForeignKey("PolicyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PolicyServer1.EntityFramework.Storage.Entities.Role", b =>
                {
                    b.HasOne("PolicyServer1.EntityFramework.Storage.Entities.Policy", "Policy")
                        .WithMany("Roles")
                        .HasForeignKey("PolicyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PolicyServer1.EntityFramework.Storage.Entities.RoleIdentity", b =>
                {
                    b.HasOne("PolicyServer1.EntityFramework.Storage.Entities.Role", "Role")
                        .WithMany("IdentityRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PolicyServer1.EntityFramework.Storage.Entities.RolePermission", b =>
                {
                    b.HasOne("PolicyServer1.EntityFramework.Storage.Entities.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PolicyServer1.EntityFramework.Storage.Entities.Role", "Role")
                        .WithMany("Permissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PolicyServer1.EntityFramework.Storage.Entities.RoleRole", b =>
                {
                    b.HasOne("PolicyServer1.EntityFramework.Storage.Entities.Role", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PolicyServer1.EntityFramework.Storage.Entities.Role", "Role")
                        .WithMany("Parents")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PolicyServer1.EntityFramework.Storage.Entities.RoleSubject", b =>
                {
                    b.HasOne("PolicyServer1.EntityFramework.Storage.Entities.Role", "Role")
                        .WithMany("Subjects")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}