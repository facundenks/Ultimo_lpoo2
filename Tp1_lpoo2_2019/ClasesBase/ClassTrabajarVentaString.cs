using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using ClasesBase.DAO.Repositorio;

namespace ClasesBase
{
    public class ClassTrabajarVentaString
    {
        public List<ClassVentas> ventaStringList()
        {
            PasajeRepositorio PasDAO = new PasajeRepositorio();
            List<Pasaje> listaPasajes = PasDAO.listarPasajes();
            List<ClassVentas> listaVentasString = new List<ClassVentas>();
            foreach (Pasaje item in listaPasajes)
            {
                ClassVentas ven = new ClassVentas();
                ven.PasajeCodigo = Convert.ToString(item.pas_codigo);
                ven.PasajeAsiento = Convert.ToString(item.pas_asiento);
                ven.PasajePrecio = Convert.ToString(item.pas_precio);
                ven.PasajeFec = Convert.ToString(item.pas_fechaHora);
                ClienteRepositorio CliDAO = new ClienteRepositorio();
                Cliente cli = new Cliente();
                cli = CliDAO.buscarCliente(item.cli_dni);
                ven.ClienteNombre = cli.cli_nombre;
                ven.ClienteApellido = cli.cli_apellido;
                ven.ClienteDNI = Convert.ToString(cli.cli_dni);
                ServicioRepositorio SerDAO = new ServicioRepositorio();
                Servicio ser = new Servicio();
                ser = SerDAO.buscarServicio((int)item.ser_codigo);
                ven.ServicioCodigo = Convert.ToString(ser.ser_codigo);
                ven.ServicioFec = Convert.ToString(ser.ser_fecha);
                ven.ServicioCodOrigen = Convert.ToString(ser.ter_codigo_origen);
                ven.ServicioCodDestino = Convert.ToString(ser.ter_codigo_destino);
                AutobusRepositorio AutDAO = new AutobusRepositorio();
                Autobus aut = new Autobus();
                aut = AutDAO.buscarAutobus((int)ser.aut_codigo);
                ven.AutobusTipoServicio = aut.aut_tiposervicio;
                ven.AutobusMatricula = aut.aut_matricula;
                ven.NombreEmpresa = "Bolut";
                listaVentasString.Add(ven);
            }
            return listaVentasString;
        }
    }
}
