using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArmyAPI.Migrations
{
    public partial class mg1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MissionStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoldierExpertises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoldierExpertises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoldierMedals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoldierMedals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoldierRanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoldierRanks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeaponTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MissionStatusId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlanningStartedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MissionStartedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MissionCompletedOn = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CasualityCount = table.Column<int>(type: "INTEGER", nullable: false),
                    LossOfLifeCount = table.Column<int>(type: "INTEGER", nullable: false),
                    EquipmentRepairCost = table.Column<decimal>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Missions_MissionStatuses_MissionStatusId",
                        column: x => x.MissionStatusId,
                        principalTable: "MissionStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Soldiers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    RecruitedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    IsSpecialForces = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Height = table.Column<float>(type: "REAL", nullable: false),
                    Weight = table.Column<float>(type: "REAL", nullable: false),
                    ChestWidth = table.Column<float>(type: "REAL", nullable: false),
                    SoldierRankId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soldiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Soldiers_SoldierRanks_SoldierRankId",
                        column: x => x.SoldierRankId,
                        principalTable: "SoldierRanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VehicleTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    CommissionedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CanCarryNuclearWeapon = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WeaponTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsNuclear = table.Column<bool>(type: "INTEGER", nullable: false),
                    Range = table.Column<float>(type: "REAL", nullable: false),
                    Length = table.Column<float>(type: "REAL", nullable: false),
                    Mass = table.Column<float>(type: "REAL", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weapons_WeaponTypes_WeaponTypeId",
                        column: x => x.WeaponTypeId,
                        principalTable: "WeaponTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MissionCommanders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MissionId = table.Column<int>(type: "INTEGER", nullable: false),
                    SoldierId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionCommanders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MissionCommanders_Missions_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Missions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MissionCommanders_Soldiers_SoldierId",
                        column: x => x.SoldierId,
                        principalTable: "Soldiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MissionSoldier",
                columns: table => new
                {
                    MissionsId = table.Column<int>(type: "INTEGER", nullable: false),
                    SoldiersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionSoldier", x => new { x.MissionsId, x.SoldiersId });
                    table.ForeignKey(
                        name: "FK_MissionSoldier_Missions_MissionsId",
                        column: x => x.MissionsId,
                        principalTable: "Missions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MissionSoldier_Soldiers_SoldiersId",
                        column: x => x.SoldiersId,
                        principalTable: "Soldiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoldierSoldierExpertise",
                columns: table => new
                {
                    SoldierExpertisesId = table.Column<int>(type: "INTEGER", nullable: false),
                    SoldiersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoldierSoldierExpertise", x => new { x.SoldierExpertisesId, x.SoldiersId });
                    table.ForeignKey(
                        name: "FK_SoldierSoldierExpertise_SoldierExpertises_SoldierExpertisesId",
                        column: x => x.SoldierExpertisesId,
                        principalTable: "SoldierExpertises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoldierSoldierExpertise_Soldiers_SoldiersId",
                        column: x => x.SoldiersId,
                        principalTable: "Soldiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoldierSoldierMedal",
                columns: table => new
                {
                    SoldierMedalsId = table.Column<int>(type: "INTEGER", nullable: false),
                    SoldiersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoldierSoldierMedal", x => new { x.SoldierMedalsId, x.SoldiersId });
                    table.ForeignKey(
                        name: "FK_SoldierSoldierMedal_SoldierMedals_SoldierMedalsId",
                        column: x => x.SoldierMedalsId,
                        principalTable: "SoldierMedals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoldierSoldierMedal_Soldiers_SoldiersId",
                        column: x => x.SoldiersId,
                        principalTable: "Soldiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MissionVehicle",
                columns: table => new
                {
                    MissionsId = table.Column<int>(type: "INTEGER", nullable: false),
                    VehiclesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionVehicle", x => new { x.MissionsId, x.VehiclesId });
                    table.ForeignKey(
                        name: "FK_MissionVehicle_Missions_MissionsId",
                        column: x => x.MissionsId,
                        principalTable: "Missions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MissionVehicle_Vehicles_VehiclesId",
                        column: x => x.VehiclesId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MissionWeapon",
                columns: table => new
                {
                    MissionsId = table.Column<int>(type: "INTEGER", nullable: false),
                    WeaponsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionWeapon", x => new { x.MissionsId, x.WeaponsId });
                    table.ForeignKey(
                        name: "FK_MissionWeapon_Missions_MissionsId",
                        column: x => x.MissionsId,
                        principalTable: "Missions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MissionWeapon_Weapons_WeaponsId",
                        column: x => x.WeaponsId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MissionCommanders_MissionId",
                table: "MissionCommanders",
                column: "MissionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MissionCommanders_SoldierId",
                table: "MissionCommanders",
                column: "SoldierId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Missions_MissionStatusId",
                table: "Missions",
                column: "MissionStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_MissionSoldier_SoldiersId",
                table: "MissionSoldier",
                column: "SoldiersId");

            migrationBuilder.CreateIndex(
                name: "IX_MissionStatuses_Name",
                table: "MissionStatuses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MissionVehicle_VehiclesId",
                table: "MissionVehicle",
                column: "VehiclesId");

            migrationBuilder.CreateIndex(
                name: "IX_MissionWeapon_WeaponsId",
                table: "MissionWeapon",
                column: "WeaponsId");

            migrationBuilder.CreateIndex(
                name: "IX_SoldierExpertises_Name",
                table: "SoldierExpertises",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SoldierMedals_Name",
                table: "SoldierMedals",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SoldierRanks_Name",
                table: "SoldierRanks",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Soldiers_SoldierRankId",
                table: "Soldiers",
                column: "SoldierRankId");

            migrationBuilder.CreateIndex(
                name: "IX_SoldierSoldierExpertise_SoldiersId",
                table: "SoldierSoldierExpertise",
                column: "SoldiersId");

            migrationBuilder.CreateIndex(
                name: "IX_SoldierSoldierMedal_SoldiersId",
                table: "SoldierSoldierMedal",
                column: "SoldiersId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleTypeId",
                table: "Vehicles",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleTypes_Name",
                table: "VehicleTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_WeaponTypeId",
                table: "Weapons",
                column: "WeaponTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WeaponTypes_Name",
                table: "WeaponTypes",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MissionCommanders");

            migrationBuilder.DropTable(
                name: "MissionSoldier");

            migrationBuilder.DropTable(
                name: "MissionVehicle");

            migrationBuilder.DropTable(
                name: "MissionWeapon");

            migrationBuilder.DropTable(
                name: "SoldierSoldierExpertise");

            migrationBuilder.DropTable(
                name: "SoldierSoldierMedal");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Missions");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "SoldierExpertises");

            migrationBuilder.DropTable(
                name: "SoldierMedals");

            migrationBuilder.DropTable(
                name: "Soldiers");

            migrationBuilder.DropTable(
                name: "VehicleTypes");

            migrationBuilder.DropTable(
                name: "MissionStatuses");

            migrationBuilder.DropTable(
                name: "WeaponTypes");

            migrationBuilder.DropTable(
                name: "SoldierRanks");
        }
    }
}
