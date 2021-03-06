﻿using System;
using System.Threading.Tasks;
using Actio.Services.Activities.Domain.Models;

namespace Actio.Services.Activities.Domain.Repositories
{
    public interface IActivityRepository
    {
        Task AddAsync(Activity activity);
        Task<Activity> GetAsync(Guid id);
    }
}