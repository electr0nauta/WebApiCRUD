using System.ComponentModel.DataAnnotations;

namespace WebApiPortfolio.Validaciones
{
    public class PrimeraLetraMayusculaAttribute: ValidationAttribute //creando una validacion reutilizable
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString())) //si value es nulo, o sea que el usuario no lo incluyo,
            {
                return ValidationResult.Success;//si no hay ningun string yo no quiero realizar ningun tipo de validacion, ya que de eso se encagar la propia validacion Required, y no quiero que se solapen.
            }

            var primeraLetra = value.ToString()[0].ToString();

            if (primeraLetra != primeraLetra.ToUpper()) 
            {
                return new ValidationResult("La primera letra debe ser mayúscula");
            }

            return ValidationResult.Success;
        }
    }
}
