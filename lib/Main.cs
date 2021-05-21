using System;
using PdfSharpCore;
using RazorEngineCore;
using VetCV.HtmlRendererCore.PdfSharpCore;

namespace lib
{
    public class ViewModel
    {
        public string Name { get; set; }
    }
    public class RazorHtmlToPdfLib
    {
        public static void MakePdf<T>(string template, T model, string filename = "test.pdf")
        {
            var engine = new RazorEngine();
            var compiledTemplate = engine.Compile(template);

            var templateResult = compiledTemplate.Run(model);

            var pdf = PdfGenerator.GeneratePdf(templateResult, PageSize.A4);
            
            pdf.Save(filename);
        }
    }
}
