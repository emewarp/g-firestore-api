using Google.Cloud.Firestore;
using MyFirestoreApi.Abstractions;

namespace MyFirestoreApi
{
    public class MyFirestoreDb : IMyFirestoreDb
    {
        public FirestoreDb GetFirestoreDb()
        {
            string project = "testproject-266710"; //read from json
            return FirestoreDb.Create(project);
        }
    }
}
