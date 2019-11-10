using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClasesBase.DAO.Repositorio;

namespace ClasesBase
{
    public class ClassTrabajarServicioFormat
    {
        AutobusRepositorio _autobusRepositorio = new AutobusRepositorio();
        ServicioRepositorio _servicioRepositorio = new ServicioRepositorio();
        TerminalRepositorio _terminalRepositorio = new TerminalRepositorio();
        EmpresaRepositorio _empresaRepositorio = new EmpresaRepositorio();

        public List<ClassServicioString> listarServicios() {

            List<Servicio> lista = _servicioRepositorio.listarServicios();
            List<ClassServicioString> serviciosFormat = new List<ClassServicioString>();

            foreach(Servicio item in lista){
                ClassServicioString oServicio = new ClassServicioString();
                Autobus oAutobus = _autobusRepositorio.buscarAutobus((int)item.aut_codigo);

                oServicio.Aut_codigo = oAutobus.aut_codigo;
                oServicio.Aut_matricula = oAutobus.aut_matricula;
                oServicio.Aut_tiposervicio = oAutobus.aut_tiposervicio;
                oServicio.Aut_cantidadPisos = (int)oAutobus.aut_cantidadPisos;

                oServicio.Ser_codigo = item.ser_codigo;
                oServicio.Ser_estado = item.ser_estado;
                oServicio.Ser_fecha = (DateTime)item.ser_fecha;

                oServicio.Ter_origen = _terminalRepositorio.buscarTerminal((int)item.ter_codigo_origen).ter_nombre;
                oServicio.Ter_destino = _terminalRepositorio.buscarTerminal((int)item.ter_codigo_destino).ter_nombre;

                oServicio.Emp_codigo = (int)oAutobus.emp_codigo;
                oServicio.Emp_nombre = _empresaRepositorio.buscarEmpresa(oServicio.Emp_codigo).emp_nombre;

                serviciosFormat.Add(oServicio);
            }
            return serviciosFormat;
        }

        public List<ClassServicioString> listarServiciosPorFecha(DateTime inicio, DateTime fin)
        {

            List<Servicio> lista = _servicioRepositorio.serviciosPorFecha(inicio,fin);
            List<ClassServicioString> serviciosFormat = new List<ClassServicioString>();
            if (lista != null)
            {
                foreach (Servicio item in lista)
                {
                    ClassServicioString oServicio = new ClassServicioString();
                    Autobus oAutobus = _autobusRepositorio.buscarAutobus((int)item.aut_codigo);

                    oServicio.Aut_codigo = oAutobus.aut_codigo;
                    oServicio.Aut_matricula = oAutobus.aut_matricula;
                    oServicio.Aut_tiposervicio = oAutobus.aut_tiposervicio;

                    oServicio.Ser_codigo = item.ser_codigo;
                    oServicio.Ser_estado = item.ser_estado;
                    oServicio.Ser_fecha = (DateTime)item.ser_fecha;

                    oServicio.Ter_origen = _terminalRepositorio.buscarTerminal((int)item.ter_codigo_origen).ter_nombre;
                    oServicio.Ter_destino = _terminalRepositorio.buscarTerminal((int)item.ter_codigo_destino).ter_nombre;

                    oServicio.Emp_codigo = (int)oAutobus.emp_codigo;
                    oServicio.Emp_nombre = _empresaRepositorio.buscarEmpresa(oServicio.Emp_codigo).emp_nombre;

                    serviciosFormat.Add(oServicio);
                }
                return serviciosFormat;
            }
            else {
                return null;
            }
            
        }

        public List<ClassServicioString> listarServiciosDestino(String destino)
        {
            
            List<ClassServicioString> serviciosFormat = new List<ClassServicioString>();
            Terminal oTerminal = _terminalRepositorio.buscarTerminalNombre(destino);
            List<Servicio> lista = _servicioRepositorio.listarServiciosDestino(oTerminal.ter_codigo);
            if(oTerminal != null ){
                foreach (Servicio item in lista)
                {
                    ClassServicioString oServicio = new ClassServicioString();
                    Autobus oAutobus = _autobusRepositorio.buscarAutobus((int)item.aut_codigo);

                    oServicio.Aut_codigo = oAutobus.aut_codigo;
                    oServicio.Aut_matricula = oAutobus.aut_matricula;
                    oServicio.Aut_tiposervicio = oAutobus.aut_tiposervicio;

                    oServicio.Ser_codigo = item.ser_codigo;
                    oServicio.Ser_estado = item.ser_estado;
                    oServicio.Ser_fecha = (DateTime)item.ser_fecha;

                    oServicio.Ter_origen = _terminalRepositorio.buscarTerminal((int)item.ter_codigo_origen).ter_nombre;
                    oServicio.Ter_destino = _terminalRepositorio.buscarTerminal((int)item.ter_codigo_destino).ter_nombre;

                    oServicio.Emp_codigo = (int)oAutobus.emp_codigo;
                    oServicio.Emp_nombre = _empresaRepositorio.buscarEmpresa(oServicio.Emp_codigo).emp_nombre;

                    serviciosFormat.Add(oServicio);
                }
                return serviciosFormat;
            }
            return null;
        }

        public List<ClassServicioString> listarServiciosOrigen(String origen)
        {

            List<ClassServicioString> serviciosFormat = new List<ClassServicioString>();
            Terminal oTerminal = _terminalRepositorio.buscarTerminalNombre(origen);
            List<Servicio> lista = _servicioRepositorio.listarServiciosOrigen(oTerminal.ter_codigo);
            if (oTerminal != null)
            {
                foreach (Servicio item in lista)
                {
                    ClassServicioString oServicio = new ClassServicioString();
                    Autobus oAutobus = _autobusRepositorio.buscarAutobus((int)item.aut_codigo);

                    oServicio.Aut_codigo = oAutobus.aut_codigo;
                    oServicio.Aut_matricula = oAutobus.aut_matricula;
                    oServicio.Aut_tiposervicio = oAutobus.aut_tiposervicio;

                    oServicio.Ser_codigo = item.ser_codigo;
                    oServicio.Ser_estado = item.ser_estado;
                    oServicio.Ser_fecha = (DateTime)item.ser_fecha;

                    oServicio.Ter_origen = _terminalRepositorio.buscarTerminal((int)item.ter_codigo_origen).ter_nombre;
                    oServicio.Ter_destino = _terminalRepositorio.buscarTerminal((int)item.ter_codigo_destino).ter_nombre;

                    oServicio.Emp_codigo = (int)oAutobus.emp_codigo;
                    oServicio.Emp_nombre = _empresaRepositorio.buscarEmpresa(oServicio.Emp_codigo).emp_nombre;

                    serviciosFormat.Add(oServicio);
                }
                return serviciosFormat;
            }
            return null;
        }
    }
}
