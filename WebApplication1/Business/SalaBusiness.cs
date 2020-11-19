using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Repository;
using WebApplication1.Models;

namespace WebApplication1.Business
{
    public class SalaBusiness
    {
        private readonly SalaRepository salaRepository;

        public SalaBusiness()
        {
            salaRepository = new SalaRepository();
        }

        public IEnumerable<Sala> GetAll()
        {
            return salaRepository.GetAll();
        }

        public IEnumerable<Sala> GetAllByUsuario(string IdUsuario)
        {
            return salaRepository.getAllByUsuario(IdUsuario);
        }

        public Sala GetById(int id)
        {
            return salaRepository.GetById(id);
        }

        public int Create(Sala sala)
        {
            return salaRepository.Criar(sala);
        }

        public int Remove(int id)
        {
            salaRepository.Remover(id);
            return 1;
        }
    }
}
