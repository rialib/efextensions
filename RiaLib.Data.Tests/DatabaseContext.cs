//-----------------------------------------------------------------------
// <copyright file="DatabaseContext.cs" company="RIA Library Foundation">
//     Copyright © 2011 RIA Library Foundation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace RiaLib.Data.Tests
{
    using System.Data.Entity;
    using System.Data.Entity.Database;
    using Membership = RiaLib.Data.Tests.Models.Membership;

    public class DatabaseContext : DbContext
    {
        public DbSet<Membership.User> Users { get; set; }

        public DbSet<Membership.Profile> Profiles { get; set; }

        protected override void OnModelCreating(System.Data.Entity.ModelConfiguration.ModelBuilder modelBuilder)
        {
            // If you don't want to create and use EdmMetadata table 
            // for monitoring the correspondence 
            // between the current model and table structure 
            // created in a database, then turn off IncludeMetadataConvention: 
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();

            modelBuilder.Conventions.Add(new TableSchemaConvention());

            base.OnModelCreating(modelBuilder);
        }
    }
}
