using PruebaTecnica_AccesoDatos.SQL;
using PruebaTecnica_Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnica_LogicaNegocio
{
   public class LogicaNegocio
    {

        DataSql _dataSql;

        public LogicaNegocio()
        {
            _dataSql = new DataSql();
        }


        //Vehiculos sin servicios
        public IEnumerable<VehiculoDTO> getVehiculosSinServicio()
        {
            return _dataSql.obtenerVehiculosSinServicios();
        }


        //Agregar vehiculo
        public void saveVehicule(VehiculoDTO datos)
        {
            Resgistrar resgistrar = new Resgistrar(
                datos.Placa, datos.Dueno, datos.Marca
                );

            _dataSql.guardarVehiculo(resgistrar);
        }


        //Vehiculos por Servicio
        public IEnumerable<VehiculoDTO> getListaVheiculoByServicio(int idServicio)
        {
            return _dataSql.obtenerListaVheiculoPorServicio(idServicio);
        }


        //Asignar Servicio
        public void AsignarServicio(int idV,int idS)
        {
            _dataSql.AsignarServicios(idV, idS);
        }


        //Mostrar Servicios
        public IEnumerable<ServiciosDTO> getServices()
        {
            return _dataSql.obtenerServicios();
        }


        //Editar Servicio
        public void EditarServicio(MisServicios misServicios)
        {
            _dataSql.editarServicio(misServicios);
        }
    }
}
