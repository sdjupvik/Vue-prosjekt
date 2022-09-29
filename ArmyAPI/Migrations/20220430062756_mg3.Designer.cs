﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ArmyAPI.Migrations
{
    [DbContext(typeof(ArmyDBContext))]
    [Migration("20220430062756_mg3")]
    partial class mg3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("Mission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CasualityCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("EquipmentRepairCost")
                        .HasColumnType("TEXT");

                    b.Property<int>("LossOfLifeCount")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("MissionCompletedOn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("MissionStartedOn")
                        .HasColumnType("TEXT");

                    b.Property<int>("MissionStatusId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PlanningStartedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MissionStatusId");

                    b.ToTable("Missions");
                });

            modelBuilder.Entity("MissionCommander", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MissionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SoldierId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MissionId")
                        .IsUnique();

                    b.HasIndex("SoldierId")
                        .IsUnique();

                    b.ToTable("MissionCommanders");
                });

            modelBuilder.Entity("MissionSoldier", b =>
                {
                    b.Property<int>("MissionsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SoldiersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MissionsId", "SoldiersId");

                    b.HasIndex("SoldiersId");

                    b.ToTable("MissionSoldier");
                });

            modelBuilder.Entity("MissionStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("MissionStatuses");
                });

            modelBuilder.Entity("MissionVehicle", b =>
                {
                    b.Property<int>("MissionsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VehiclesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MissionsId", "VehiclesId");

                    b.HasIndex("VehiclesId");

                    b.ToTable("MissionVehicle");
                });

            modelBuilder.Entity("MissionWeapon", b =>
                {
                    b.Property<int>("MissionsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WeaponsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MissionsId", "WeaponsId");

                    b.HasIndex("WeaponsId");

                    b.ToTable("MissionWeapon");
                });

            modelBuilder.Entity("ProfileImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ProfileImages");
                });

            modelBuilder.Entity("Soldier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("ChestWidth")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("Height")
                        .HasColumnType("REAL");

                    b.Property<bool>("IsSpecialForces")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RecruitedOn")
                        .HasColumnType("TEXT");

                    b.Property<int>("SoldierRankId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Weight")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("SoldierRankId");

                    b.ToTable("Soldiers");
                });

            modelBuilder.Entity("SoldierExpertise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("SoldierExpertises");
                });

            modelBuilder.Entity("SoldierMedal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("SoldierMedals");
                });

            modelBuilder.Entity("SoldierRank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("SoldierRanks");
                });

            modelBuilder.Entity("SoldierSoldierExpertise", b =>
                {
                    b.Property<int>("SoldierExpertisesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SoldiersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SoldierExpertisesId", "SoldiersId");

                    b.HasIndex("SoldiersId");

                    b.ToTable("SoldierSoldierExpertise");
                });

            modelBuilder.Entity("SoldierSoldierMedal", b =>
                {
                    b.Property<int>("SoldierMedalsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SoldiersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SoldierMedalsId", "SoldiersId");

                    b.HasIndex("SoldiersId");

                    b.ToTable("SoldierSoldierMedal");
                });

            modelBuilder.Entity("Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("CanCarryNuclearWeapon")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CommissionedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("VehicleTypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("VehicleTypeId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("VehicleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("VehicleTypes");
                });

            modelBuilder.Entity("Weapon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsNuclear")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Length")
                        .HasColumnType("REAL");

                    b.Property<float>("Mass")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<float>("Range")
                        .HasColumnType("REAL");

                    b.Property<int>("WeaponTypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WeaponTypeId");

                    b.ToTable("Weapons");
                });

            modelBuilder.Entity("WeaponType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("WeaponTypes");
                });

            modelBuilder.Entity("Mission", b =>
                {
                    b.HasOne("MissionStatus", "MissionStatus")
                        .WithMany()
                        .HasForeignKey("MissionStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MissionStatus");
                });

            modelBuilder.Entity("MissionCommander", b =>
                {
                    b.HasOne("Mission", null)
                        .WithOne()
                        .HasForeignKey("MissionCommander", "MissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Soldier", null)
                        .WithOne()
                        .HasForeignKey("MissionCommander", "SoldierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MissionSoldier", b =>
                {
                    b.HasOne("Mission", null)
                        .WithMany()
                        .HasForeignKey("MissionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Soldier", null)
                        .WithMany()
                        .HasForeignKey("SoldiersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MissionVehicle", b =>
                {
                    b.HasOne("Mission", null)
                        .WithMany()
                        .HasForeignKey("MissionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vehicle", null)
                        .WithMany()
                        .HasForeignKey("VehiclesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MissionWeapon", b =>
                {
                    b.HasOne("Mission", null)
                        .WithMany()
                        .HasForeignKey("MissionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Weapon", null)
                        .WithMany()
                        .HasForeignKey("WeaponsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Soldier", b =>
                {
                    b.HasOne("SoldierRank", "SoldierRank")
                        .WithMany("Soldiers")
                        .HasForeignKey("SoldierRankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SoldierRank");
                });

            modelBuilder.Entity("SoldierSoldierExpertise", b =>
                {
                    b.HasOne("SoldierExpertise", null)
                        .WithMany()
                        .HasForeignKey("SoldierExpertisesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Soldier", null)
                        .WithMany()
                        .HasForeignKey("SoldiersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SoldierSoldierMedal", b =>
                {
                    b.HasOne("SoldierMedal", null)
                        .WithMany()
                        .HasForeignKey("SoldierMedalsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Soldier", null)
                        .WithMany()
                        .HasForeignKey("SoldiersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Vehicle", b =>
                {
                    b.HasOne("VehicleType", "VehicleType")
                        .WithMany()
                        .HasForeignKey("VehicleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VehicleType");
                });

            modelBuilder.Entity("Weapon", b =>
                {
                    b.HasOne("WeaponType", "WeaponType")
                        .WithMany()
                        .HasForeignKey("WeaponTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WeaponType");
                });

            modelBuilder.Entity("SoldierRank", b =>
                {
                    b.Navigation("Soldiers");
                });
#pragma warning restore 612, 618
        }
    }
}
