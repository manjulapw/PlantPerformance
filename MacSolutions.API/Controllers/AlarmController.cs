using MediatR;
using Microsoft.AspNetCore.Mvc;
using MacSolutions.Application.Alarms.Commands.CreateAlarm;
using MacSolutions.Application.Alarms.Commands.DeleteAlarm;
using MacSolutions.Application.Alarms.Commands.UpdateAlarm;
using MacSolutions.Application.Alarms.Queries.GetAllAlarms;
using MacSolutions.Application.Alarms.Queries.GetAlarmById;

namespace MacSolutions.API.Controllers;

[ApiController]
[Route("api/Alarms")]
public class AlarmController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var Alarms = await mediator.Send(new GetAllAlarmsQuery());
        return Ok(Alarms);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute]int id)
    {
        var Alarm = await mediator.Send(new GetAlarmByIdQuery(id));
        return Ok(Alarm);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAlarm(CreateAlarmCommand command)
    {
        var id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAlarm([FromRoute] int id)
    {
        await mediator.Send(new DeleteAlarmCommand(id));
        return NoContent();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateAlarm([FromRoute] int id, UpdateAlarmCommand command)
    {
        command.Id = id;
        await mediator.Send(command);
        return NoContent();
    }
}