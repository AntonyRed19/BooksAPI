using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookTask.Entities;

namespace BookTask.Services.Abstractions
{
    public interface IBookManageService
    {
        Task<bool> CreateAsync(int id, string title, string description);
        Task<bool> UpdateAsync(int id, string title, string description);
        Task<bool> DeleteAsync(int id);
        Task<BookEntity> GetByIdAsync(int id);
    }
}
