using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.System.Parameter;
using relicarioApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace relicarioApi.Repositories.System.Parameter
{
    public class ParametersRepository : IParametersRepository
    {
        private readonly DataContext _context;

        public ParametersRepository(DataContext context)
        {
            _context = context;
        }

        public void Delete(DeleteParametersRequest request)
        {
            var parameters = _context.Parameters.FirstOrDefault(x => x.Id == request.Id);

            if (parameters != null)
            {
                _context.Parameters.Remove(parameters);
            }
        }


        public IEnumerable<Parameters> Get(GetParametersRequest param)
        {
            var parametersQuery = _context.Parameters.AsQueryable();

            if (param.Id != Guid.Empty)
            {
                return parametersQuery.Where(x => x.Id == param.Id);
            }

            if (!string.IsNullOrWhiteSpace(param.Param))
            {
                return parametersQuery.Where(x => x.Param == param.Param);
            }

            return parametersQuery.AsEnumerable();
        }

        public Parameters GetByParam(string param)
        {
            return _context.Parameters.FirstOrDefault(x => x.Param == param);
        }

        public void Save(Parameters parameters)
        {
            _context.Parameters.Add(parameters);
        }

        public Parameters Update(Parameters parameters)
        {
            var ParametersDb = _context.Parameters.FirstOrDefault(x => x.Id == parameters.Id);
            if (ParametersDb == null)
            {
#pragma warning disable S112 // General exceptions should never be thrown
                throw new Exception(message: $"Parameters não encotrado para atualizar: {ParametersDb?.Id}");
#pragma warning restore S112 // General exceptions should never be thrown
            }

            ParametersDb.Param = parameters.Param;
            ParametersDb.Value = parameters.Value;

            return ParametersDb;
        }
    }
}
