﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProductionLopushock.Components
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Ekz_WSREntities : DbContext
    {
        public Ekz_WSREntities()
            : base("name=Ekz_WSREntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Adress> Adress { get; set; }
        public virtual DbSet<Agent> Agent { get; set; }
        public virtual DbSet<Application> Application { get; set; }
        public virtual DbSet<Change> Change { get; set; }
        public virtual DbSet<ChangeMaterial> ChangeMaterial { get; set; }
        public virtual DbSet<ChangePeople> ChangePeople { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<MinCost> MinCost { get; set; }
        public virtual DbSet<Movements> Movements { get; set; }
        public virtual DbSet<NFCCard> NFCCard { get; set; }
        public virtual DbSet<PointSale> PointSale { get; set; }
        public virtual DbSet<Priority> Priority { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Remains> Remains { get; set; }
        public virtual DbSet<Shop> Shop { get; set; }
        public virtual DbSet<Standard> Standard { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<Supply> Supply { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TypeAgent> TypeAgent { get; set; }
        public virtual DbSet<TypeMaterial> TypeMaterial { get; set; }
        public virtual DbSet<TypeProduct> TypeProduct { get; set; }
        public virtual DbSet<TypeSupplier> TypeSupplier { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<Warehouse> Warehouse { get; set; }
        public virtual DbSet<Workshop> Workshop { get; set; }
    }
}
