using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WorldCup1.Models;

namespace WorldCup1.Operations.Abstract
{
        public interface IBaseOperation<T> where T : BaseModel, new()
        {
            void Add(T item);
            void Delete(T item);
            void Update(T item);
            List<T> GetAll();
            T Get(int id);
            int GetNextId();
        }
    
}
