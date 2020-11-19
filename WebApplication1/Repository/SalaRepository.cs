using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Repository.Interfaces;
using RepositoryHelpers.DataBase;
using RepositoryHelpers.DataBaseRepository;

namespace WebApplication1.Repository
{
    public class SalaRepository : IRepository<Sala>
    {
        private readonly CustomRepository<Sala> Repository;
        private readonly Connection Connection;

        public SalaRepository()
        {
            var connection = new Connection()
            {
                Database = RepositoryHelpers.Utils.DataBaseType.SqlServer,
                ConnectionString = "Server=localhost\\SQLEXPRESS; Database = conflict_meet; Trusted_Connection = true"
            };
            Connection = connection;

            Repository = new CustomRepository<Sala>(connection);
        }

        public IEnumerable<Sala> GetAll()
        {
            var query = "SELECT * FROM SALA";
            return Repository.Get(query).ToList();
        }

        public IEnumerable<Sala> getAllByUsuario(string IdUsuario)
        {
            var query = "SELECT * " +
                        "FROM [dbo].[SalaUsuario] AS A " +
                        "JOIN [dbo].[sala] AS B ON A.Id_sala = B.Id " +
                        "WHERE A.Id_usuario = @IdUsuario;";

            var parameters = new Dictionary<string, object> { { "IdUsuario", IdUsuario } };

            return Repository.Get(query, parameters).ToList();
        }

        public Sala GetById(int id)
        {
            return Repository.GetById(id);
        }
         
        public int Criar(Sala sala)
        {
            var idSala = Repository.Insert(sala, true);

            var query = "INSERT INTO [dbo].[SalaUsuario] (Id_usuario, Id_sala) VALUES(@IdUsuario, @IdSala);";
            var parameters = new Dictionary<string, object> { { "IdUsuario", sala.IdUsuario }, { "IdSala", idSala } };

            return Repository.ExecuteQuery(query, parameters);
        }

        public void Remover(int id)
        {
            Repository.Delete(id);
        }

        public void Atualizar(Sala sala)
        {
            Repository.Update(sala);
        }
    }
}
