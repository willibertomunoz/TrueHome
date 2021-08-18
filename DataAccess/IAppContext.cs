using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess
{
    public interface IAppContext : IDisposable
    {
        public DbSet<Property> Property { get; set; }

        public DbSet<Activity> Activity { get; set; }

        public DbSet<Survey> Survey { get; set; }
    }
}
