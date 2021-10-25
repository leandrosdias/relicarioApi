using relicarioApi.Domain.Commands.Requests.System.Parameter;
using relicarioApi.Models;
using System.Collections.Generic;

namespace relicarioApi.Repositories.System.Parameter
{
    public interface IParametersRepository
    {
        void Save(Models.Parameters parameters);
        IEnumerable<Models.Parameters> Get(GetParametersRequest param);
        Models.Parameters GetByParam(string param);
        void Delete(DeleteParametersRequest request);
        Models.Parameters Update(Models.Parameters parameters);
    }
}
