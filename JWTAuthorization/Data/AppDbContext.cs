﻿using Microsoft.EntityFrameworkCore;
using JWTAuthorization.Models;
namespace JWTAuthorization.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
