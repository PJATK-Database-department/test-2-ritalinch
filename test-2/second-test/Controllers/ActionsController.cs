using Microsoft.AspNetCore.Mvc;
using second_test.Services;
using test.Exceptions;

namespace second_test.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActionsController : Controller
{
    private readonly IActionsService _service;

    public ActionsController(IActionsService service)
    {
        _service = service;
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetActionWithFirefightersByIdAsync([FromRoute] int id)
    {
        try
        {
            return Ok(await _service.GetActionWithFirefightersByIdAsync(id));
        }
        catch (NotFoundException)
        {
            return NotFound("No action with provided index found");
        }
    }
    

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteActionByIdAsync([FromRoute] int id)
    {
        try
        {
            await _service.DeleteActionByIdAsync(id);
            return Ok();
        }
        catch (NotFoundException)
        {
            return NotFound("No action with provided index found");
        }
        catch (BadArgumentsException e)
        {
            return BadRequest(e.Message);
        }
    }
}