namespace MyFirestoreApi.Abstractions
{
    interface IMyFirestoreClientService
    {
        string GetClient();
        string CreateClient();
        string UpdateClient();
        bool DeleteClient();
    }
}
