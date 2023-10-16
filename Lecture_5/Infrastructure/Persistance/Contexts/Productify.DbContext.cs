﻿using System;
using Microsoft.EntityFrameworkCore;

using Productify.Domain.Entities;

namespace Productify.Persistance.Contexts
{
	public class ProductifyDbContext: DbContext 
	{
		public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
			optionsBuilder.UseInMemoryDatabase("ProductifyDb");

        }

        public ProductifyDbContext()
		{
		}
	}
}

