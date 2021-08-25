﻿using HelloWorldWeb.Services;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWebMVC.Services
{
    public class BroadcastService : IBroadcastService
    {
        private readonly IHubContext<MessageHub> messageHub;

        public BroadcastService(IHubContext<MessageHub> messageHub)
        {
            this.messageHub = messageHub;
        }

        public void NewTeamMemberAdded(string name, int id)
        {
            this.messageHub.Clients.All.SendAsync("NewTeamMemberAdded", name, id);
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
