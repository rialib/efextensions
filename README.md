Entity Framework Extensions
===========================

The ADO.NET Entity Framework Extensions library contains a set of utility classes with additional functionality to Entity Framework CTP5.

NotifyIfModelOutOfSync
----------------------

This class can be used to send you notification (or throw an exception) if model and database schema are out of sync.

	DbDatabase.SetInitializer<DatabaseContext>(new NotifyIfModelOutOfSync<DatabaseContext>());

	using (var db = new DatabaseContext())
	{
		db.Users.Load();
	}

TableSchemaConvention
---------------------

This class can be used to make Entity Framework generate db schema for your models with respect to their parent namespace(s). For example if you have a model `RiaLib.Data.Models.Membership.User` then coresponding db table will be called [Membership].[User] instead of [dbo].[User].

    public class DatabaseContext : DbContext
    {
        public DbSet<Membership.User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();

            modelBuilder.Conventions.Add(new TableSchemaConvention());
			
			base.OnModelCreating(modelBuilder);
        }
    }

Want to participate in this project?
------------------------------------

Fill free to [fork](https://github.com/rialib/efextensions/fork) this repo and [pull back](https://github.com/rialib/efextensions/pull/new/master) your updates.