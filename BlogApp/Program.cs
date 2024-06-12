using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete;
using BlogApp.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BlogContext>(options =>{
    options.UseSqlite(builder.Configuration["ConnectionStrings:Sql_connection"]);
    
});

builder.Services.AddScoped<IPostRepository ,EfPostRepository>();
builder.Services.AddScoped<ITagRepository ,EfTagRepository>();
builder.Services.AddScoped<ICommentRepository ,EfCommentRepository>(); //ICommentRepository çağrıldığı zaman , EfCommentRepository versiyonu nesne olarak oluşturulup geri gönderilir.


var app = builder.Build();

app.UseStaticFiles();

SeedData.TestVerileriniDoldur(app);

//localhost://posts/react-dersleri gibi bir url yapısı 
//localhost://posts/php-dersleri

app.MapControllerRoute(
    name : "post_details",
    pattern : "posts/details/{url}",
    defaults : new {controller = "Posts", action = "Details"} //sayfanın yönlendireceği yer
);

app.MapControllerRoute(
    name : "posts_by_tag",
    pattern : "posts/tag/{tag}",
    defaults : new {controller = "Posts", action = "Index"} //sayfanın yönlendireceği yer
);

app.MapControllerRoute( //yukarıdaki url ler dışında bir url varsa bu kısım ele alınır
    name : "default", 
    pattern : "{controller=Home}/{action=Index}/{id?}"
);

app.Run(); 
