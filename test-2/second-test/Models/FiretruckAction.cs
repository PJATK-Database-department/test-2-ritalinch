namespace second_test.Models
{
    public partial class FiretruckAction
    {
        public int IdFireTruckAction { get; set; }
        public DateTime AssignmentDate { get; set; }
        public int IdFireTruck { get; set; }
        public int IdAction { get; set; }

        public virtual Action IdActionNavigation { get; set; } = null!;
        public virtual FireTruck IdFireTruckNavigation { get; set; } = null!;
    }
}
