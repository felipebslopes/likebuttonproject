using Like.WebApi.Context;
using Like.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Like.WebApi.Data
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly LikeContextDb _likeContextDb;
        public Repository (ApplicationDbContext applicationDbContext, LikeContextDb likeContextDb)
        {
            this._applicationDbContext = applicationDbContext;
            this._likeContextDb = likeContextDb;
        }

        public async Task<int> GetCountLikes(int idArticle)
        {
           var count = await Task.Run(() =>  _likeContextDb.Likes.Count(x => x.IdArticle == idArticle));

            return count;
        }

        public async Task<bool> InsertLike(LikeArticle like)
        {
            _likeContextDb.Add(like);
            if(await Task.Run(()=> _likeContextDb.SaveChanges() > 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async  Task<bool>  VerifyLike(LikeArticle like)
        {
            return await Task.Run(()=> _likeContextDb.Likes.Where(x => x.IdUser == like.IdUser && x.IdArticle == like.IdArticle).Any());
        }

        public async Task<bool> VerifyUser(string username)
        {
             return await Task.Run(()=> _applicationDbContext.Users.Where(x => x.UserName == username).Any());
        }
    }
}
