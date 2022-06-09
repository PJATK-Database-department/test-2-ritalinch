namespace second_test.Models
{
    public partial class Action
    {
        public Action()
        {
            FiretruckActions = new HashSet<FiretruckAction>();
            IdFirefighters = new HashSet<Firefighter>();
        }

        public int IdAction { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool NeedSpecialEquipment { get; set; }

        public virtual ICollection<FiretruckAction> FiretruckActions { get; set; }

        public virtual ICollection<Firefighter> IdFirefighters { get; set; }
    }
}
