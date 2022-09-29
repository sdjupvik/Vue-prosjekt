using Microsoft.EntityFrameworkCore;

public class ArmyDBSeeder
{
    private readonly ArmyDBContext dBContext;

    public ArmyDBSeeder(ArmyDBContext _dBContext)
    {
        dBContext = _dBContext;
    }

    public async Task Seed()
    {
        var soldiers = dBContext.Soldiers.ToList();
        if (soldiers.Any())
            dBContext.Soldiers.RemoveRange(soldiers);

        var weapons = dBContext.Weapons.ToList();
        if (weapons.Any())
            dBContext.Weapons.RemoveRange(weapons);

        var missions = dBContext.Missions.ToList();
        if (missions.Any())
            dBContext.Missions.RemoveRange(missions);

        await SeedSoldiersAsync();
        await SeedWeaponsAsync();
        await SeedMissionsAsync();
    }

    public void xSeed()
    {
        var list = new List<Task>{
                        SeedMasterDataAsync(),
                        SeedSoldiersAsync(),
        };

        Task.WaitAll(list.ToArray());
    }

    public async Task SeedMasterDataAsync()
    {
        var weaponTypes = new List<WeaponType>{
            new WeaponType{ Name = "Machine Gun"},
            new WeaponType{ Name = "Missile"},
            new WeaponType{ Name = "Bomb"},
            new WeaponType{ Name = "Pistol"},
            new WeaponType{ Name = "Rifle"},
        };

        var vehicleTypes = new List<VehicleType>{
            new VehicleType{Name = "Aircraft Carrier"},
            new VehicleType{Name = "Fighter Aircraft"},
            new VehicleType{Name = "Stealth Bomber"},
            new VehicleType{Name = "Cargo Plane"},
            new VehicleType{Name = "Helicoptor"},
            new VehicleType{Name = "Submarine"},
            new VehicleType{Name = "War Ship"},
        };

        var soldierRanks = new List<SoldierRank>{
            new SoldierRank{ Name = "Major"},
            new SoldierRank{ Name = "Kaptein"},
            new SoldierRank{ Name = "Korporal"},
            new SoldierRank{ Name = "Visekorporal"},
        };

        var soldierMedals = new List<SoldierMedal>{
            new SoldierMedal{ Name = "Medal for Outstanding Civic Service"},
            new SoldierMedal{ Name = "Royal Norwegian Order of St. Olav"},
            new SoldierMedal{ Name = "St. Olav's Medal With Oak Branch"},
            new SoldierMedal{ Name = "Royal Norwegian Order of Merit"},
            new SoldierMedal{ Name = "Medal for Heroism in Gold"},
            new SoldierMedal{ Name = "Haakon VII Freedom Cross"},
            new SoldierMedal{ Name = "War Cross With Sword"},
        };

        var missionStatuses = new List<MissionStatus>{
            new MissionStatus{ Name = "Planning" },
            new MissionStatus{ Name = "In Progress" },
            new MissionStatus{ Name = "Successful" },
            new MissionStatus{ Name = "Failed" },
        };

        var soldierExpertises = new List<SoldierExpertise>{
            new SoldierExpertise{ Name = "Extreme Survival"},
            new SoldierExpertise{ Name = "Fighter Pilot"},
            new SoldierExpertise{ Name = "Martial Art"},
            new SoldierExpertise{ Name = "Tactician"},
            new SoldierExpertise{ Name = "Surgeon"},
            new SoldierExpertise{ Name = "Sniper"},
        };

        var tasks = new List<Task>{
            dBContext.SoldierExpertises.AddRangeAsync(soldierExpertises),
            dBContext.MissionStatuses.AddRangeAsync(missionStatuses),
            dBContext.SoldierMedals.AddRangeAsync(soldierMedals),
            dBContext.SoldierRanks.AddRangeAsync(soldierRanks),
            dBContext.VehicleTypes.AddRangeAsync(vehicleTypes),
            dBContext.WeaponTypes.AddRangeAsync(weaponTypes),
        };

        Task.WaitAll(tasks.ToArray());

        await dBContext.SaveChangesAsync();
    }

    public async Task SeedSoldiersAsync()
    {

        var soldiers = new List<Soldier>
        {
            new Soldier{
                Address = "59062 Stehr Oval, Fort Arlington, Norway",
                ChestWidth = 77,
                DateOfBirth = new DateTime(1995, 1, 1),
                FirstName = "Twila",
                Height = 157.5F,
                IsSpecialForces = false,
                LastName = "Parisian",
                RecruitedOn = new DateTime(2008, 5, 5),
                SoldierRank = dBContext.SoldierRanks.First(x => x.Name == "Major"),
                Weight = 60.3F,
                SoldierMedals = dBContext.SoldierMedals.Skip(1).Take(3).ToList(),
                SoldierExpertises = dBContext.SoldierExpertises.Skip(1).Take(3).ToList(),
            },
            new Soldier{
                Address = "3574 Hodkiewicz Mountains, West Springfield, Norway",
                ChestWidth = 77,
                DateOfBirth = new DateTime(1985, 6, 17),
                FirstName = "Alvis",
                Height = 156.5F,
                IsSpecialForces = false,
                LastName = "Ortiz",
                RecruitedOn = new DateTime(2008, 8, 5),
                SoldierRank = dBContext.SoldierRanks.First(x => x.Name == "Major"),
                Weight = 61.3F,
                SoldierMedals = dBContext.SoldierMedals.Skip(0).Take(2).ToList(),
                SoldierExpertises = dBContext.SoldierExpertises.Skip(0).Take(2).ToList(),
            },
            new Soldier{
                Address = "547 Kailyn Burg, Port Kokomo, Norway",
                ChestWidth = 77,
                DateOfBirth = new DateTime(1986, 7, 17),
                FirstName = "Elwyn",
                Height = 157.5F,
                IsSpecialForces = false,
                LastName = "Flatley",
                RecruitedOn = new DateTime(2008, 8, 15),
                SoldierRank = dBContext.SoldierRanks.First(x => x.Name == "Major"),
                Weight = 62.3F,
                SoldierMedals = dBContext.SoldierMedals.Skip(2).Take(3).ToList(),
                SoldierExpertises = dBContext.SoldierExpertises.Skip(2).Take(3).ToList(),
            },
            new Soldier{
                Address = "1525 Klein Courts, East Santa Barbara, Norway",
                ChestWidth = 78,
                DateOfBirth = new DateTime(1992, 2, 1),
                FirstName = "Berniece",
                Height = 160.2F,
                IsSpecialForces = true,
                LastName = "VonRueden",
                RecruitedOn = new DateTime(2006, 3, 15),
                SoldierRank = dBContext.SoldierRanks.First(x => x.Name == "Major"),
                Weight = 70.3F,
                SoldierMedals = dBContext.SoldierMedals.Skip(3).Take(2).ToList(),
                SoldierExpertises = dBContext.SoldierExpertises.Skip(3).Take(2).ToList(),
            },
            new Soldier{
                Address = "908 Rashad Cliff, West South Jordan, Norway",
                ChestWidth = 80,
                DateOfBirth = new DateTime(1991, 2, 5),
                FirstName = "Wilfredo",
                Height = 165.7F,
                IsSpecialForces = false,
                LastName = "Swift",
                RecruitedOn = new DateTime(2009, 3, 11),
                SoldierRank = dBContext.SoldierRanks.First(x => x.Name == "Kaptein"),
                Weight = 65.8F,
                SoldierMedals = dBContext.SoldierMedals.Skip(3).Take(1).ToList(),
                SoldierExpertises = dBContext.SoldierExpertises.Skip(3).Take(1).ToList(),
            },
            new Soldier{
                Address = "664 Gorczany Isle, Port Palm Bay, Norway",
                ChestWidth = 76,
                DateOfBirth = new DateTime(1989, 7, 15),
                FirstName = "Hardy",
                Height = 170.7F,
                IsSpecialForces = true,
                LastName = "Satterfield",
                RecruitedOn = new DateTime(2009, 12, 21),
                SoldierRank = dBContext.SoldierRanks.First(x => x.Name == "Visekorporal"),
                Weight = 67.4F,
                SoldierExpertises = dBContext.SoldierExpertises.Skip(2).Take(2).ToList(),
            },
            new Soldier{
                Address = "708 Feeney Harbors, North Peoria, Norway",
                ChestWidth = 79,
                DateOfBirth = new DateTime(1989, 4, 15),
                FirstName = "Daryl",
                Height = 159.2F,
                IsSpecialForces = false,
                LastName = "Mueller",
                RecruitedOn = new DateTime(2010, 11, 21),
                SoldierRank = dBContext.SoldierRanks.First(x => x.Name == "Korporal"),
                Weight = 66.4F,
                SoldierMedals = dBContext.SoldierMedals.Skip(4).Take(1).ToList(),
                SoldierExpertises = dBContext.SoldierExpertises.Skip(4).Take(1).ToList(),
            },
        };

        await dBContext.Soldiers.AddRangeAsync(soldiers);
        await dBContext.SaveChangesAsync();
    }

    public async Task SeedWeaponsAsync()
    {
        var weapons = new List<Weapon> {
            new Weapon {
                Name = "FN Minimi",
                Description = "In service with Norwegian Special Operations Forces and KJK since the early 2000s.",
                WeaponTypeId = dBContext.WeaponTypes.First(x => x.Name == "Machine Gun").Id,
                IsNuclear = false,
                Mass = 7,
                Length = 1040,
                Range = 123,
            },
            new Weapon {
                Name = "FN MAG",
                Description = "Installed on Leopard 2 tanks purchased from the Netherlands.",
                WeaponTypeId = dBContext.WeaponTypes.First(x => x.Name == "Machine Gun").Id,
                IsNuclear = false,
                Mass = 11,
                Length = 1263,
                Range = 153,
            },
            new Weapon {
                Name = "M2 Browning",
                Description = "In January 2019, the Norwegian Armed Forces ordered 1300 new M2A2N, which will replace the older HMGs.",
                WeaponTypeId = dBContext.WeaponTypes.First(x => x.Name == "Machine Gun").Id,
                IsNuclear = false,
                Mass = 38,
                Length = 1654,
                Range = 453,
            },
            new Weapon {
                Name = "Glock P80",
                Description = "Introduced in 2020, the P80 was commissioned by United States firearms distributor Lipsey's to create an exclusive commemorative Glock model, the Pistole 80.",
                WeaponTypeId = dBContext.WeaponTypes.First(x => x.Name == "Pistol").Id,
                IsNuclear = false,
                Mass = 1,
                Length = 204,
                Range = 103,
            },
            new Weapon {
                Name = "Heckler & Koch HK417",
                Description = "Replaced the NM149 in the Norwegian Armed Forces.",
                WeaponTypeId = dBContext.WeaponTypes.First(x => x.Name == "Rifle").Id,
                IsNuclear = false,
                Mass = 4,
                Length = 885,
                Range = 103,
            },
        };

        await dBContext.Weapons.AddRangeAsync(weapons);
        await dBContext.SaveChangesAsync();
    }

    public async Task SeedMissionsAsync()
    {
        var missions = new List<Mission>{
            new Mission {
                CasualityCount = 12,
                Description = "This is a kill or capture mission. Operatives have full authorization for killing the primary target Usama Bin Laden if he is not going to surrender.",
                EquipmentRepairCost = 1200000,
                LossOfLifeCount = 2,
                MissionCompletedOn = new DateTime(2011, 5, 2),
                MissionStartedOn = new DateTime(2011, 5, 2),
                MissionStatus = dBContext.MissionStatuses.First(x => x.Name == "Successful"),
                Name = "Neptune Spear",
                PlanningStartedOn = new DateTime(2001, 10, 11),
                Soldiers = dBContext.Soldiers.Where(x => x.FirstName == "Daryl" || x.FirstName == "Hardy" || x.FirstName == "Twila").ToList(),
                Weapons = dBContext.Weapons.Where(x => x.Name == "Heckler & Koch HK417"||x.Name == "FN Minimi"||x.Name == "FN MAG").ToList()
            }
        };

        await dBContext.Missions.AddRangeAsync(missions);
        await dBContext.SaveChangesAsync();
    }
}