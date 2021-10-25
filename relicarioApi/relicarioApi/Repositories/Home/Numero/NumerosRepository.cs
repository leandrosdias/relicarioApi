using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.Home.Numeros;
using relicarioApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relicarioApi.Repositories.Home.Numeros
{
    public class NumerosRepository : INumerosRepository
    {
        private readonly DataContext _context;

        public NumerosRepository(DataContext context)
        {
            _context = context;
        }

        public void Delete(DeleteNumerosRequest request)
        {
            var numeros = _context.Numeros.FirstOrDefault(x => x.Id == request.Id);

            if (numeros != null)
            {
                _context.Numeros.Remove(numeros);
            }
        }

        public IEnumerable<Models.Numeros> Get(GetNumerosRequest param)
        {
            var numerosQuery = _context.Numeros.AsQueryable();

            if (param.Id != Guid.Empty)
            {
                return numerosQuery.Where(x => x.Id == param.Id);
            }

            return numerosQuery.AsEnumerable();
        }

        public void Save(Models.Numeros numeros)
        {
            _context.Numeros.Add(numeros);
        }

        public Models.Numeros Update(Models.Numeros numeros)
        {
            var numerosDb = _context.Numeros.FirstOrDefault(x => x.Id == numeros.Id);
            if (numerosDb == null)
            {
#pragma warning disable S112 // General exceptions should never be thrown
                throw new Exception(message: $"Numeros não encotrado para atualizar: {numerosDb?.Id}");
#pragma warning restore S112 // General exceptions should never be thrown
            }

            if (!string.IsNullOrWhiteSpace(numeros.Descricao))
                numerosDb.Descricao = numeros.Descricao;

            if (numeros.Numero != 0)
                numerosDb.Numero = numeros.Numero;

            return numerosDb;
        }
    }
}
