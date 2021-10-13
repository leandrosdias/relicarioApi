using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.Home.Valores;
using relicarioApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relicarioApi.Repositories.Home.Valores
{
    public class ValoresRepository : IValoresRepository
    {
        private readonly DataContext _context;

        public ValoresRepository(DataContext context)
        {
            _context = context;
        }

        public void Delete(DeleteValoresRequest request)
        {
            var valores = _context.Valores.FirstOrDefault(x => x.Id == request.Id);

            if (valores != null)
            {
                _context.Valores.Remove(valores);
            }
        }

        public IEnumerable<Models.Valores> Get(GetValoresRequest param)
        {
            var valoresQuery = _context.Valores.AsQueryable();

            if (param.Id != Guid.Empty)
            {
                return valoresQuery.Where(x => x.Id == param.Id);
            }

            return valoresQuery.AsEnumerable();
        }

        public void Save(Models.Valores valores)
        {
            _context.Valores.Add(valores);
        }

        public Models.Valores Update(Models.Valores valores)
        {
            var valoresDb = _context.Valores.FirstOrDefault(x => x.Id == valores.Id);
            if (valoresDb == null)
            {
#pragma warning disable S112 // General exceptions should never be thrown
                throw new Exception(message: $"Valores não encotrado para atualizar: {valoresDb?.Id}");
#pragma warning restore S112 // General exceptions should never be thrown
            }

            if (!string.IsNullOrWhiteSpace(valores.Descricao))
                valoresDb.Descricao = valores.Descricao;

            if (!string.IsNullOrWhiteSpace(valores.Icone))
                valoresDb.Icone = valores.Icone;

            if (!string.IsNullOrWhiteSpace(valores.Titulo))
                valoresDb.Titulo = valores.Titulo;

            return valoresDb;
        }
    }
}
