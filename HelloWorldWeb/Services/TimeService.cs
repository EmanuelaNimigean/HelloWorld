// <copyright file="TimeService.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

using System;

namespace HelloWorldWeb.Services
{
    public class TimeService : ITimeService
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}