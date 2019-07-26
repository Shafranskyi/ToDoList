using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.Models.Entities;

namespace ToDoList.Models.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void Create(ClientProfile item);
    }
}