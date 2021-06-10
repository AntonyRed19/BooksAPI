using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookTask.BookProviders.Abstractions;
using BookTask.Entities;
using BookTask.Services.Abstractions;

namespace BookTask.Services
{
    public class BookManageService : IBookManageService
    {
        private readonly IBookProvider _bookProvider;
        public BookManageService(IBookProvider bookProvider)
        {
            _bookProvider = bookProvider;
        }

        public async Task<int> CreateAsync(string title, string description)
        {
            return await _bookProvider.CreateAsync(title, description);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _bookProvider.DeleteAsync(id);
        }

        public async Task<BookEntity> GetByIdAsync(int id)
        {
            return await _bookProvider.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, string title, string description)
        {
            return await _bookProvider.UpdateAsync(id, title, description);
        }
    }
}
