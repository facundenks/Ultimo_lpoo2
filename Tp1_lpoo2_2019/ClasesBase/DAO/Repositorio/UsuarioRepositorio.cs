using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClasesBase.DAO.Repositorio
{
    public class UsuarioRepositorio
    {
        public Usuario login(Usuario oUsuario)
        {
            String name = oUsuario.usu_nombreUsuario;
            String pass = oUsuario.usu_contraseña;
            using (BDpasajesEntities db = new BDpasajesEntities())
            {
                IQueryable<Usuario> Usuario = from q in db.Usuario
                                              where q.usu_nombreUsuario == name &&
                                              q.usu_contraseña == pass
                                              select q;
                List<Usuario> lista = Usuario.ToList();
                if (lista.Count != 0)
                {
                    var logUsuario = lista[0];

                    return logUsuario;
                }
                else {
                    return null;
                }
            }
        }


        public List<Usuario> getUsersList() {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                IQueryable<Usuario> Users = from u in context.Usuario
                                            select u;
                return Users.ToList();
            }
        }
    }
}
