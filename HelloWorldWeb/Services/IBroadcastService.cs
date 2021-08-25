// <copyright file="IBroadcastService.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

namespace HelloWorldWeb.Services
{
    public interface IBroadcastService
    {
        void TeamMemberAdded(string name, int id);

        void TeamMemberDeleted(int id);

        void TeamMemberEdit(string name, int id);
    }
}