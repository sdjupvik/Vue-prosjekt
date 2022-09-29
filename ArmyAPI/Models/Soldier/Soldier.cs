public class Soldier
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime RecruitedOn { get; set; }
    public string Address { get; set; }
    public bool IsSpecialForces { get; set; }
    public DateTime DateOfBirth { get; set; }
    public float Height { get; set; }
    public float Weight { get; set; }
    public float ChestWidth { get; set; }
    public int SoldierRankId { get; set; }

    public virtual SoldierRank SoldierRank { get; set; }
    public virtual List<Mission> Missions { get; set; }
    public virtual List<SoldierExpertise> SoldierExpertises { get; set; }
    public virtual List<SoldierMedal> SoldierMedals { get; set; }
}

public class CreateSoldierViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public int[] Expertises { get; set; }
    public bool IsSpecialForce { get; set; }
    public int Rank { get; set; }
    public float Weight { get; set; }
    public float Height { get; set; }
    public float ChestWidth { get; set; }
    public DateTime DateOfBirth { get; set; }
}
 