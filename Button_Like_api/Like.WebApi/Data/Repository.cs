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

        public int GetCountLikes(int idArticle)
        {
           var count =  _likeContextDb.Likes.Count(x => x.IdArticle == idArticle);

            return count;
        }

        public bool InsertLike(LikeArticle like)
        {
            _likeContextDb.Add(like);
            if(_likeContextDb.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool VerifyLike(LikeArticle like)
        {
            return _likeContextDb.Likes.Where(x => x.IdUser == like.IdUser && x.IdArticle == like.IdArticle).Any();
        }

        public bool VerifyUser(string username)
        {
             return  _applicationDbContext.Users.Where(x => x.UserName == username).Any();
        }
    }
}
