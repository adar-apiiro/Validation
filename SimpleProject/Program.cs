
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using log4net;
using EntityFramework;
using Microsoft.AspNetCore;
using Docker.DotNet;
using Newtonsoft.Json;

namespace SimpleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MyDbContext())
            {
                var data = context.MyEntities.ToList();
                foreach (var entity in data)
                {
                    Console.WriteLine($"Id: {entity.Id}, Name: {entity.Name}");
                }
            }

            var log = LogManager.GetLogger(typeof(Program));
            log.Info("Hello, log4net!");
        }
    }

    public class MyDbContext : IdentityDbContext
    {
        public DbSet<MyEntity> MyEntities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("your_connection_string");
        }
    }

    public class MyEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
