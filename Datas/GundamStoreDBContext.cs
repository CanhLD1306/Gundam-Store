using GundamStore.Models;
using Microsoft.EntityFrameworkCore;

namespace GundamStore.Datas
{
    public class GundamStoreDBContext : DbContext
    {
        public GundamStoreDBContext(DbContextOptions<GundamStoreDBContext> options) : base(options)
        {

        }

        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Size>? Sizes { get; set; }

        public DbSet<Banner>? Banners { get; set; }
        public DbSet<ProductImage>?  ProductImages { get; set; }

    }
}
