public class Weapon : BaseModelEntity
{
    public int WeaponTypeId { get; set; }
    public bool IsNuclear { get; set; }
    public float Range { get; set; }
    public float Length { get; set; } // unit mm
    public float Mass { get; set; } // unit kg

    public virtual WeaponType WeaponType { get; set; }

    public virtual List<Mission> Missions { get; set; }
}

public class CreateWeaponViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsNuclear { get; set; }
    public float Range { get; set; }
    public float Length { get; set; }
    public float Mass { get; set; }
    public int Type { get; set; }
}