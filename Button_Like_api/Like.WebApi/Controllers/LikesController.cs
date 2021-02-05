﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Like.WebApi.Context;
using Like.WebApi.Data;
using Like.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Like.WebApi.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly IRepository _repository;
        public LikesController(IRepository repository)
        {
            _repository = repository;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("{idArticle}")]
        public ActionResult<int> Get(int idArticle)
        {
            try
            {
                return _repository.GetCountLikes(idArticle);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public ActionResult<bool> Post(LikeArticle like)
        {
            if (!_repository.VerifyLike(like))
            {
                if (_repository.InsertLike(like))
                {
                    return true;
                }
                else
                {
                    return BadRequest("Não foi possível inserir like");
                }
            }
            else
            {
                return BadRequest("Like já inserido por esse usuário");
            }

        }

    }
}