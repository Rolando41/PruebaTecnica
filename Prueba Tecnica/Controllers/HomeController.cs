using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaTecnica_Entidades;
using PruebaTecnica_LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LogicaNegocio _logicaNegocio;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _logicaNegocio = new LogicaNegocio();
        }


        //Vehiculos sin servicios
        public IActionResult Index()
        {
            IEnumerable<VehiculoDTO> response = _logicaNegocio.getVehiculosSinServicio();

            ViewBag.lista = response;

            return View();
        }

        //Agregar vehiculo
        public IActionResult CreateVehicule()
        {

            return View();
        }

        [BindProperty]

        public VehiculoDTO _resgistrar { get; set; }
        public IActionResult saveVehiculo()
        {

            _logicaNegocio.saveVehicule(_resgistrar);

            return RedirectToAction("Index");
        }

        //Vehiculos por Servicio
        public IActionResult Servicios()
        {
            IEnumerable<VehiculoDTO> tab1 = _logicaNegocio.getListaVheiculoByServicio(1);
            IEnumerable<VehiculoDTO> tab2 = _logicaNegocio.getListaVheiculoByServicio(2);
            IEnumerable<VehiculoDTO> tab3 = _logicaNegocio.getListaVheiculoByServicio(3);
            IEnumerable<VehiculoDTO> tab4 = _logicaNegocio.getListaVheiculoByServicio(4);

            ViewBag.tab1 = tab1;
            ViewBag.tab2 = tab2;
            ViewBag.tab3 = tab3;
            ViewBag.tab4 = tab4;
            return View();
        }


        //Asignar Servicio
        [BindProperty]
        public RegistrarServicio _registrarServicio { get; set; }
        public IActionResult Resultado()
        {
            _logicaNegocio.AsignarServicio(_registrarServicio.ID_Vehiculo, _registrarServicio.ID_Servicio);

            return RedirectToAction("Index");
        }


        //Mostrar Servicios
        public IActionResult MisServicios()
        {

            IEnumerable<ServiciosDTO> list = _logicaNegocio.getServices();
            ViewBag.list = list;
            return View();
        }


        //Agregar Servicio

        public IActionResult VistaServicios(int id, string placa, string dueno, string marca)
        {

            ViewBag.id = id;
            ViewBag.dueno = dueno;
            ViewBag.marca = marca;
            ViewBag.placa = placa;

            return View();
        }

        //Editar Servicio
        public IActionResult EditarServicios(int id, string descripcion, string monto)
        {
            ViewBag.id = id;
            ViewBag.descripcion = descripcion;
            ViewBag.monto = monto;
            return View();
        }

        [BindProperty]
        public ServiciosDTO _misServicios { get; set; }
        public IActionResult ProcesoEditado()
        {
            MisServicios misServicios = new MisServicios(
                _misServicios.ID_Servicio, _misServicios.Descripcion,_misServicios.Monto);

            _logicaNegocio.EditarServicio(misServicios);
          
            return RedirectToAction("MisServicios");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {

            return View();
        }
    }
}
