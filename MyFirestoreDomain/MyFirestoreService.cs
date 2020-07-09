
using Google.Cloud.Firestore;
using MyFirestoreDomain.Contracts;

namespace MyFirestoreDomain
{
    public class MyFirestoreService
    {
        public FirestoreDb Db { get; private set; }

        public MyFirestoreService(IMyFirestoreDb db)
        {
            Db = db.GetFirestoreDb();
        }
    }
}
