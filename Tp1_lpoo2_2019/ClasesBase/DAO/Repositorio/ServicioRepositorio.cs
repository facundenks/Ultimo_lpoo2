using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase.DAO.Repositorio
{
    public class ServicioRepositorio
    {
        public void AgrgarServicio(Servicio oServicio)
        {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                context.Servicio.AddObject(oServicio);
                context.SaveChanges();
            }
        }

        public void ModificarServicio(Servicio oServicio)
        {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                Servicio servicioMod = context.Servicio.SingleOrDefault(p => p.ser_codigo == oServicio.ser_codigo);

                servicioMod.ser_estado = oServicio.ser_estado;
                servicioMod.ser_fecha = oServicio.ser_fecha;
                servicioMod.aut_codigo = oServicio.aut_codigo;
                servicioMod.ter_codigo_origen = oServicio.ter_codigo_origen;
                servicioMod.ter_codigo_destino = oServicio.ter_codigo_destino;
                
                context.SaveChanges();
            }
        }

        public List<Servicio> listarServiciosDestino(int codigoDestino)
        {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                IQueryable<Servicio> listaServicios = from q in context.Servicio
                                                      where q.ter_codigo_destino == codigoDestino
                                                      select q;
                return listaServicios.ToList();
            }
        }

        public List<Servicio> listarServiciosOrigen(int codigoOrigen)
        {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                IQueryable<Servicio> listaServicios = from q in context.Servicio
                                                      where q.ter_codigo_origen == codigoOrigen
                                                      select q;
                return listaServicios.ToList();
            }
        }

        public List<Servicio> listarServicios()
        {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                IQueryable<Servicio> listaServicios = from q in context.Servicio
                                              select q;
                return listaServicios.ToList();
            }
        }

        public Servicio buscarServicio(int codigo) {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                IQueryable<Servicio> servicioEncontrado = from q in context.Servicio
                                                          where q.ser_codigo == codigo && 
                                                          q.ser_estado == "Abierto"
                                                          select q;

                List<Servicio> lista = servicioEncontrado.ToList();
                if (lista.Count != 0)
                {
                    var servicio = lista[0];

                    return servicio;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool existeServicio(int codigo)
        {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                IQueryable<Servicio> servicioEncontrado = from q in context.Servicio
                                                          where q.ser_codigo == codigo 
                                                          select q;

                List<Servicio> lista = servicioEncontrado.ToList();
                if (lista.Count != 0)
                {
                    var servicio = lista[0];

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool servicioConVentas(int codigo)
        {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                IQueryable<Pasaje> servicioConPasajes = from q in context.Pasaje
                                                          where q.ser_codigo == codigo
                                                          select q;

                List<Pasaje> lista = servicioConPasajes.ToList();
                if (lista.Count != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Servicio servicioCoche(int numAutobus)
        {
            using (BDpasajesEntities db = new BDpasajesEntities())
            {
                IQueryable<Servicio> servicio = from q in db.Servicio
                                              where q.aut_codigo == numAutobus &&
                                              q.ser_estado == "Abierto"
                                              select q;
                List<Servicio> lista = servicio.ToList();
                if (lista.Count != 0)
                {
                    var servicioCoche = lista[0];

                    return servicioCoche;
                }
                else
                {
                    return null;
                }
            }
        }

        public List<Servicio> serviciosPorFecha(DateTime inicio, DateTime fin) { 
            using(BDpasajesEntities context = new BDpasajesEntities()){
                IQueryable<Servicio> servicio = from q in context.Servicio
                                        where
                                        (q.ser_fecha >= inicio.Date && q.ser_fecha <= fin)
                                        select q;
                List<Servicio> lista = servicio.ToList();
                if (lista.Count != 0)
                {
                    return lista;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool controlFechaHoraServicio(DateTime fecha, int codigoAutobus)
        {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                IQueryable<Servicio> servicioEncontrado = from q in context.Servicio
                                                          where q.ser_fecha == fecha 
                                                          select q;

                List<Servicio> lista = servicioEncontrado.ToList();
                if (lista.Count != 0)
                {
                    bool ban = true;
                    foreach (Servicio s in lista){
                        int hora = Convert.ToInt32(Convert.ToDateTime(s.ser_fecha).Hour);
                        int minutos = Convert.ToInt32(Convert.ToDateTime(s.ser_fecha).Minute);
                        if(hora == fecha.Hour && minutos == fecha.Minute && s.ser_estado == "Abierto" 
                            && s.aut_codigo == codigoAutobus){

                            ban = false;
                        }
                    }
                   
                    return ban;
    
                }
                else
                {
                    return true;
                }
            }
        }

        public bool controlFechaHoraServicioExistente(DateTime fecha, int codigoAutobus, int serCodigo)
        {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                IQueryable<Servicio> servicioEncontrado = from q in context.Servicio
                                                          where q.ser_fecha == fecha
                                                          select q;

                List<Servicio> lista = servicioEncontrado.ToList();
                if (lista.Count != 0)
                {
                    bool ban = true;
                    foreach (Servicio s in lista)
                    {
                        int hora = Convert.ToInt32(Convert.ToDateTime(s.ser_fecha).Hour);
                        int minutos = Convert.ToInt32(Convert.ToDateTime(s.ser_fecha).Minute);
                        if (hora == fecha.Hour && minutos == fecha.Minute && s.ser_estado == "Abierto"
                            && s.aut_codigo == codigoAutobus && s.ser_codigo != serCodigo)
                        {

                            ban = false;
                        }
                    }

                    return ban;

                }
                else
                {
                    return true;
                }
            }
        }

        public string buscarServicio()
        {
            throw new NotImplementedException();
        }
    }
}
