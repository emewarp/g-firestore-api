
using Google.Cloud.Firestore;
using MyFirestoreCrossCutting;

namespace MyFirestoreDomain
{
    public class MyFirestoreService
    {
        public FirestoreDb Db { get; private set; }

        public MyFirestoreService()
        {
            Db = MyFirestoreDb.GetFirestoreDb();
        }
    }
}
