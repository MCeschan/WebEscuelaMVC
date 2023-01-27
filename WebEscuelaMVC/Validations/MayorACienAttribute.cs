using System.ComponentModel.DataAnnotations;

namespace WebEscuelaMVC.Validations
{
    public class MayorACienAttribute:ValidationAttribute
    {
        public MayorACienAttribute() {
            ErrorMessage = "El numero ingresado debe ser mayor a 100";
        }
        public override bool IsValid(object value)
        {
            int numero = (int)value;
            if (numero > 100) {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
