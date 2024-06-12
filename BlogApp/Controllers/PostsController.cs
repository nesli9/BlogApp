using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Mvc;
using BlogApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Controllers{
    public class PostsController : Controller
    {
        private IPostRepository _postRepository;
        private ITagRepository _tagRepository;

        public PostsController(IPostRepository postRepository ){
            _postRepository = postRepository; //inject yöntemiyle nesne oluşturulması sağlanır
        }
        public async Task<IActionResult> Index(string tag){

            var posts = _postRepository.Posts;

            if (!string.IsNullOrEmpty(tag))
            {
                posts = posts.Where(x => x.Tags.Any(t => t.Url == tag)); //gönderilen tagle eşleşen bir kayıt varsa geri dönen kayda alınır
            }
            return View(new PostsViewModel {Posts = await posts.ToListAsync()});
            
        }
        public async Task<IActionResult> Details(string url){
            return View( await _postRepository
                                .Posts
                                .Include(x => x.Tags) //tag sorgusu 
                                .Include(x => x.Comments) //gidilen comment
                                .ThenInclude(x => x.User)//gidilen entity içerisinde extra sorgu yazılır (her gidilen commentın user bilgisi yazdırılır.)
                                .FirstOrDefaultAsync(p => p.Url == url));
        }
        public IActionResult AddComment(int PostId , string UserName ,string Text){
            return View();

        }

    }
}