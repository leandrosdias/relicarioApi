using AutoMapper;
using MediatR;
using relicarioApi.Data;
using relicarioApi.Domain.Commands.Requests.Home.Numeros;
using relicarioApi.Domain.Commands.Responses.Home.Numeros;
using relicarioApi.Repositories.Home.Numeros;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using relicarioApi.Models;

namespace relicarioApi.Domain.Handlers.Home.Numeros
{
    public class ChangeNumerosHandler : IRequestHandler<ChangeNumerosRequest, ChangeNumerosResponse>
    {
        private readonly INumerosRepository _numerosRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ChangeNumerosHandler(INumerosRepository numerosRepository, IMapper mapper, IUnitOfWork uow)
        {
            _numerosRepository = numerosRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public Task<ChangeNumerosResponse> Handle(ChangeNumerosRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var Numeros = _mapper.Map<Models.Numeros>(request);
                var result = _numerosRepository.Update(Numeros);
                _uow.Commit();
                return Task.FromResult(_mapper.Map<ChangeNumerosResponse>(result));
            }
            catch (Exception e)
            {
                _uow.Rollback();
                Debug.WriteLine("ChangeNumerosHandler: " + e.Message + " Stack: " + e.StackTrace);
                return Task.FromResult(new ChangeNumerosResponse(false, e.Message));
            }
        }
    }
}

