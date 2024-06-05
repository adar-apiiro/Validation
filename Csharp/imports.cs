using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Serilog;
using Microsoft.EntityFrameworkCore;
using EntityFramework;

namespace ExampleNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example usage of Microsoft.EntityFrameworkCore
            using (var context = new MyDbContext())
            {
                var data = context.MyEntities.ToList();
            }

            // Example usage of Microsoft.Data.SqlClient
            using (var connection = new SqlConnection("your_connection_string"))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM MyTable", connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["MyColumn"]);
                }
            }

            // Example usage of Newtonsoft.Json
            var jsonData = JsonConvert.SerializeObject(new { Name = "John", Age = 30 });
            var obj = JsonConvert.DeserializeObject<dynamic>(jsonData);
            Console.WriteLine($"Name: {obj.Name}, Age: {obj.Age}");

            // Example usage of Serilog
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            Log.Information("Hello, Serilog!");
        }
    }

    public class MyDbContext : DbContext
    {
        public DbSet<MyEntity> MyEntities { get; set; }
    }

    public class MyEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
