using CRUD.Data;
using CRUD.Models;
using CRUD.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace CRUD.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ClientHttp _httpClientFactory;
        //el constructor llama a la cración del cliente
        public ProductoController(ClientHttp httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // GET: ProductoController
        public async Task<IActionResult> Index()
        {
            using (var httpClient = _httpClientFactory.CreateHttpClient())
            {
                var response = await httpClient.GetAsync("api/Producto");
               
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    // Imprime el JSON en la consola
                    Console.WriteLine(data);
                    var productoslistado = JsonSerializer.Deserialize<IEnumerable<Producto>>(data);

                    return View(productoslistado);
                }
                else
                {
                    ViewBag.ErrorMessage = "Asegurate de tener conexión con la API";
                    return View("ErrorView"); ;
                }
            }
        }

        // GET: ProductoController/Details/5
        public async Task<IActionResult> Details(int idProducto)
        {
            using (var httpClient = _httpClientFactory.CreateHttpClient())
            {
                var response = await httpClient.GetAsync("api/Producto/" + idProducto);
                
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    
                    Console.WriteLine(data);
                    var productoEcontrado = JsonSerializer.Deserialize<Producto>(data);

                    return View(productoEcontrado);
                }
                else
                {
                    ViewBag.ErrorMessage = "No se pueden mostrar los detalles por el momento";
                    return View("ErrorView");
                }
            }
        }

        // GET: ProductoController/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Producto producto)
        {
            using (var httpClient = _httpClientFactory.CreateHttpClient())
            {
                
                var jsonProducto = JsonSerializer.Serialize(producto);

                
                var content = new StringContent(jsonProducto, Encoding.UTF8, "application/json");

                
                var response = await httpClient.PostAsync("api/Producto", content);
                
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMessage = "Debe llenar los campos";
                    return View("ErrorView");
                }
            }
        }

        // POST: ProductoController/Create


        // GET: ProductoController/Edit/5
     

        
        public IActionResult Edit(int IdProducto)
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Producto producto)
        {
            using (var httpClient = _httpClientFactory.CreateHttpClient())
            {
                
                var jsonProducto = JsonSerializer.Serialize(producto);

                
                var content = new StringContent(jsonProducto, Encoding.UTF8, "application/json");

                
                var response = await httpClient.PutAsync("api/Producto/" + producto.idProducto, content);
                
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMessage = "Debe llenar los campos";
                    return View("ErrorView");
                }
            }
        }


        // POST: ProductoController/Edit/5


        // GET: ProductoController/Delete/5
        public async Task<IActionResult> Delete(int idProducto)
        {
            using (var httpClient = _httpClientFactory.CreateHttpClient())
            {
                var response = await httpClient.DeleteAsync($"api/Producto/" + idProducto);

               
                if (response.IsSuccessStatusCode)
                {
                   
                    Console.WriteLine(response);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Exception", new { message = "Error retrieving data" });
                }
            }
        }

        // POST: ProductoController/Delete/5
       
    }
}
