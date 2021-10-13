using AutoMapper;
using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.Home.Valores;
using relicarioApi.Domain.Commands.Responses.Home.Valores;
using relicarioApi.Repositories.Home.Valores;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using relicarioApi.Models;

namespace relicarioApi.Domain.Handlers.Home.Valores
{
    public class ChangeValoresHandler : IRequestHandler<ChangeValoresRequest, ChangeValoresResponse>
    {
        private readonly IValoresRepository _valoresRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ChangeValoresHandler(IValoresRepository valoresRepository, IMapper mapper, IUnitOfWork uow)
        {
            _valoresRepository = valoresRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public Task<ChangeValoresResponse> Handle(ChangeValoresRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var valores = _mapper.Map<Models.Valores>(request);
                var result = _valoresRepository.Update(valores);
                _uow.Commit();
                return Task.FromResult(_mapper.Map<ChangeValoresResponse>(result));
            }
            catch (Exception e)
            {
                _uow.Rollback();
                Debug.WriteLine("ChangeValoresHandler: " + e.Message + " Stack: " + e.StackTrace);
                return Task.FromResult(new ChangeValoresResponse(false, e.Message));
            }
        }
    }
}

