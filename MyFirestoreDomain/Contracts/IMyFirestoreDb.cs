using Google.Cloud.Firestore;

namespace MyFirestoreDomain.Contracts
{
    public interface IMyFirestoreDb
    {
        FirestoreDb GetFirestoreDb();

    }
}
