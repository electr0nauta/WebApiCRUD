using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiPortfolio.Validaciones;

namespace WebApiPortfolio.Entidades
{
    public class Autor
    {
        public int Id { get; set; }
       
        
        
        //queda comentada para que pueda utilizar la validación por modelo que se define más abajo.
        public string Nombre { get; set; }
    }
}
