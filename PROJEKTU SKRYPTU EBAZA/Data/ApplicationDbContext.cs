using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PROJEKTU_SKRYPTU_EBAZA.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

         
                  
              
        }
        //Stworzenie Tabeli Produktów o nazwie Products
        public DbSet<Product> Products { get; set; }
        //Stworzenie Tabeli Kategorii o nazwie ProductsCategories
        public DbSet<ProductCategory> ProductCategories { get; set; }

        //Stworzenie Tabelii Dostawóc o nazwie Suppliers
        public DbSet<Supplier> Suppliers { get; set; }

    }
}
