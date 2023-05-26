using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiPortfolio.Validaciones;

namespace WebApiPortfolio.Entidades
{
    public class Autor
    {
        public int Id { get; set; }
       
        [Required(ErrorMessage = "El campo {0} es requerido")]//Required es una validacion, en este caso que dice que el atributo nombre es requerido si o si para poder hacer el post.
        //{0} es un placeholder, en este caso para el atributo nombre
        [StringLength(maximumLength: 120, ErrorMessage ="El campo {0} no de de tener mas de {1} caracteres")]//StringLenght es otra validacion, en este caso, que el atributo nombre no puede tener mas de 5 caracteres.
        //{0} es el placeholder del atributo nombre, y {1} es el placeholder del atributo que se le pasa por parametro a la funcion maximumLenght, que en este caso es 5
        [PrimeraLetraMayuscula]//validacion personalizada, en la que valido que la primera letra del nombre sea mayúscula.
        //queda comentada para que pueda utilizar la validación por modelo que se define más abajo.
        public string Nombre { get; set; }
    }
}
