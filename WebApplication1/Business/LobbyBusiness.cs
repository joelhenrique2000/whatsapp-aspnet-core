using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Business
{
    public class LobbyBusiness
    {
        private readonly SalaRepository salaRepository;

        public LobbyBusiness() {
            salaRepository = new SalaRepository();
        }

        public IEnumerable<Sala> GetAll(string id) {
            return salaRepository.getAllByUsuario(id);
        }
    }
}
