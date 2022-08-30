using Autofac;
using AutoMapper;
using dm_api.Application;
using dm_api.Application.Dtos;
using dm_api.Application.Interfaces;
using dm_api.Application.Mappers;
using dm_api.Application.Validations;
using dm_api.Domain.Core.Interfaces.Repositories;
using dm_api.Domain.Core.Interfaces.Services;
using dm_api.Domain.Service;
using dm_api.Infraestructure.Data.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dm_api.Infraestructure.CrossCutting.IoC
{
    public static class ConfigurationIoC
    {
        public static void Load(ContainerBuilder container)
        {
            container.RegisterType<ApplicationServiceClient>().As<IApplicationServiceClient>();
            container.RegisterType<ServiceClient>().As<IServiceClient>();
            container.RegisterType<RepositoryClient>().As<IRepositoryClient>();
            container.RegisterType<ClientRequestValidator>().As<IValidator<ClientRequest>>();
            container.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ClientRequestToModelClient());
                cfg.AddProfile(new ModelClientToClientResponse());
            }
            ));

            container.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
        }
    }
}
