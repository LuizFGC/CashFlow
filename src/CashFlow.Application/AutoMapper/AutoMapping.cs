using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.AutoMapper;

public class AutoMapping : Profile
{

        public AutoMapping()
        {
                RequestToEntity();
                EntityToResponse();
        }
        
        private void RequestToEntity()
        {
                CreateMap<RequestDespesa, Despesa>();
                CreateMap<RequestCreateUser, User>()
                        .ForMember(dest => dest.Password, config => config.Ignore());
        }

        private void EntityToResponse()
        {
                CreateMap<Despesa, ResponseRegistrarDespesa>();
                CreateMap<Despesa, ResponseShortDespesa>();
                CreateMap<Despesa, ResponseDespesaById>();
                CreateMap<User, ResponseCreateUser>();
                
        }
}

