using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Like.WebApi.Models
{
    public class LikeArticle
    {
        public LikeArticle()
        {

        }

        public LikeArticle(int idUser, int idArticle)
        {
            this.IdUser = idUser;
            this.IdArticle = idArticle;
        }
        [Key]
        public int IdLike { get; set; }
        public int IdUser { get; set; }
        public int IdArticle { get; set; }

    }
}
