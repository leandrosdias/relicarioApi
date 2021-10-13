using relicarioApi.Domain.Commands.Requests.Home.Valores;
using relicarioApi.Models;
using System.Collections.Generic;

namespace relicarioApi.Repositories.Home.Valores
{
    public interface IValoresRepository
    {
        void Save(Models.Valores valores);
        IEnumerable<Models.Valores> Get(GetValoresRequest param);
        void Delete(DeleteValoresRequest request);
        Models.Valores Update(Models.Valores valores);
    }
}
