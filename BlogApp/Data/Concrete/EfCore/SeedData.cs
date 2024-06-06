using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore{
    public static class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app){
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<BlogContext>();

                if (context != null)
                {
                    if (context.Database.GetPendingMigrations().Any())
                    {
                        context.Database.Migrate(); //database update etme kodu (watch ile çalıştırılınca vt güncellenir)
                    }
                    if (!context.Tags.Any())
                    {
                        context.Tags.AddRange(
                            new Tag {Text = "web programlama",Url="web-programlama"},
                            new Tag {Text = "backend", Url="backend"},
                            new Tag {Text = "frontend" ,Url="frontend"},
                            new Tag {Text = "fulllstack" ,Url="fullstack"},
                            new Tag {Text = "php",Url="php"}
                        );
                        context.SaveChanges();
                    }

                    if (!context.Users.Any())
                    {
                        context.Users.AddRange(
                            new User {UserName ="sadikturan"},
                            new User {UserName ="ahmetyilmaz"}
                        );
                        context.SaveChanges();
                    }
                    if (!context.Posts.Any())
                    {
                        context.Posts.AddRange(
                            new Post {
                                Title = "Asp.net core",
                                Content = "App.net core dersleri",
                                Url = "aspnet-core",
                                IsActive = true,
                                PublishedOn = DateTime.Now.AddDays(-10),
                                Tags = context.Tags.Take(3).ToList(),
                                Image="1.jpg",
                                UserId = 1
                            },
                            new Post {
                                Title = "PHP",
                                Content = "PHP dersleri",
                                Url = "php",
                                IsActive = true,
                                PublishedOn = DateTime.Now.AddDays(-20),
                                Tags = context.Tags.Take(2).ToList(),
                                Image="2.jpg",
                                UserId = 1
                            },
                            new Post {
                                Title = "Django",
                                Content = "Django dersleri",
                                Url = "django",
                                IsActive = true,
                                PublishedOn = DateTime.Now.AddDays(-30),
                                Tags = context.Tags.Take(4).ToList(),
                                Image="3.jpg",
                                UserId = 2
                            },
                            new Post {
                                Title = "React",
                                Content = "React dersleri",
                                Url = "react",
                                IsActive = true,
                                PublishedOn = DateTime.Now.AddDays(-5),
                                Tags = context.Tags.Take(4).ToList(),
                                Image="3.jpg",
                                UserId = 2
                            },
                            new Post {
                                Title = "Angular",
                                Content = "Angular dersleri",
                                Url = "angular",
                                IsActive = true,
                                PublishedOn = DateTime.Now.AddDays(-40),
                                Tags = context.Tags.Take(4).ToList(),
                                Image="3.jpg",
                                UserId = 2
                            },
                            new Post {
                                Title = "Web Tasarım",
                                Content = "Web Tasarım dersleri",
                                Url = "web-tasarim",
                                IsActive = true,
                                PublishedOn = DateTime.Now.AddDays(-50),
                                Tags = context.Tags.Take(4).ToList(),
                                Image="3.jpg",
                                UserId = 2
                            }
                        );
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
