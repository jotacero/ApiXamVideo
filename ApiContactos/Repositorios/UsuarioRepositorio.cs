using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ApiContactos.Adapters;
using ApiContactos.Models;
using ContactosModel.Model;
using RepositorioAdapter.Repositorio;

namespace ApiContactos.Repositorios
{
    public class UsuarioRepositorio:
        BaseRepositorioEntity<Usuario,UsuarioModel,UsuarioAdapter>
    {
        public UsuarioRepositorio(DbContext context) : base(context)
        {
        }

        public ICollection<UsuarioModel> Obtener()
        {
            var data = Get();
            if (data.Count > 0) return data;
            return null;
        }

        public UsuarioModel Validar(string login, string password)
        {
            var data = Get(o => o.login == login && o.password == password);
            if (data.Any()) return data.First();
            return null;
        }

        public override UsuarioModel Add(UsuarioModel model)
        {
            if(IsUnico(model.login)) return base.Add(model);
            return null;
        }

        public bool IsUnico(string login)
        {
            var data = Get(o => o.login == login);
            return !data.Any();
        }

        public int BorrarIndividual(int id)
        {
            var data = Delete(id);
            return data;
        }

        public int BorrarIndividual(UsuarioModel model)
        {
            var data = Delete(model);
            return data;
        }
    }
}