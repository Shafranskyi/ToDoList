using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.Models.EF;
using ToDoList.Models.Entities;
using ToDoList.Models.Interfaces;

namespace ToDoList.Models.Repositories
{
    public class ClientManager : IClientManager
    {
        public ApplicationContext Database { get; set; }
        public ClientManager(ApplicationContext db)
        {
            Database = db;
        }

        public void Create(ClientProfile item)
        {
            Database.ClientProfiles.Add(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}