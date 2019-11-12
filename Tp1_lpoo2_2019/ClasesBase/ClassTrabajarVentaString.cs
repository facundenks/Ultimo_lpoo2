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
        PasajeRepositorio PasDAO = new PasajeRepositorio();
        ClienteRepositorio CliDAO = new ClienteRepositorio();
        ServicioRepositorio SerDAO = new ServicioRepositorio();
        AutobusRepositorio AutDAO = new AutobusRepositorio();
        TerminalRepositorio _terminalRepositorio = new TerminalRepositorio();

        public List<ClassVentas> ventaStringList()
        {
            List<Pasaje> listaPasajes = PasDAO.listarPasajes();
            List<ClassVentas> listaVentasString = new List<ClassVentas>();

            foreach (Pasaje item in listaPasajes)
            {
                ClassVentas ven = new ClassVentas();
                ven.PasajeCodigo = Convert.ToString(item.pas_codigo);
                ven.PasajeAsiento = Convert.ToString(item.pas_asiento);
                ven.PasajePrecio = Convert.ToString(item.pas_precio);
                ven.PasajeFec = Convert.ToString(item.pas_fechaHora);
                
                Cliente cli = new Cliente();
                Console.WriteLine(item.cli_dni);
                cli = CliDAO.buscarCliente(item.cli_dni);
                ven.ClienteNombre = cli.cli_nombre;
                ven.ClienteApellido = cli.cli_apellido;
                ven.ClienteDNI = Convert.ToString(cli.cli_dni);

                Servicio ser = new Servicio();
                ser = SerDAO.buscarServicio((int)item.ser_codigo);
                ven.ServicioCodigo = Convert.ToString(ser.ser_codigo);
                ven.ServicioFec = Convert.ToString(ser.ser_fecha);
                
                Terminal terOrigen = _terminalRepositorio.buscarTerminal((int)ser.ter_codigo_origen);
                Terminal terDest = _terminalRepositorio.buscarTerminal((int)ser.ter_codigo_destino);
                ven.ServicioCodOrigen = Convert.ToString(terOrigen.ter_nombre);
                ven.ServicioCodDestino = Convert.ToString(terDest.ter_nombre);
                //ven.ServicioCodOrigen = Convert.ToString(ser.ter_codigo_origen);
                //ven.ServicioCodDestino = Convert.ToString(ser.ter_codigo_destino);
                
                Autobus aut = new Autobus();
                aut = AutDAO.buscarAutobus((int)ser.aut_codigo);
                ven.AutobusTipoServicio = aut.aut_tiposervicio;
                ven.AutobusMatricula = aut.aut_matricula;
                
                ven.NombreEmpresa = "Bolut";
                listaVentasString.Add(ven);
            }
            return listaVentasString;
        }

        //AVUR DESDE ACA

        public List<ClassVentas> listarVentasPorFecha(DateTime inicio, DateTime fin)
        {
            List<Pasaje> lista = PasDAO.pasajesPorFecha(inicio, fin);
            List<ClassVentas> pasajeFormat = new List<ClassVentas>();

            foreach (Pasaje item in lista)
            {
                ClassVentas ven= new ClassVentas();
                Servicio ser = SerDAO.buscarServicio((int)item.ser_codigo); 
                Autobus auto = AutDAO.buscarAutobus((int)ser.aut_codigo);
                Cliente cli = CliDAO.buscarCliente((String)item.cli_dni);
                Terminal terOrigen = _terminalRepositorio.buscarTerminal((int)ser.ter_codigo_origen);
                Terminal terDest = _terminalRepositorio.buscarTerminal((int)ser.ter_codigo_destino);

                ven.AutobusMatricula = auto.aut_matricula;
                ven.AutobusTipoServicio = auto.aut_tiposervicio;

                ven.ServicioCodigo = Convert.ToString(ser.ser_codigo);
                ven.ServicioFec = Convert.ToString(ser.ser_fecha);
                ven.ServicioCodOrigen = Convert.ToString(terOrigen.ter_nombre);
                ven.ServicioCodDestino = Convert.ToString(terDest.ter_nombre);

                ven.ClienteDNI = Convert.ToString(cli.cli_dni);
                ven.ClienteApellido = cli.cli_apellido;
                ven.ClienteNombre = cli.cli_nombre;

                ven.PasajeCodigo = Convert.ToString(item.pas_codigo);
                ven.PasajeAsiento = Convert.ToString(item.pas_asiento);
                ven.PasajeFec = Convert.ToString(item.pas_fechaHora);
                ven.PasajePrecio = Convert.ToString(item.pas_precio);

                ven.NombreEmpresa = "Bolut";
                pasajeFormat.Add(ven);
            }
           
            
            return pasajeFormat;
                       
         }
        
            
     }
        
    
}
