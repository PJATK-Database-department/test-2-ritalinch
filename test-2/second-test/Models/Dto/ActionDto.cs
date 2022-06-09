namespace second_test.Models.Dto;

public class ActionDto
{
    public Action Action { get; set; }
    public IEnumerable<Firefighter> Firefighters { get; set; }

    public ActionDto(Action action, IEnumerable<Firefighter> firefighters)
    {
        Action = action;
        Firefighters = firefighters;
    }
}