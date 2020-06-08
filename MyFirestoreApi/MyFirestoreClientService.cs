using MyFirestoreApi.Abstractions;

namespace MyFirestoreApi
{
    public class MyFirestoreClientService : IMyFirestoreClientService
    {
        private IMyFirestoreDb _db;

        public MyFirestoreClientService(IMyFirestoreDb db)
        {
            _db = db;
        }

        public string CreateClient()
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteClient()
        {
            throw new System.NotImplementedException();
        }

        public string GetClient()
        {
            throw new System.NotImplementedException();
        }

        public string UpdateClient()
        {
            throw new System.NotImplementedException();
        }
    }
}
