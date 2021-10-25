using relicarioApi.Domain.Commands.Requests.Home.Numeros;
using relicarioApi.Models;
using System.Collections.Generic;

namespace relicarioApi.Repositories.Home.Numeros
{
    public interface INumerosRepository
    {
        void Save(Models.Numeros numeros);
        IEnumerable<Models.Numeros> Get(GetNumerosRequest param);
        void Delete(DeleteNumerosRequest request);
        Models.Numeros Update(Models.Numeros numeros);
    }
}
