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

        #region Public Methods
        public async Task<List<Client>> GetAllClients()
        {
            List <Client> clients = new List<Client>();
            QuerySnapshot snapshot = await GetClientSnapshot();
            foreach (DocumentSnapshot documentClient in snapshot.Documents) // Get clients (snapshot.Documents)
            {
                clients.Add(GetClient(documentClient));
            }
            return clients;
        }
        public async Task<Client> GetClientById(string clientId)
        {
            QuerySnapshot snapshot = await GetClientSnapshot();            
            foreach (DocumentSnapshot documentClient in snapshot.Documents) // Get clients (snapshot.Documents)
            {
                if (documentClient.Id.Equals(clientId))
                {
                    return GetClient(documentClient);
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
                    { "id", client.Id },
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
                // tdo 
            }

            return created;
        }

        public async Task<bool> DeleteClient(string clientId)
        {
            bool deleted = false;

            try
            {
                DocumentReference cityRef = Db.Collection(COLLECTION).Document(clientId);
                // Delete document does NOT delete subcollections, we have to delete them separately
                Dictionary<string, object> updates = new Dictionary<string, object>
                {
                     { "name", FieldValue.Delete },
                     { "mail", FieldValue.Delete },
                     { "phone", FieldValue.Delete },
                     { "card", FieldValue.Delete }
                };
                await cityRef.UpdateAsync(updates); //update collection deleting fields
                await cityRef.DeleteAsync(); //delete collection
                
                deleted = true;
            }
            catch(Exception e)
            {
                //todo
            }            

            return deleted;
        }

       
        public string UpdateClient(Client client)
        {
            throw new System.NotImplementedException();
        }

       #endregion

        #region Private Methods
        private Client GetClient(DocumentSnapshot documentClient)
        {
            Dictionary<string, object> documentClientDictionary = documentClient.ToDictionary(); //client columns
            Client client = new Client
            {
                Id = documentClientDictionary["id"].ToString(),
                Name = documentClientDictionary["name"].ToString(),
                Mail = documentClientDictionary["mail"].ToString(),
                Phone = documentClientDictionary["phone"].ToString(),
                Card = documentClientDictionary["card"].ToString()
            };
            return client;
        }
        private async Task<QuerySnapshot> GetClientSnapshot()
        {            
            CollectionReference usersRef = Db.Collection(COLLECTION); // Get db           
            QuerySnapshot snapshot = await usersRef.GetSnapshotAsync(); // Get client table

            return snapshot;
        }
        private string CreateRandomId()
        {
            return Guid.NewGuid().ToString();
        }
        #endregion
    }
}
