using Microsoft.EntityFrameworkCore;

namespace UnitTest.API.Models
{
    public interface IUnitTestAPIContext
    {
        DbSet<Product> Products { get; }
        int SaveChanges();
        void MarkAsModified(Product item);
    }
}
