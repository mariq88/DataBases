﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SuperMarketInfo.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SupermarketInformationEntities1 : DbContext
    {
        public SupermarketInformationEntities1()
            : base("name=SupermarketInformationEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Measure> Measures { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
    }
}