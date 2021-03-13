using Dapper;
using PruebaTecnica_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PruebaTecnica_AccesoDatos.SQL
{
    public class DataSql
    {
        // String para la conexion a la base de datos
        string connectionStringSql = @"Data source=MSI\SQLEXPRESS;Initial catalog=PruebaTecnica;Integrated Security=True";


        //Vehiculos sin servicios
        public IEnumerable<VehiculoDTO> getVehiculosSinServicios()
        {

            IEnumerable<VehiculoDTO> response;

            using (var db = new SqlConnection(connectionStringSql))
            {

                var sql = "SELECT* FROM Vehiculo left join [Vehiculo-Servicio] ON Vehiculo.ID_Vehiculo = [Vehiculo-Servicio].ID_Vehiculo where [Vehiculo-Servicio].[ID_Vehiculo-Servicio] is null; ";
                response = db.Query<VehiculoDTO>(sql);

            }
            return response;

        }


        //Agregar vehiculo
        public void saveVehiculo(Resgistrar model)
        {


            Resgistrar newModel = new Resgistrar(
                model.Placa, model.Dueno, model.Marca
                );


            using (var db = new SqlConnection(connectionStringSql))
            {

                var sql = "INSERT INTO Vehiculo (Placa,Dueno,Marca) VALUES(@Placa,@Dueno,@Marca);";
                db.Execute(sql, newModel);

            }

        }


        //Vehiculos por Servicio
        public IEnumerable<VehiculoDTO> getListaVheiculoByServicio(int idServicio)
        {

                IEnumerable<VehiculoDTO> response;

            using (var db = new SqlConnection(connectionStringSql))
            {

                var sql = "SELECT Vehiculo.ID_Vehiculo, Vehiculo.Placa,Vehiculo.Dueno,Vehiculo.Marca FROM Vehiculo Inner Join [Vehiculo-Servicio] ON Vehiculo.ID_Vehiculo = [Vehiculo-Servicio].ID_Vehiculo AND [Vehiculo-Servicio].ID_Servicio = " + idServicio+";";
                response = db.Query<VehiculoDTO>(sql);

            }
            return response;

        }


        //Asignar Servicio
        public void  AsignarServicios(int idVheiculo,int idServicio)
        {

            AsignarServicio asignar = new AsignarServicio(
              idVheiculo,idServicio
                );
            using (var db = new SqlConnection(connectionStringSql))
            {

                var sql = "INSERT INTO [Vehiculo-Servicio] (ID_Vehiculo,ID_Servicio) VALUES (@ID_Vehiculo,@ID_Servicio);";
                db.Execute(sql, asignar);

            }
          

        }


        //Mostrar Servicios
        public IEnumerable<ServiciosDTO> getServices()
        {
            IEnumerable<ServiciosDTO> response;

            using (var db = new SqlConnection(connectionStringSql))
            {

                var sql = "SELECT* FROM Servicios; ";

                response = db.Query<ServiciosDTO>(sql);

            }
            return response;
        }


        //Editar Servicio
        public void editarServicio(MisServicios dto) {

            using (var db = new SqlConnection(connectionStringSql))
            {

                var sql = "UPDATE Servicios SET Descripcion = @Descripcion, Monto = @Monto WHERE Servicios.ID_Servicio = @ID_Servicio; ";
                db.Execute(sql, dto);

            }
        }



    }
}
