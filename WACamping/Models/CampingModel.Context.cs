﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WACamping.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LOCAMERDataEntities : DbContext
    {
        public LOCAMERDataEntities()
            : base("name=LOCAMERDataEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<location> locations { get; set; }
        public virtual DbSet<mobil_home> mobil_home { get; set; }
        public virtual DbSet<option> options { get; set; }
        public virtual DbSet<sejour> sejours { get; set; }
        public virtual DbSet<tarif> tarifs { get; set; }
        public virtual DbSet<type_sejour> type_sejour { get; set; }
    }
}
