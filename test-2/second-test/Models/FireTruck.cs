namespace second_test.Models
{
    public partial class FireTruck
    {
        public FireTruck()
        {
            FiretruckActions = new HashSet<FiretruckAction>();
        }

        public int IdFireTruck { get; set; }
        public string OperationalNumber { get; set; } = null!;
        public bool SpecialEquipment { get; set; }

        public virtual ICollection<FiretruckAction> FiretruckActions { get; set; }
    }
}
