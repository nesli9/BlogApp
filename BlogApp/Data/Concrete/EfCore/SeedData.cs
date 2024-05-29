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
                        context.Database.Migrate();
                    }
                    if (!context.Tags.Any())
                    {
                        context.Tags.AddRange(
                            new Tag {Text = "web programlama"},
                            new Tag {Text = "backend"},
                            new Tag {Text = "frontend"},
                            new Tag {Text = "fulllstack"},
                            new Tag {Text = "php"}
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
                                IsActive = true,
                                PublishedOn = DateTime.Now.AddDays(-10),
                                Tags = context.Tags.Take(3).ToList(),
                                UserId = 1
                            },
                            new Post {
                                Title = "PHP",
                                Content = "PHP dersleri",
                                IsActive = true,
                                PublishedOn = DateTime.Now.AddDays(-20),
                                Tags = context.Tags.Take(2).ToList(),
                                UserId = 1
                            },
                            new Post {
                                Title = "Django",
                                Content = "Django dersleri",
                                IsActive = true,
                                PublishedOn = DateTime.Now.AddDays(-5),
                                Tags = context.Tags.Take(4).ToList(),
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
