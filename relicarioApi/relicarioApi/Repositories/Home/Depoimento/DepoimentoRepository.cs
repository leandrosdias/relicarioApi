using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.Home.Depoimento;
using System;
using System.Collections.Generic;
using System.Linq;

namespace relicarioApi.Repositories.Home.Depoimento
{
    public class DepoimentoRepository : IDepoimentoRepository
    {
        private readonly DataContext _context;

        public DepoimentoRepository(DataContext context)
        {
            _context = context;
        }

        public void Delete(DeleteDepoimentoRequest request)
        {
            var depoimento = _context.Depoimentos.FirstOrDefault(x => x.Id == request.Id);

            if (depoimento != null)
            {
                _context.Depoimentos.Remove(depoimento);
            }
        }

        public IEnumerable<Models.Depoimento> Get(GetDepoimentoRequest param)
        {
            var depoimentoQuery = _context.Depoimentos.AsQueryable();

            if (param.Id != Guid.Empty)
            {
                return depoimentoQuery.Where(x => x.Id == param.Id);
            }

            return depoimentoQuery.AsEnumerable().OrderBy(x => x.Sequencia);
        }

        public void Save(Models.Depoimento depoimento)
        {
            _context.Depoimentos.Add(depoimento);
        }

        public Models.Depoimento Update(Models.Depoimento depoimento)
        {
            var depoimentoDb = _context.Depoimentos.FirstOrDefault(x => x.Id == depoimento.Id);
            if (depoimentoDb == null)
            {
#pragma warning disable S112 // General exceptions should never be thrown
                throw new Exception(message: $"Depoimento não encotrado para atualizar: {depoimentoDb?.Id}");
#pragma warning restore S112 // General exceptions should never be thrown
            }

            if (!string.IsNullOrWhiteSpace(depoimento.Descricao))
                depoimentoDb.Descricao = depoimento.Descricao;

            if (!string.IsNullOrWhiteSpace(depoimento.Nome))
                depoimentoDb.Nome = depoimento.Nome;

            if (depoimento.Sequencia != 0)
                depoimentoDb.Sequencia = depoimento.Sequencia;

            return depoimentoDb;
        }
    }
}
