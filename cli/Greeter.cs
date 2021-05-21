using System;
using Cocona;
using lib;
using RazorEngineCore;

namespace cli
{
    public class ViewModel
    {
        public string Name { get; set; }
    }

    public class CommentModel
    {
        public string Nickname { get; set; }
        public string Content { get; set; }
    }
    partial class Program
    {
        [Command("greet")]
        public void Hello(bool hey, [Argument] string name, string filename = "hello.pdf")
        {
            var template = $"<h1>{(hey ? "Hey" : "Hello")}</h1><p>Your name is: @Model.Name</p>";
            var model = new ViewModel
            {
                Name = name
            };
            
            RazorHtmlToPdfLib.MakePdf(template, model, filename);
        }

        [Command("comment")]
        public void Comment(string filename, [Argument] string nick, [Argument] string comment)
        {
            var template = $"<h1>Comment from @Model.Nickname</h1><p>@Model.Content</p>";
            var model = new CommentModel
            {
                Nickname = nick,
                Content = comment
            };
            
            RazorHtmlToPdfLib.MakePdf(template, model, filename);
        }
    }
}