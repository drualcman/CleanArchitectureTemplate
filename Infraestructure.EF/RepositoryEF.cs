using Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.EF
{
    public class RepositoryEF<T> : IRepository<T> where T : class
    {
        private readonly ZionDbContext Context;
        public RepositoryEF(ZionDbContext context)
        {
            Context = context;
        }

        public async Task<T> Add(T data)
        {
            await Context.AddAsync(data);
            await Context.SaveChangesAsync();
            return data;
        }

        public Task<bool> Delete(T data)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(T data)
        {
            throw new NotImplementedException();
        }
    }
}
