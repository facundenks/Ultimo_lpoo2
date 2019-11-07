using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase.DAO.Repositorio
{
    public class EmpresaRepositorio
    {
        public Empresa buscarEmpresa(int codigo)
        {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                IQueryable<Empresa> empresaEncontrada = from q in context.Empresa
                                                          where q.emp_codigo == codigo
                                                          select q;

                List<Empresa> lista = empresaEncontrada.ToList();
                if (lista.Count != 0)
                {
                    var empresa = lista[0];

                    return empresa;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
