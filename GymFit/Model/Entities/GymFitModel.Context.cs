﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GymFit.Model.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GymFitEntities : DbContext
    {
        public GymFitEntities()
            : base("name=GymFitEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Adres> Adres { get; set; }
        public virtual DbSet<Dostawca> Dostawca { get; set; }
        public virtual DbSet<Faktura> Faktura { get; set; }
        public virtual DbSet<Grafik> Grafik { get; set; }
        public virtual DbSet<Karnet> Karnet { get; set; }
        public virtual DbSet<Klient> Klient { get; set; }
        public virtual DbSet<Notatka> Notatka { get; set; }
        public virtual DbSet<ObiektSportowy> ObiektSportowy { get; set; }
        public virtual DbSet<Osoba> Osoba { get; set; }
        public virtual DbSet<PozycjaFaktury> PozycjaFaktury { get; set; }
        public virtual DbSet<Pracownik> Pracownik { get; set; }
        public virtual DbSet<SposobPlatnosci> SposobPlatnosci { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Szafka> Szafka { get; set; }
        public virtual DbSet<Towar> Towar { get; set; }
        public virtual DbSet<Wizyta> Wizyta { get; set; }
        public virtual DbSet<Wojewodztwo> Wojewodztwo { get; set; }
        public virtual DbSet<Zadanie> Zadanie { get; set; }
    }
}
