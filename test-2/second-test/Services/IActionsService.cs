using second_test.Models.Dto;

namespace second_test.Services;

public interface IActionsService
{
    Task<ActionDto> GetActionWithFirefightersByIdAsync(int id);
    Task DeleteActionByIdAsync(int id);
}