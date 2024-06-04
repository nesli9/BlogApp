using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Mvc;
using BlogApp.Models;

namespace BlogApp.Controllers{
    public class PostsController : Controller
    {
        private IPostRepository _postRepository;
        private ITagRepository _tagRepository;

        public PostsController(IPostRepository postRepository ){
            _postRepository = postRepository; //inject yöntemiyle nesne oluşturulması sağlanır
        }
        public IActionResult Index(){
            return View(
                new PostsViewModel{
                    Posts = _postRepository.Posts.ToList()
                }
            );
        }
    }
}