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

Want to participate in this project?
------------------------------------

Fill free to fork this repo and pull back your updates.