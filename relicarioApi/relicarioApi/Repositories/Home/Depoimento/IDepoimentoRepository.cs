using relicarioApi.Domain.Commands.Requests.Home.Depoimento;
using System.Collections.Generic;

namespace relicarioApi.Repositories.Home.Depoimento
{
    public interface IDepoimentoRepository
    {
        void Save(Models.Depoimento depoimento);
        IEnumerable<Models.Depoimento> Get(GetDepoimentoRequest param);
        void Delete(DeleteDepoimentoRequest request);
        Models.Depoimento Update(Models.Depoimento depoimento);
    }
}
