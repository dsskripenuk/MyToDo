using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Test_Task_Shop_Express.Models;

namespace Test_Task_Shop_Express
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TaskModel> Tasks { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
