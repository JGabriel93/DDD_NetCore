using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MyContext _context;
        private DbSet<T> _dataset;
        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(d => d.Id.Equals(id));
                if (result == null)
                    throw new Exception("Registro não encontrado");

                _dataset.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Ocorreu um erro");
            }
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dataset.AnyAsync(x => x.Id.Equals(id));
        }

        public async Task<Guid> InsertAsync(T entity)
        {
            try
            {
                if (entity.Id == Guid.Empty)
                {
                    entity.Id = Guid.NewGuid();
                }

                _dataset.Add(entity);

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception("Ocorreu um erro");
            }

            return entity.Id;
        }

        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(d => d.Id.Equals(id));
                if (result == null)
                    throw new Exception("Registro não encontrado");

                return result;
            }
            catch (Exception)
            {
                throw new Exception("Ocorreu um erro");
            }
        }

        public async Task<IEnumerable<T>> SelectAllAsync()
        {
            try
            {
                return await _dataset.ToListAsync();
            }
            catch (Exception)
            {
                throw new Exception("Ocorreu um erro");
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(d => d.Id.Equals(entity.Id));
                if (result == null)
                    throw new Exception("Registro não encontrado");

                entity.UpdateAt = DateTime.UtcNow;
                entity.CreateAt = result.CreateAt;

                _context.Entry(result).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new Exception("Ocorreu um erro");
            }

            return entity;
        }
    }
}
