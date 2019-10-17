using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

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

        public List<Usuario> getUsersList()
        {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                IQueryable<Usuario> Users = from u in context.Usuario
                                            select u;
                return Users.ToList();
            }
        }


        public ObservableCollection<Usuario> listaUsuarios()
        {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                IQueryable<Usuario> Usuarios = from q in context.Usuario
                                              select q;
                var oc = new ObservableCollection<Usuario>();
                foreach (var item in Usuarios)
                    oc.Add(item);

                return oc;
            }
        }

        public void AgrgarUsuario(Usuario oUsuario)
        {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                context.Usuario.AddObject(oUsuario);
                context.SaveChanges();
            }
        }

        public void ModificarUsuario(Usuario oUsuario) { 
            using(BDpasajesEntities context = new BDpasajesEntities()){
                Usuario UsuarioAc = context.Usuario.SingleOrDefault(p => p.usu_id == oUsuario.usu_id);
                UsuarioAc.usu_apellidoNombre = oUsuario.usu_apellidoNombre;
                UsuarioAc.usu_nombreUsuario = oUsuario.usu_nombreUsuario;
                UsuarioAc.usu_contraseña = oUsuario.usu_contraseña;
                UsuarioAc.rol_codigo = oUsuario.rol_codigo;
                
                context.SaveChanges();
            }
        }

        public int ObtenerPosicion(int id) {
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                IQueryable<Usuario> Users = from u in context.Usuario
                                            select u;
                List<Usuario> lista = Users.ToList();
                int indice = lista.FindIndex(x => x.usu_id == id);
                return indice;
            }
        }

        public bool nombreUsuarioExiste(String name)
        {
            using (BDpasajesEntities db = new BDpasajesEntities())
            {
                IQueryable<Usuario> Usuario = from q in db.Usuario
                                              where q.usu_nombreUsuario == name
                                              select q;
                List<Usuario> lista = Usuario.ToList();
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

        public bool ultimoOperador() {
            using (BDpasajesEntities db = new BDpasajesEntities())
            {
                int id = 2;
                IQueryable<Usuario> Usuario = from q in db.Usuario
                                              where q.usu_id == id
                                              select q;
                List<Usuario> lista = Usuario.ToList();
                if (lista.Count == 1)
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void eliminarUsuario(int id){
            using (BDpasajesEntities context = new BDpasajesEntities())
            {
                Usuario UsuarioAc = (from q in context.Usuario
                                     where q.usu_id == id
                                     select q).First();
                context.DeleteObject(UsuarioAc);
                context.SaveChanges();
            }
        }
    }
}
