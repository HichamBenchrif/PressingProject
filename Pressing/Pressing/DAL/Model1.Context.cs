﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pressing.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MLR1Entities : DbContext
    {
        public MLR1Entities()
            : base("name=MLR1Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ARTICLE> ARTICLEs { get; set; }
        public virtual DbSet<B_R> B_R { get; set; }
        public virtual DbSet<BON_RECEPTION> BON_RECEPTION { get; set; }
        public virtual DbSet<BON_SORTIE> BON_SORTIE { get; set; }
        public virtual DbSet<CATEGORIE_ARTILCLE> CATEGORIE_ARTILCLE { get; set; }
        public virtual DbSet<CLIENT> CLIENTs { get; set; }
        public virtual DbSet<DÉPENSES_ET_ENTRÉES> DÉPENSES_ET_ENTRÉES { get; set; }
        public virtual DbSet<FACTURE> FACTUREs { get; set; }
        public virtual DbSet<FAMILL> FAMILLs { get; set; }
        public virtual DbSet<FOURNISSEUR> FOURNISSEURs { get; set; }
        public virtual DbSet<SERVICE> SERVICEs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
