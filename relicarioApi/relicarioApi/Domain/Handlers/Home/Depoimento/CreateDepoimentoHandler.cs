using AutoMapper;
using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.Home.Depoimento;
using relicarioApi.Domain.Commands.Responses.Home.Depoimento;
using relicarioApi.Repositories.Home.Depoimento;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.Home.Depoimento
{
    public class CreateDepoimentoHandler : IRequestHandler<CreateDepoimentoRequest, CreateDepoimentoResponse>
    {
        private readonly IDepoimentoRepository _depoimentoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public CreateDepoimentoHandler(IDepoimentoRepository depoimentoRepository, IMapper mapper, IUnitOfWork uow)
        {
            _depoimentoRepository = depoimentoRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public Task<CreateDepoimentoResponse> Handle(CreateDepoimentoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var Depoimento = _mapper.Map<Models.Depoimento>(request);

                _depoimentoRepository.Save(Depoimento);
                _uow.Commit();
                return Task.FromResult(_mapper.Map<CreateDepoimentoResponse>(Depoimento));
            }
            catch (Exception e)
            {
                _uow.Rollback();
                Debug.WriteLine("CreateDepoimentoResponse: " + e.Message + " Stack: " + e.StackTrace);
                return Task.FromResult(new CreateDepoimentoResponse(false, e.Message));
            }
        }
    }
}
