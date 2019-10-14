using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using ClasesBase.DAO.Repositorio;

namespace ClasesBase
{
    public class TrabajarUsuario
    {
        public ObservableCollection<Usuario> TraerUsuarios()
        {
            UsuarioRepositorio _usuarioRepositorio = new UsuarioRepositorio();
            return _usuarioRepositorio.listaUsuarios();
        }
    }
}
