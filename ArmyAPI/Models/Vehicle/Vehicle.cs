public class Vehicle : BaseModelEntity
{
    public int VehicleTypeId { get; set; }
    public DateTime CommissionedOn { get; set; }
    public bool CanCarryNuclearWeapon { get; set; }

    public virtual List<Mission> Missions { get; set; }

    public virtual VehicleType VehicleType { get; set; }
}