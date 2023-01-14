using Microsoft.AspNetCore.SignalR;

namespace signalRtest.Hubs
{
    public class MyHub : Hub
    {
        public static List<string> Names { get; set; } = new List<string>();
        private static int ClientCount { get; set; } = 0;
        public static int TeamCount { get; set; } = 7;
        public async Task SendName(string name)
        {
            if (Names.Count >= TeamCount)
            {
                await Clients.Caller.SendAsync("Error", $"En fazla {TeamCount} kişi olabilir.");
            }
            else
            {
                Names.Add(name);
                await Clients.All.SendAsync("ReceiveName", name);
            }
        }
        public async Task GetNames()
        {
            await Clients.All.SendAsync("ReceiveNames", Names);
        }
        // public async override Task 
        public async override Task OnConnectedAsync()
        {
            ClientCount+=1;
            await Clients.All.SendAsync("ReciveClientCount", ClientCount);
            await base.OnConnectedAsync();
        }
        public async override Task OnDisconnectedAsync(Exception? exception)
        {
            ClientCount-=1;
            await Clients.All.SendAsync("ReciveClientCount", ClientCount);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
