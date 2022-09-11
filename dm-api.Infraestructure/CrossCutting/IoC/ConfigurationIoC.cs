using Autofac;
using AutoMapper;
using dm_api.Application;
using dm_api.Application.Dtos;
using dm_api.Application.Interfaces;
using dm_api.Application.Mappers;
using dm_api.Application.Validations;
using dm_api.Domain.Core.Interfaces.Config;
using dm_api.Domain.Core.Interfaces.Repositories;
using dm_api.Domain.Core.Interfaces.Services;
using dm_api.Domain.Service;
using dm_api.Infraestructure.Data.Repositories;
using dm_api.Infraestructure.CrossCutting.Config;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace dm_api.Infraestructure.CrossCutting.IoC
{
    public static class ConfigurationIoC
    {
        public static void Load(ContainerBuilder container)
        {
            container.RegisterType<Settings>().As<ISettings>();
            // Services
            container.RegisterType<ApplicationServiceClient>().As<IApplicationServiceClient>();
            container.RegisterType<ApplicationServiceUser>().As<IApplicationServiceUser>();
            container.RegisterType<ApplicationServiceToken>().As<IApplicationServiceToken>();
            container.RegisterType<ServiceClient>().As<IServiceClient>();
            container.RegisterType<ServiceUser>().As<IServiceUser>();
            container.RegisterType<TokenService>().As<ITokenService>();
            // Repositories
            container.RegisterType<RepositoryClient>().As<IRepositoryClient>();
            container.RegisterType<RepositoryUser>().As<IRepositoryUser>();
            // Validation
            container.RegisterType<ClientRequestValidator>().As<IValidator<ClientRequest>>();
            // Mapper
            container.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ClientRequestToModelClient());
                cfg.AddProfile(new ModelClientToClientResponse());
            }
            ));

            // Register Container
            container.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
        }
    }
}
