﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tiyatro_Takip.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TiyatroEntities2 : DbContext
    {
        public TiyatroEntities2()
            : base("name=TiyatroEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Sahne_Turu> Sahne_Turu { get; set; }
        public virtual DbSet<Tiyatro> Tiyatro { get; set; }
        public virtual DbSet<tiyatro_kategori> tiyatro_kategori { get; set; }
        public virtual DbSet<Tiyatro_Konusu> Tiyatro_Konusu { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }
        public virtual DbSet<Uyeler> Uyeler { get; set; }
    }
}
