using Microsoft.EntityFrameworkCore;
using second_test.Contexts;
using second_test.Models;
using second_test.Models.Dto;
using test.Exceptions;

namespace second_test.Services.impl;

public class ActionsServiceImpl : IActionsService
{
    private readonly FirefighterDbContext _context;

    public ActionsServiceImpl(FirefighterDbContext context)
    {
        _context = context;
    }

    public async Task<ActionDto> GetActionWithFirefightersByIdAsync(int id)
    {
        if (!await _context.Actions.AnyAsync(action => action.IdAction == id))
        {
            throw new NotFoundException();
        }

        var action = _context.Actions.First(action => action.IdAction == id);
        return new ActionDto(
            action,
            _context.Firefighters.Where(firefighter => firefighter.IdActions.Any(actionFire => actionFire.IdAction == action.IdAction))
        );
    }

    public async Task DeleteActionByIdAsync(int id)
    {
        if (!await _context.Actions.AnyAsync(action => action.IdAction == id))
        {
            throw new NotFoundException();
        }
        
        var action = _context.Actions.First(action => action.IdAction == id);
        if (action.EndTime != null)
        {
            throw new BadArgumentsException("Action is already completed");
        }

        _context.Actions.Remove(action);
        await foreach (var contextFirefighter in _context.Firefighters)
        {
            if (contextFirefighter.IdActions.Contains(action))
            {
                contextFirefighter.IdActions.Remove(action);
            }
        }
        
        await foreach (var contextFireTruckAction in _context.FiretruckActions)
        {
            if (contextFireTruckAction.IdAction == action.IdAction)
            {
                _context.FiretruckActions.Remove(contextFireTruckAction);
            }
        }

        await _context.SaveChangesAsync();
    }
}