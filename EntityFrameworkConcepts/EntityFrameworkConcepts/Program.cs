using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkConcepts
{
    class Program
    {
        static void Main(string[] args)
        {
            using (UnderwritingEntitiesContainer db = new UnderwritingEntitiesContainer())
            {
                db.Database.Log = Console.WriteLine;

                //db.Configuration.AutoDetectChangesEnabled = false;
                //db.Configuration.ProxyCreationEnabled = false;

                db.headers.Add(new header() { Id = 2,PolicyReference = "P02" });

                db.headers.Find(1).PolicyReference += "-1";

                Console.WriteLine(db.ChangeTracker.Entries().Count());
                Console.WriteLine(db.ChangeTracker.Entries().Where(e => e.State != System.Data.Entity.EntityState.Unchanged).Count());
                db.ChangeTracker.DetectChanges();
                Console.WriteLine(db.ChangeTracker.Entries().Where(e => e.State != System.Data.Entity.EntityState.Unchanged).Count());

                var changedheader = db.ChangeTracker.Entries().Where(e => e.State == System.Data.Entity.EntityState.Modified).First();

                Console.WriteLine("ID - " + changedheader.OriginalValues["Id"] + " Modified? " +changedheader.Property("Id").IsModified);
                Console.WriteLine(changedheader.OriginalValues["PolicyReference"] + " is now " + changedheader.CurrentValues["PolicyReference"]);

                Console.WriteLine(db.ChangeTracker.Entries().Last().Entity.GetType().FullName);
            }
            Console.ReadKey();
        }
    }
}
