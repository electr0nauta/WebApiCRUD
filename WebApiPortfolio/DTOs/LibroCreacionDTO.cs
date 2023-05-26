using System.ComponentModel.DataAnnotations;
using WebApiPortfolio.Validaciones;

namespace WebApiPortfolio.DTOs
{
    public class LibroCreacionDTO
    {
        [PrimeraLetraMayuscula]
        [StringLength(maximumLength: 250)]
        public string Titulo { get; set; }
    }
}
