using Google.Cloud.Firestore;
using MyFirestoreCrossCutting;
using MyFirestoreDomain.Contracts;

namespace MyFirestoreDomain
{
    public class MyFirestoreDb : IMyFirestoreDb
    {
        public FirestoreDb GetFirestoreDb()
        {
            string project = ConfigDownloader.GetProjectName();
            return FirestoreDb.Create(project);
        }
    }
}
