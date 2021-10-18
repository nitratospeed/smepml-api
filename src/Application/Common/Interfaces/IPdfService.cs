namespace Application.Common.Interfaces
{
    public interface IPdfService
    {
        byte[] GetPdf(string html);
    }
}
