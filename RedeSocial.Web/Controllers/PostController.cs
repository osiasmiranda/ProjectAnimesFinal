using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using RedeSocial.Domain.Entities;
using RedeSocial.Domain.Interfaces.Services;
using RedeSocial.Domain.Services;
using RedeSocial.Infrastructure.Context;
using RedeSocial.Web.Models;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace RedeSocial.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly RedeDbContext _context;
        private readonly IPostService _postService;
        private readonly IFileService _fileService;
        private readonly UserManager<ProfileEntity> _userManager;

        public PostController(IPostService postService,
            IFileService fileService,
            UserManager<ProfileEntity> userManager,
            RedeDbContext context)
        {
            _postService = postService;
            _context = context;
            _fileService = fileService;
            _userManager = userManager;
        }

        // GET: Post
        public async Task<IActionResult> Index()
        {
            var post = await _postService.GetAllAsync();
            if (post == null)
            {
                return Redirect("Login");
            }
            return View(post.OrderByDescending(post => post.PublishDateTime));
        }

        // GET: Post/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound("Publicação não encontrada.");
            }
            var post = await _postService.GetByIdAsync(id.Value);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);

        }

        // GET: Post/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostEntity postEntity)
        {
            if (!ModelState.IsValid)
            {
                return View(postEntity);
            }
            if (postEntity.ImageFile != null)
            {
                var fileResult = _fileService.SaveImage(postEntity.ImageFile);
                if (fileResult.Item1 == 0)
                {
                    TempData["msg"] = "O arquivo não pôde ser salvo!";
                    return View(postEntity);
                }
                var imageName = fileResult.Item2;
                postEntity.PostUrlImage = imageName;
                postEntity.UserEmail = User.Identity!.Name;
                postEntity.PublishDateTime = DateTime.Now;
            }

             await _postService.Send(postEntity);

            if (ModelState.IsValid)
            {
                TempData["msg"] = "Adicionado com sucesso.";
                return RedirectToAction(nameof(Index));

            }
            else
            {
                TempData["msg"] = "Erro no lado do servidor";
                return View(postEntity);
            }
        }
        private async Task<string> Upload(IFormFile file)
        {
            var connectionString = "DefaultEndpointsProtocol=https;AccountName=storagesamplescrete;AccountKey=kdy+UEYulhU5yD5jmkDQQT6gnv0/SiaJubqcH5JEogh8pXZxPSfEmS3YHKZk2c7bW/kpz6Agk4iN+AStJCBIlg==;EndpointSuffix=core.windows.net"; //_configuration["StorageConfiguration:ConnectionString"];
            var containerName = "redesocial";//_configuration["StorageConfiguration:ContainerName"];

            BlobContainerClient container = new BlobContainerClient(connectionString, containerName);

            BlobClient blob = container.GetBlobClient(file.FileName);

            await using (Stream? data = file.OpenReadStream())
            {
                await blob.UploadAsync(data);
            };

            return blob.Uri.AbsoluteUri.ToString();
        }

        // GET: Post/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var post = await _postService.GetByIdAsync(id.Value);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);

        }

        // POST: Post/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,PostUrlImage,AuthorId")] PostEntity postEntity)
        {

            if (!ModelState.IsValid)
            {
                return View(postEntity);
            }
            if (postEntity.ImageFile != null)
            {
                var fileResult = _fileService.SaveImage(postEntity.ImageFile);
                if (fileResult.Item1 == 0)
                {
                    TempData["msg"] = "O arquivo não pôde ser salvo!";
                    return View(postEntity);
                }
                var imageName = fileResult.Item2;
                postEntity.PostUrlImage = imageName;
            }

            await _postService.UpdateAsync(postEntity);

            if (ModelState.IsValid)
            {
                TempData["msg"] = "Adicionado com sucesso.";
                return RedirectToAction(nameof(Index));

            }
            else
            {
                TempData["msg"] = "Erro no lado do servidor";
                return View(postEntity);
            }

            //if (id != postEntity.Id)
            //{
            //    return NotFound();
            //}

            // if (ModelState.IsValid)
            //{
            //   try
            // {
            //     await _postService.UpdateAsync(postEntity);
            // }
            //catch (DbUpdateConcurrencyException)
            //{
            //  if (!PostEntityExists(postEntity.Id))
            //{
            //     return NotFound();
            //}
            // else
            //{
            //    throw;
            // }
            //}
            // return RedirectToAction(nameof(Index));
            //}
            //return View(postEntity);
        }

        // GET: Post/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var post = await _postService.GetByIdAsync(id.Value);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _postService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool PostEntityExists(int id)
        {
            return (_context.Posts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
