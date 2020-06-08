namespace MyFirestoreApi.Abstractions
{
    interface IMyFirestoreService
    {
        string GetClient();
        string CreateClient();
        string UpdateClient();
        bool DeleteClient();
    }
}
