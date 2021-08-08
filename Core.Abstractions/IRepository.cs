using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstractions
{
    public interface IRepository<T>
    {
        Task<T> Add(T data);
        Task<bool> Update(T data);
        Task<bool> Delete(T data);
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
    }
}
