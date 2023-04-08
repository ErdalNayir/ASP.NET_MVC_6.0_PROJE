using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using BulkyBookWeb.Repository.Abstract;
using System.Linq.Expressions;

namespace BulkyBookWeb.Repository.Concrete
{
    public class ProductRepository : IRepository<Product>
    {
        //DI
        private readonly ApplicationDbContext _context;

        //Constructor
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Product model)
        {
            _context.Products.Add(model);   
            _context.SaveChanges();
        }

        public void Delete(Product model)
        {
            _context.Products.Remove(model);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(Expression<Func<Product, bool>> predicate)
        {
            return _context.Products.SingleOrDefault(predicate);
        }

        public void Update(Product model)
        {
            _context.Products.Update(model);
            _context.SaveChanges();
        }
    }
}
