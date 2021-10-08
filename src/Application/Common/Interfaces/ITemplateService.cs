using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface ITemplateService
    {
        string GetTemplate(Diagnostico diagnostico, Enfermedad enfermedad);
    }
}
