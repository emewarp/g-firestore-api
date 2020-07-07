using Google.Cloud.Firestore;
using MyFirestoreDomain.Contracts;

namespace MyFirestoreApi
{
    public class MyFirestoreDb : IMyFirestoreDb
    {
        public FirestoreDb GetFirestoreDb()
        {
            string project = "theviquesapp"; //read from json
            return FirestoreDb.Create(project);
        }
    }
}
