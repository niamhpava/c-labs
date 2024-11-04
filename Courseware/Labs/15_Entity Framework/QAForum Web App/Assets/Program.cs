using Microsoft.EntityFrameworkCore;
using QAForum.EF;
using QAForum.Models;
using System;
using System.Linq;

namespace SeedDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ForumDbContext>();
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Forum.Data;Trusted_Connection=True;");
            using(ForumDbContext ctx = new ForumDbContext(optionsBuilder.Options))
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.Migrate();
                InitForums(ctx);
            }
        }

        static void InitForums(ForumDbContext ctx)
        {

            // Add three users all with the same password and name = username
            string userName_Paul = "Paul@testing.com";
            string userName_Admin = "admin@testing.com";
            string userName_Moderator = "moderator@testing.com";

            // Add some Forums 
            string forumTitle_AspNetMVC = "ASP.NET MVC";
            string forumTitle_AspNetAjax = "ASP.NET AJAX";
            string forumTitle_AspNetWebForms = "ASP.NET WebForms";
            string forumTitle_Jquery = "jQuery";
            string forumTitle_Silverlight = "Silverlight";
            string forumTitle_VS2019 = "Visual Studio 2019";
            string forumTitle_Wpf = "Windows Presentation Foundation - WPF";

            Forum AspNetMVC = AddForum(ctx, forumTitle_AspNetMVC);
            Forum AspNetAjax = AddForum(ctx, forumTitle_AspNetAjax);
            Forum AspNetWebForms = AddForum(ctx, forumTitle_AspNetWebForms);
            Forum Jquery = AddForum(ctx, forumTitle_Jquery);
            Forum Silverlight = AddForum(ctx, forumTitle_Silverlight);
            Forum VS2019 = AddForum(ctx, forumTitle_VS2019);
            Forum Wpf = AddForum(ctx, forumTitle_Wpf);


            // Add some Threads
            string threadTitle_SoWhatsNewInMVC = "So what's new in MVC Core?";
            string threadTitle_MvcFrameworkVsCore = "What are the changes between MVC Framework and Core?";
            string threadTitle_UseAJAXWithMVC = "Can I use the AJAX Control Toolkit with ASP.NET MVC ?";
            string threadTitle_UseExistingWebFormAssets = "Can I reuse any of my existing ASP.NET Webform assets if I migrate to ASP.NET MVC ?";
            string threadTitle_DifferenceAjaxJQuery = "What is the difference between Ajax Control Toolkit and jQueryUI ?";
            string threadTitle_CombineSilverlightAndMVC = "Can I combine Silverlight and ASP.NET MVC ?";
            string threadTitle_CannnotSeeMVC5Template = "Why can't I see the MVC5 template in Visual Studio 2019 ?";
            string threadTitle_MigrateWPFToSilverlight = "Can I migrate my WPF application to Silverlight ?";

            QAForum.Models.Thread? SoWhatsNewInMVC = AddThread(ctx, AspNetMVC, threadTitle_SoWhatsNewInMVC, userName_Paul);
            QAForum.Models.Thread? MvcFrameworkVsCore = AddThread(ctx, AspNetMVC, threadTitle_MvcFrameworkVsCore, userName_Paul);
            QAForum.Models.Thread? UseAJAXWithMVC = AddThread(ctx, AspNetAjax, threadTitle_UseAJAXWithMVC, userName_Admin);
            QAForum.Models.Thread? UseExistingWebFormAssets = AddThread(ctx, AspNetWebForms, threadTitle_UseExistingWebFormAssets, userName_Admin);
            QAForum.Models.Thread? DifferenceAjaxJQuery = AddThread(ctx, Jquery, threadTitle_DifferenceAjaxJQuery, userName_Admin);
            QAForum.Models.Thread? CombineSilverlightAndMVC = AddThread(ctx, Silverlight, threadTitle_CombineSilverlightAndMVC, userName_Admin);
            QAForum.Models.Thread? CannnotSeeMVC5Template = AddThread(ctx, VS2019, threadTitle_CannnotSeeMVC5Template, userName_Admin);
            QAForum.Models.Thread? MigrateWPFToSilverlight = AddThread(ctx, Wpf, threadTitle_MigrateWPFToSilverlight, userName_Admin);


            // Add some Posts
            AddPost(ctx,
                    "Blazer in MVC Core 3",
                    "MVC Core 3 includes support for Blazer client-side applications, as well as lots of other new features",
                    -2, // <== 2 days ago
                    SoWhatsNewInMVC, userName_Paul);
            
            AddPost(ctx,
                    "gRPC in MVC Core 3",
                    "One of the great new features in Core 3 is gRPC, which allows remote procedure calls using modern technologies",
                    -2, // <== 2 days ago
                    SoWhatsNewInMVC, userName_Paul);

            AddPost(ctx,
                    "Key differences between Framework and Core",
                    "MVC Core is a complete re-write, from the ground up, so a lot of things have changed. Read here for more details!",
                    -2, // <== 2 days ago
                    MvcFrameworkVsCore, userName_Paul);

            AddPost(ctx,
                    "Using the AJAX Control Toolkit",
                    "Our current WebForms site uses the Chart control. Can I use it in MVC ?",
                    -4, // <== 4 days ago
                    UseAJAXWithMVC, userName_Paul);

            AddPost(ctx,
                    "Asset reuse",
                    "ASP.NET MVC 5 builds on ASP.NET MVC 3 and 4, adding great features that both simplify your code and allow deeper extensibility. This topic provides an overview of many of the new features that are included in this release, organized into the following sections:",
                    -5, // <== 5 days ago
                    UseExistingWebFormAssets, userName_Paul);

            AddPost(ctx,
                    "Ajax Control Toolkit description",
                    "I am familiar with the Ajax Control Toolkit but I am hearning a lot of talk about jQueryUI. What is the difference ?",
                    -5, // <== 5 days ago
                    DifferenceAjaxJQuery, userName_Paul);

            AddPost(ctx,
                    "Combining Silverlight and ASP.NET MVC",
                    "I get the impression that migrating to MVC could be quite tricky. Is there a simple way of combining my existing WebForm assets with the new MVC content ?",
                    -3, // <== 3 days ago
                    CombineSilverlightAndMVC, userName_Paul);

            AddPost(ctx,
                    "MVC5 and Visual Studio 2019",
                    "I have just installed Visual Studio 2019 Professional but cannot locate the MVC 5 project template. What am I doing wrong ?",
                    -4, // <== 4 days ago
                    CannnotSeeMVC5Template, userName_Moderator);

            AddPost(ctx,
                    "WPF applications and Silverlight",
                    "I have an application that I developed in WPF. I would like to convert it to run as a Silverlight application. Is there a wizard that I can use ?",
                    -2, // <== 2 days ago
                    MigrateWPFToSilverlight, userName_Moderator);

            ctx.SaveChanges();
        }

        static Forum AddForum(ForumDbContext context, string title)
        {
            context.Forums.Add(
                new Forum
                {
                    Title = title
                });
            context.SaveChanges();
            return context.Forums.Single(f => f.Title == title);
        }
        static QAForum.Models.Thread AddThread(ForumDbContext context, Forum forum, string threadTitle, string userName)
        {
            context.Threads.Add(new QAForum.Models.Thread
            {
                Title = threadTitle,
                Forum = forum,
                UserName = userName
            });
            context.SaveChanges();
            return context.Threads.Single(f => f.Title == threadTitle);
        }
        static void AddPost(ForumDbContext context, string postTitle, string postBody, int dateOffset, QAForum.Models.Thread thread, string userName)
        {
            context.Posts.Add(
                new Post
                {
                    Title = postTitle,
                    Thread = thread,
                    UserName = userName,
                    PostBody = postBody,
                    PostDateTime = DateTime.Now.AddDays(dateOffset)
                });
        }
    }
}
