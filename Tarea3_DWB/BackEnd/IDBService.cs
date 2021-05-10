using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea3_DWB.BackEnd
{
    public interface IDBService<T> where T: class
    {
        //Internal Database Service
        public List<T> Get();
        public T Get(object id);
        public void Add(T newElement);
        public void Update(Object id, T elementForUpdate);
        public void Delete(Object id);
    }
}
