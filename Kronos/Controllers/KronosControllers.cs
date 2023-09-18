using Kronos.Contract;
using Kronos.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Nodes;

namespace Kronos.Controllers;


[ApiController]
public class KronosControllers : ControllerBase
{
    private readonly RedmineAgent redmineAgent;

    public KronosControllers(RedmineAgent redmineAgent)
    {
        this.redmineAgent = redmineAgent;
    }

    [HttpPost("/")]
    public IActionResult HandleWebHook([FromBody] PushEvent pushEvent)
    {   
        if (pushEvent.Commits.Any())
        {
            foreach (var item in pushEvent.Commits)

            {
                EventModel eventModel = new EventModel(
                    eventName: pushEvent.EventName,
                    author: item.Author,
                    commit: item);
               bool submit = redmineAgent.SubmitTime(eventModel);
            }
        }

        return Ok("Ok");
    }

}

