//-----------------------------------------------------------------------
// <copyright file="NotifyIfModelOutOfSync.cs" company="RIA Library Foundation">
//     Copyright © 2011 RIA Library Foundation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace RiaLib.Data.Tests
{
    using System.Data.Entity.Database;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class NotifyIfModelOutOfSyncTest
    {
        [TestMethod]
        public void TableSchemaConventionTest()
        {
            DbDatabase.SetInitializer(new DropCreateDatabaseAlways<DatabaseContext>());

            using (var db = new DatabaseContext())
            {
                db.Database.Initialize(true);

                var expected = typeof(DatabaseContext).GetProperties().Where(x => x.PropertyType.Name == "DbSet`1")
                    .Select(x => new { Namespace = x.PropertyType.GetGenericArguments()[0].FullName, PropertyName = x.Name })
                    .Select(x => { var i1 = x.Namespace.LastIndexOf('.'); var i2 = x.Namespace.LastIndexOf('.', i1 - 1); return x.Namespace.Substring(i2 + 1, i1 - i2) + x.PropertyName; })
                    .OrderBy(x => x).ToArray();
                
                var actual = db.Database.SqlQuery<string>(SqlQueries.SelectFullTableNames).ToArray();

                CollectionAssert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        public void InitializeDatabaseTest()
        {
            DbDatabase.SetInitializer(new NotifyIfModelOutOfSync<DatabaseContext>());

            // TODO: Implement unit test

            using (var db = new DatabaseContext())
            {
                db.Database.Initialize(true);
            }
        }
    }
}
