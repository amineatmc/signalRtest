using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using signalRtest.Hubs;

namespace signalRtest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly IHubContext<MyHub> _hubContext;
        public NotificationController(IHubContext<MyHub> hubContext)
        {
            _hubContext = hubContext;
        }


        [HttpGet("{teamCount}")]
        public async Task<IActionResult> SetTeamCount(int teamCount)
        {
            MyHub.TeamCount = teamCount;
            await _hubContext.Clients.All.SendAsync("Notify",$"Takım {teamCount} kişi olacaktır.");
            return Ok();
        }
    }
}
