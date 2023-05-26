using System.ComponentModel.DataAnnotations;
using WebApiPortfolio.Validaciones;

namespace WebApiPortfolio.DTOs
{
    public class LibroDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
    }
}
