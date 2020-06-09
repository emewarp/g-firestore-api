using Google.Cloud.Firestore;
using MyFirestoreApi.Abstractions;
using MyFirestoreApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFirestoreApi
{
    public class MyFirestoreClientService : MyFirestoreService, IMyFirestoreClientService
    {
        
        public const string COLLECTION = "clients";

        public MyFirestoreClientService(IMyFirestoreDb db): base(db) { }

        public async Task<Client> GetClient(string clientId)
        {
            // Get db
            CollectionReference usersRef = Db.Collection(COLLECTION); 
            // Get client table
            QuerySnapshot snapshot = await usersRef.GetSnapshotAsync();
            // Get clients (snapshot.Documents)
            foreach (DocumentSnapshot documentClient in snapshot.Documents) 
            {
                if (documentClient.Id.Equals(clientId))
                {
                    Dictionary<string, object> documentClientDictionary = documentClient.ToDictionary(); //client columns
                    Client client = new Client
                    {
                        Id = clientId,
                        Name = documentClientDictionary["name"].ToString(),
                        Mail = documentClientDictionary["mail"].ToString(),
                        Phone = documentClientDictionary["phone"].ToString(),
                        Card = documentClientDictionary["card"].ToString()
                    };
                    return client;
                }                    
            }
            return null;
        }

        public async Task<bool> CreateClient(Client client)
        {
            bool created = false;
            client.Id = CreateRandomId();

            try
            {
                DocumentReference docRef = Db.Collection(COLLECTION).Document(client.Id);
                Dictionary<string, object> user = new Dictionary<string, object>
                {
                    { "name", client.Name },
                    { "mail", client.Mail },
                    { "phone", client.Phone },
                    { "card", client.Card }
                };
                
                var result = await docRef.SetAsync(user);
                if (result != null)
                    created = true;
            }
            catch(Exception e)
            {
                ///log??
            }

            return created;
        }

        public bool DeleteClient(string clientId)
        {
            throw new System.NotImplementedException();
        }

       
        public string UpdateClient(Client client)
        {
            throw new System.NotImplementedException();
        }

        private string CreateRandomId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
