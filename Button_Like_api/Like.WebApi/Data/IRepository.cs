using Like.WebApi.Models;


namespace Like.WebApi.Data
{
    public interface IRepository
    {     

        bool VerifyUser(string username);
        bool InsertLike(LikeArticle like);
        bool VerifyLike(LikeArticle like);
        int GetCountLikes(int idArticle);
      
    }
}
