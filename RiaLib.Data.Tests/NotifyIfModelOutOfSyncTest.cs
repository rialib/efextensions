//-----------------------------------------------------------------------
// <copyright file="NotifyIfModelOutOfSync.cs" company="RIA Library Foundation">
//     Copyright © 2011 RIA Library Foundation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace RiaLib.Data.Tests
{
    using System.Data.Entity;
    using System.Data.Entity.Database;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class NotifyIfModelOutOfSyncTest
    {
        [TestMethod]
        public void InitializeDatabaseTest()
        {
            DbDatabase.SetInitializer<DatabaseContext>(new NotifyIfModelOutOfSync<DatabaseContext>());

            // TODO: Implement unit test

            using (var db = new DatabaseContext())
            {
                db.Users.Load();
            }
        }
    }
}
