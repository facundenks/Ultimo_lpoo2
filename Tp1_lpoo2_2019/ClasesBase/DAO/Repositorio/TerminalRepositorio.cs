using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase.DAO.Repositorio
{
    public class TerminalRepositorio
    {
        public Terminal buscarTerminal(int codigo)
        {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                IQueryable<Terminal> terminalEncontrada = from q in context.Terminal
                                                          where q.ter_codigo == codigo
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
    }
}
