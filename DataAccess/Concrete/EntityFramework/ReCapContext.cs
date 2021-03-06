﻿using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class ReCapContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                //optionsBuilder.UseSqlServer(@"Server=TU04LTBX1Y5Q2;Database=ReCap;Trusted_Connection=true");
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-TEV2VHC\SQLEXPRESS;Database=ReCap;Trusted_Connection=true");
            }
            catch (Exception)
            {

                Console.WriteLine("Database bağlanamıyor");
            }
            
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
