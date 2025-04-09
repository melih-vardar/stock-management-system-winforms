using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace StockManagementSystem.Models
{
    public class DbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // Docker Compose ile çalıştırıldığında bu bağlantı dizesini kullanın
            // Docker ile MySQL konteynerinin adı "mysql" olarak tanımlanmıştır
            string connectionString = "server=localhost;user=stockuser;password=stockpass;database=stockmanagement;allowPublicKeyRetrieval=true;sslMode=none";
            
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            return new AppDbContext(optionsBuilder.Options);
        }
    }

    public static class DbConfig
    {
        // Alternatif olarak appsettings.json dosyasından da okunabilir
        private static string _connectionString = "server=localhost;user=stockuser;password=stockpass;database=stockmanagement;allowPublicKeyRetrieval=true;sslMode=none";

        public static AppDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));

            return new AppDbContext(optionsBuilder.Options);
        }

        public static void SetConnectionString(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
} 