using Google.Cloud.Firestore;

namespace MyFirestoreApi.Abstractions
{
    public interface IMyFirestoreDb
    {
        FirestoreDb GetFirestoreDb();

    }
}
