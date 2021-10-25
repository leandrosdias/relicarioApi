using AutoMapper;
using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.Home.Numeros;
using relicarioApi.Domain.Commands.Responses.Home.Numeros;
using relicarioApi.Repositories.Home.Numeros;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace relicarioApi.Domain.Handlers.Home.Numeros
{
    public class CreateNumerosHandler : IRequestHandler<CreateNumerosRequest, CreateNumerosResponse>
    {
        private readonly INumerosRepository _numerosRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public CreateNumerosHandler(INumerosRepository numerosRepository, IMapper mapper, IUnitOfWork uow)
        {
            _numerosRepository = numerosRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public Task<CreateNumerosResponse> Handle(CreateNumerosRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var Numeros = _mapper.Map<Models.Numeros>(request);

                _numerosRepository.Save(Numeros);
                _uow.Commit();
                return Task.FromResult(_mapper.Map<CreateNumerosResponse>(Numeros));
            }
            catch (Exception e)
            {
                _uow.Rollback();
                Debug.WriteLine("CreateNumerosResponse: " + e.Message + " Stack: " + e.StackTrace);
                return Task.FromResult(new CreateNumerosResponse(false, e.Message));
            }
        }
    }
}
