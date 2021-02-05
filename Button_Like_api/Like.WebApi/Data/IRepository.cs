using Like.WebApi.Models;
using System.Threading.Tasks;

namespace Like.WebApi.Data
{
    public interface IRepository
    {     

        Task<bool> VerifyUser(string username);
        Task<bool> InsertLike(LikeArticle like);
        Task<bool> VerifyLike(LikeArticle like);
        Task<int> GetCountLikes(int idArticle);
      
    }
}
