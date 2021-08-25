// <copyright file="BroadcastService.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.SignalR;

namespace HelloWorldWeb.Services
{
    public class BroadcastService : IBroadcastService
    {
        private readonly IHubContext<MessageHub> messageHub;

        public BroadcastService(IHubContext<MessageHub> messageHub)
        {
            this.messageHub = messageHub;
        }

        public void TeamMemberAdded(string name, int id)
        {
            this.messageHub.Clients.All.SendAsync("TeamMemberAdded", name, id);
        }

        public void TeamMemberDeleted(int id)
        {
            this.messageHub.Clients.All.SendAsync("TeamMemberDeleted", id);
        }

        public void TeamMemberEdit(string name, int id)
        {
            this.messageHub.Clients.All.SendAsync("TeamMemberEdit", name, id);
        }
    }
}
