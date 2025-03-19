using Microsoft.EntityFrameworkCore;
using Webbanhang.DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Webbanhang.Repositories
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public EFCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lấy tất cả danh mục
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var categories = await _context.Categories.ToListAsync();

            if (categories == null || !categories.Any())
            {
                throw new Exception("No categories found in the database.");
            }

            return categories;
        }


        // Lấy danh mục theo Id
        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        // Thêm danh mục mới
        public async Task AddAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        // Cập nhật danh mục
        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        // Xóa danh mục theo Id
        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}
