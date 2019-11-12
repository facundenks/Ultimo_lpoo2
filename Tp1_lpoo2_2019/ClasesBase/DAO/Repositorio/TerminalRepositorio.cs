using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase.DAO.Repositorio
{
    public class TerminalRepositorio
    {
<<<<<<< HEAD
        public List<Terminal> listarTerminales()
        {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                IQueryable<Terminal> listaTerminales = from q in context.Terminal
                                                      select q;
                return listaTerminales.ToList();
=======
        public void agregarTerminal(Terminal t)
        {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                context.Terminal.AddObject(t);
                context.SaveChanges();
>>>>>>> b1b4d71bc4a60a85d893a95a478642e3b1fec9b3
            }
        }

        public Terminal buscarTerminal(int codigo)
        {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                IQueryable<Terminal> terminalEncontrada = from q in context.Terminal
                                                          where q.ter_codigo == @codigo
                                                          select q;

                List<Terminal> lista = terminalEncontrada.ToList();
                if (lista.Count != 0)
                {
                    var terminal = lista[0];

                    return terminal;
                }
                else
                {
                    return null;
                }
            }
        }

        public Terminal buscarTerminalNombre(String nombre)
        {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                IQueryable<Terminal> terminalEncontrada = from q in context.Terminal
                                                          where q.ter_nombre.Contains(nombre)
                                                          select q;

                List<Terminal> lista = terminalEncontrada.ToList();
                if (lista.Count != 0)
                {
                    var terminal = lista[0];

                    return terminal;
                }
                else
                {
                    return null;
                }
            }
        }

        public List<Terminal> getTerminales()
        {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                IQueryable<Terminal> terminales = from q in context.Terminal
                                              select q;
                return terminales.ToList();
            }
        }
    }
}
