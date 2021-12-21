using System;
using System.Collections.Generic;
using System.Linq;
using TodoAPI.Data;
using TodoAPI.Models;

namespace TodoAPI.Repositories.Interfaces
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public ICollection<Category> Categories()
        {
            return _context.Categories.OrderBy(n => n.CategoryName).ToList();
        }

        public Category Category(int id)
        {
            var categoryInDb = _context.Categories.SingleOrDefault(c => c.CategoryId == id);
            return categoryInDb;
        }

        public bool CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            return Save();
        }

        public bool DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ;
        }

        public bool CategoryExist(string name)
        {
            var categoriExist = _context.Categories.Any(n => n.CategoryName.ToLower().Trim() == name.ToLower().Trim());
            return categoriExist;
        }

        public bool UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            return Save();
        }
    }
}
