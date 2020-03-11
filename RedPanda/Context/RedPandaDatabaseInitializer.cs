using System.Data.Entity;

namespace RedPanda.DataAccess.Context {
    internal class RedPandaDatabaseInitializer : DropCreateDatabaseIfModelChanges<RedPandaContext> {
        protected override void Seed(RedPandaContext context) {
            base.Seed(context);
        }
    }
}