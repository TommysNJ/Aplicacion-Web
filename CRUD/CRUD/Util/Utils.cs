using CRUD.Models;

namespace CRUD.Util;

public class Utils
{
    public static List<Producto> ListaProducto = new List<Producto>() {
        new Producto
        {
            idProducto = 1,
            nombre = "Producto1",
            descripcion = "Descripcion1",
            cantidad = 1
        }
    };
}
