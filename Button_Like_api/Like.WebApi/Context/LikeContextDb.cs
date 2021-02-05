using Like.WebApi.Models;
using Microsoft.EntityFrameworkCore;



namespace Like.WebApi.Context
{
    public class LikeContextDb : DbContext
    {
        public LikeContextDb(DbContextOptions<LikeContextDb> options) : base(options) { }

        public DbSet<LikeArticle> Likes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        
       
        builder.Entity<LikeArticle>().
            HasKey(LA => LA.IdLike);
        builder.Entity<LikeArticle>().Property(LA => LA.IdLike).ValueGeneratedOnAdd();

    }
}

}

