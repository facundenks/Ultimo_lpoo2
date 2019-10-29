using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using ClasesBase.DAO.Repositorio;

namespace ClasesBase
{
    public class ClassTrabajarUsuarioString
    {
        public List<ClassUsuario> UsuarioStringList(){
            UsuarioRepositorio listUsu = new UsuarioRepositorio();
            List<Usuario> lista = listUsu.getUsersList();
            List<ClassUsuario> listaString = new List<ClassUsuario>();
            foreach (Usuario item in lista) {
                ClassUsuario usu = new ClassUsuario();
                usu.UsuarioId1 = Convert.ToString(item.usu_id);
                usu.NombreUsuario1 = Convert.ToString(item.usu_nombreUsuario);
                usu.ApellidoUsuario1 = Convert.ToString(item.usu_apellidoNombre);
                usu.PassUsuario1 = Convert.ToString(item.usu_contraseña);
                if (item.rol_codigo==1)
                {
                    usu.CodigoUsuario1 = "Administrador";
                }
                if (item.rol_codigo == 2)
                {
                    usu.CodigoUsuario1 = "Operador";
                }
                listaString.Add(usu);
            }
            return listaString;
        }
    }
}
