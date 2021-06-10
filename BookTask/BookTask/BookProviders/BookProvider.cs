using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookTask.BookProviders.Abstractions;
using BookTask.Entities;

namespace BookTask.BookProviders
{
    public class BookProvider : IBookProvider
    {
        private readonly List<BookEntity> _entities = new List<BookEntity>();
        public async Task<bool> CreateAsync(int id, string title, string desc)
        {
            return await Task.Run(() =>
            {
                _entities.Add(new BookEntity()
                {
                    Id = id,
                    Title = title,
                    Description = desc
                });
                return true;
            });
        }

        public async Task<bool> UpdateAsync(int id, string title, string desc)
        {
            return await Task.Run(() =>
            {
                var entity = _entities.FirstOrDefault(f => f.Id == id);
                if (entity == null)
                {
                    return false;
                }

                entity.Title = title;
                entity.Description = desc;
                return true;
            });
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (id == 0)
            {
                return false;
            }

            return await Task.Run(() =>
            {
                var entity = _entities.FirstOrDefault(f => f.Id == id);
                if (entity == null)
                {
                    return false;
                }

                return _entities.Remove(entity);
            });
        }

        public async Task<BookEntity> GetByIdAsync(int id)
        {
            return await Task.Run(() =>
            {
                return _entities.FirstOrDefault(f => f.Id == id);
            });
        }
    }
}
