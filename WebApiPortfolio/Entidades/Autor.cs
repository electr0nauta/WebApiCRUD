using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiPortfolio.Validaciones;

namespace WebApiPortfolio.Entidades
{
    public class Autor: IValidatableObject //implemento esta interfaz, para poder crear mis propias validaciones por modelo, en este caso en la clase autor.
    {
        public int Id { get; set; }
       
        [Required(ErrorMessage = "El campo {0} es requerido")]//Required es una validacion, en este caso que dice que el atributo nombre es requerido si o si para poder hacer el post.
        //{0} es un placeholder, en este caso para el atributo nombre
        [StringLength(maximumLength: 120, ErrorMessage ="El campo {0} no de de tener mas de {1} caracteres")]//StringLenght es otra validacion, en este caso, que el atributo nombre no puede tener mas de 5 caracteres.
        //{0} es el placeholder del atributo nombre, y {1} es el placeholder del atributo que se le pasa por parametro a la funcion maximumLenght, que en este caso es 5
        //[PrimeraLetraMayuscula]//validacion personalizada, en la que valido que la primera letra del nombre sea mayúscula.
        //queda comentada para que pueda utilizar la validación por modelo que se define más abajo.
        public string Nombre { get; set; }
        //[Range(18, 120)]//range es una validacion, en la que el atributo edad debe estar entre los valores estipulados, en este caso 18 y 120
        //[NotMapped]//es para poder tener propiedades en nuestras entidades, pero estas propiedades no se van a corresponder con la columna de la tabla correspondiente.
        //public int Edad { get; set; }
        //[CreditCard]//se encarga de validar la tarjeta de credito, no valida que sea una tarjeta activa, ni que tenga fondos, sino que por lo menos valida la numeracion de la tarjeta.
        //[NotMapped]
       // public string TarjetaDeCredito { get; set; }
        //[Url]
        //[NotMapped]
        //public string URL { get; set; }

       // public int Menor { get; set; }

      //  public int Mayor { get; set; }
        public List<Libro> Libros { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)//implemento mis validaciones a nivel del modelo
        {
            if (!string.IsNullOrEmpty(Nombre)) //misma regla de validacion que PrimeraLetraMayuscula
            {
                var primeraletra = Nombre[0].ToString();

                if (primeraletra != primeraletra.ToUpper()) 
                {
                    yield return new ValidationResult("La primera letra debe ser maypuscula",//cada vez que se ejecuta esta condicion, yield se encarga de insertar el error dentro de la coleccion IEnumerable.
                        new string[] { nameof(Nombre) });
                }
            }

            //if (Menor > Mayor) 
            //{
            //    yield return new ValidationResult("Este valor no puede ser mas grande que el campo Mayor",
            //        new string[] { nameof(Menor) });
            //}
        }
    }
}
