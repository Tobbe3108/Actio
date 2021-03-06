﻿using System;
using Actio.Common.Events.Interfaces;

namespace Actio.Common.Events.Rejected
{
    public class CreateActivityRejected : IRejectedEvent
    {
        protected CreateActivityRejected()
        {
        }

        public CreateActivityRejected(Guid id, string reason, string code)
        {
            Id = id;
            Reason = reason;
            Code = code;
        }

        public Guid Id { get; set; }
        public string Reason { get; }
        public string Code { get; }
    }
}