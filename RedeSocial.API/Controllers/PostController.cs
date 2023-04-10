using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.ObjectModelRemoting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using RedeSocial.Domain.Entities;
using RedeSocial.Domain.Interfaces.Services;
using RedeSocial.Domain.Services;
using RedeSocial.Infrastructure.Context;

namespace RedeSocial.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        // GET: api/Post
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostEntity>>> GetPosts()
        {
          if (_postService == null)
          {
              return NotFound();
          }
            var posts = await _postService.GetAllAsync();
            return posts.ToList();

        }

        // GET: api/Post/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostEntity>> GetPostEntity(int id)
        {
          if (_postService == null)
          {
              return NotFound();
          }
            var postEntity = await _postService.GetByIdAsync(id);

            if (postEntity == null)
            {
                return NotFound();
            }

            return postEntity;
        }

        // PUT: api/Post/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutPostEntity(int id, PostEntity postEntity)
        {
            if (id != postEntity.Id)
            {
                return BadRequest();
            }

            await _postService.UpdateAsync(postEntity);

            return NoContent();
        }

        // POST: api/Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<PostEntity>> PostPostEntity(PostEntity postEntity)
        {
          if (_postService == null)
          {
              return Problem("Context é nulo!");


          }
            await _postService.Send(postEntity);
            return CreatedAtAction("GetPostEntity", new { id = postEntity.Id }, postEntity);
        }

        //private async Task<string> Upload(IFormFile file)
       // {
        //    var connectionString = "DefaultEndpointsProtocol=https;AccountName=storagesamplescrete;AccountKey=kdy+UEYulhU5yD5jmkDQQT6gnv0/SiaJubqcH5JEogh8pXZxPSfEmS3YHKZk2c7bW/kpz6Agk4iN+AStJCBIlg==;EndpointSuffix=core.windows.net"; //_configuration["StorageConfiguration:ConnectionString"];
        //    var containerName = "redesocial";//_configuration["StorageConfiguration:ContainerName"];

        //    BlobContainerClient container = new BlobContainerClient(connectionString, containerName);

         //   BlobClient blob = container.GetBlobClient(file.FileName);

         //   await blob.UploadAsync(file.OpenReadStream(), true);

        //    return blob.Uri.AbsoluteUri.ToString();
       // }


        // DELETE: api/Post/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PostEntity>> DeletePostEntity(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var postEntity = await _postService.GetByIdAsync(id);
            if (postEntity == null)
            {
                return NotFound();
            }
            await _postService.DeleteAsync(id);

            return postEntity;

        }

    }
}
