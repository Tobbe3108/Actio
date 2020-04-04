using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actio.Services.Activities.Services
{
    public interface IActivityService
    {
        Task AddAsync(Guid id, Guid userId, string category, string name, string description, DateTime createdAt);
    }
}