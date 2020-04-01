using System;
using Actio.Common.Commands.Interfaces;

namespace Actio.Common.Commands
{
    public class CreateActivity : IAuthenticatedCommand
    {
        public Guid Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UserId { get; set; }
    }
}