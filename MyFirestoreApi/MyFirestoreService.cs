
using Google.Cloud.Firestore;
using MyFirestoreDomain.Contracts;

namespace MyFirestoreApi
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
