using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase.DAO.Repositorio
{
    public class TerminalRepositorio
    {
        public void agregarTerminal(Terminal t)
        {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                context.Terminal.AddObject(t);
                context.SaveChanges();
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
