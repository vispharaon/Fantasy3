﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fantasy3.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class fantasyEntities : DbContext
    {
        public fantasyEntities()
            : base("name=fantasyEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<events> events { get; set; }
        public DbSet<footballplayer> footballplayer { get; set; }
        public DbSet<footballteam> footballteam { get; set; }
        public DbSet<gameweek> gameweek { get; set; }
        public DbSet<league> league { get; set; }
        public DbSet<leagueparticipants> leagueparticipants { get; set; }
        public DbSet<match> match { get; set; }
        public DbSet<matchevents> matchevents { get; set; }
        public DbSet<playernews> playernews { get; set; }
        public DbSet<position> position { get; set; }
        public DbSet<season> season { get; set; }
        public DbSet<selectedsquadchecked> selectedsquadchecked { get; set; }
        public DbSet<squad> squad { get; set; }
        public DbSet<squadplayer> squadplayer { get; set; }
        public DbSet<squadstructure> squadstructure { get; set; }
        public DbSet<user> user { get; set; }
        public DbSet<usergroup> usergroup { get; set; }
    }
}
