using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace CRUD.Models
{
    public class Producto
    {
        public int idProducto { get; set; }
        [Required]
        public string nombre { get; set; }
        public string descripcion { get; set; }
        [Required]
        public int cantidad { get; set; }




    }
}
