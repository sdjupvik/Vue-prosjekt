using System.ComponentModel.DataAnnotations.Schema;

public class Mission : BaseModelEntity
{
    public int MissionStatusId { get; set; }
    public DateTime PlanningStartedOn { get; set; }
    public DateTime? MissionStartedOn { get; set; }
    public DateTime? MissionCompletedOn { get; set; }
    public int CasualityCount { get; set; }
    public int LossOfLifeCount { get; set; }
    public decimal EquipmentRepairCost { get; set; }

    public MissionStatus MissionStatus { get; set; }
    public virtual List<Weapon> Weapons { get; set; }
    public virtual List<Soldier> Soldiers { get; set; }
    public virtual List<Vehicle> Vehicles { get; set; }
}

public class CreateMissionViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int[] Soldiers { get; set; }
}


public class UpdateMissionViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int[] Soldiers { get; set; }
    public decimal Damage { get; set; }
    public int Status { get; set; }
}