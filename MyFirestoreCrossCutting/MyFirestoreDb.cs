using Google.Cloud.Firestore;

namespace MyFirestoreCrossCutting
{
    public static class MyFirestoreDb 
    {
        public static FirestoreDb GetFirestoreDb()
        {
            string project = ConfigDownloader.GetProjectName();
            return FirestoreDb.Create(project);
        }
    }
}
