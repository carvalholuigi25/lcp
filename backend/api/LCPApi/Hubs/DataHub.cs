using Microsoft.AspNetCore.SignalR;

namespace LCPApi.Hubs;

public class DataHub : Hub {
    public async Task SendData(string user, string data) {
        await Clients.All.SendAsync("ReceiveData", user, data);
    }
}