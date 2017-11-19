using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace EntityFrameworkConcepts
{
    class Program
    {
        static void Main(string[] args)
        {
            //Database.SetInitializer(new CreateDatabaseIfNotExists<UnderwritingEntitiesContainer>());

            //EF_concurrencyfeatures();

            using (UnderwritingEntitiesContainer db = new UnderwritingEntitiesContainer())
            {
                db.Database.Log = Console.WriteLine;

                ////use Db table name for Sqlquery
                ////tightly coupled code
                //var headers = db.headers.SqlQuery("Select * from uw.header");

                //foreach(var h in headers)
                //{
                //    Console.WriteLine("ID" + h.Id + " value " + h.PolicyReference);
                //}

                var objectContext = (db as IObjectContextAdapter).ObjectContext;
                //Use EntitySql
                //strongly typed
                using (EntityConnection connection = objectContext.Connection as EntityConnection)
                {
                    connection.Open();
                    EntityCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "Select value header from UnderwritingEntitiesContainer.headers as header";

                    EntityDataReader dr = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
                    while(dr.Read())
                    {
                        Console.WriteLine("id " + dr[0]);
                        Console.WriteLine("value " + dr[1]);
                    }


                    //ObjectQuery
                    string query = "select value h from UnderwritingEntitiesContainer.headers as h";
                    // Use for filter - ObjectParameter
                    foreach (header h in new ObjectQuery<header>(query, objectContext))
                    {
                        Console.WriteLine("id " + h.HeaderId + " policy " + h.PolicyReference);
                    }
                    connection.Close();
                }

               
            }
                Console.ReadKey();
        }

        private static void EF_concurrencyfeatures()
        {
            using (UnderwritingEntitiesContainer db = new UnderwritingEntitiesContainer())
            {
                //using (TransactionScope trans = new TransactionScope())
                //{
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Database.Log = Console.WriteLine;

                        //db.Configuration.AutoDetectChangesEnabled = false;
                        //db.Configuration.ProxyCreationEnabled = false;

                        db.headers.Add(new header() { HeaderId = 2, PolicyReference = "P02" });

                        db.headers.Find(1).PolicyReference += "-1";

                        Console.WriteLine(db.ChangeTracker.Entries().Count());
                        Console.WriteLine(db.ChangeTracker.Entries().Where(e => e.State != System.Data.Entity.EntityState.Unchanged).Count());
                        db.ChangeTracker.DetectChanges();
                        Console.WriteLine(db.ChangeTracker.Entries().Where(e => e.State != System.Data.Entity.EntityState.Unchanged).Count());

                        var changedheader = db.ChangeTracker.Entries().Where(e => e.State == System.Data.Entity.EntityState.Modified).First();

                        Console.WriteLine("ID - " + changedheader.OriginalValues["HeaderId"] + " Modified? " + changedheader.Property("HeaderId").IsModified);
                        Console.WriteLine(changedheader.OriginalValues["PolicyReference"] + " is now " + changedheader.CurrentValues["PolicyReference"]);

                        Console.WriteLine(db.ChangeTracker.Entries().Last().Entity.GetType().FullName);
                        //db.SaveChanges();
                        //transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
                //trans.Complete();
                //}
            }
        }
    }
}
