using Application.Common.Interfaces;
using SelectPdf;

namespace Infrastructure.Services
{
    public class PdfService : IPdfService
    {
        public byte[] GetPdf(string html)
        {
            HtmlToPdf htmlToPdf = new HtmlToPdf();
            htmlToPdf.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
            htmlToPdf.Options.MarginLeft = 15;
            htmlToPdf.Options.MarginRight = 15;

            PdfDocument pdfDocument = htmlToPdf.ConvertHtmlString(html);

            var pdf = pdfDocument.Save();

            return pdf;
        }
    }
}
