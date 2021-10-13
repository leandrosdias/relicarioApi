using AutoMapper;
using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.Home.Valores;
using relicarioApi.Domain.Commands.Responses.Home.Valores;
using relicarioApi.Repositories.Home.Valores;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.Home.Valores
{
    public class CreateValoresHandler : IRequestHandler<CreateValoresRequest, CreateValoresResponse>
    {
        private readonly IValoresRepository _valoresRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public CreateValoresHandler(IValoresRepository valoresRepository, IMapper mapper, IUnitOfWork uow)
        {
            _valoresRepository = valoresRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public Task<CreateValoresResponse> Handle(CreateValoresRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var valores = _mapper.Map<Models.Valores>(request);

                _valoresRepository.Save(valores);
                _uow.Commit();
                return Task.FromResult(_mapper.Map<CreateValoresResponse>(valores));
            }
            catch (Exception e)
            {
                _uow.Rollback();
                Debug.WriteLine("CreateValoresResponse: " + e.Message + " Stack: " + e.StackTrace);
                return Task.FromResult(new CreateValoresResponse(false, e.Message));
            }
        }
    }
}
