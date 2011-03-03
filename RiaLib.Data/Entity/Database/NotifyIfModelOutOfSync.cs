//-----------------------------------------------------------------------
// <copyright file="NotifyIfModelOutOfSync.cs" company="RIA Library Foundation">
//     Copyright © 2011 RIA Library Foundation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace System.Data.Entity.Database
{
    using System;
    using System.Transactions;

    public class NotifyIfModelOutOfSync<TContext> : IDatabaseInitializer<TContext> where TContext : DbContext
    {
        private readonly Action<string> notify;

        public NotifyIfModelOutOfSync()
        {
            this.notify = message =>
                {
                    throw new Exception(Exceptions.ModelIsOutOfSync, new Exception(message));
                };
        }

        public NotifyIfModelOutOfSync(Action<string> notify)
        {
            this.notify = notify;
        }

        public void InitializeDatabase(TContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            // Create new database if it doesn't exist
            using (new TransactionScope(TransactionScopeOption.Suppress))
            {
                if (!context.Database.Exists())
                {
                    context.Database.Create();
                    Seed(context);
                    context.SaveChanges();
                    return;
                }
            }

            // TODO: Compare model metadata with db schema. Notify caller if model is out of sync

            // if (outOfSync)
            // {
            //     notify(message);
            // }
        }

        protected virtual void Seed(TContext context)
        {
        }
    }
}
