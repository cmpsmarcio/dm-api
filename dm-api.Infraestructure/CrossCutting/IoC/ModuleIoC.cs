using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dm_api.Infraestructure.CrossCutting.IoC
{
    public class ModuleIoC: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            ConfigurationIoC.Load(builder);
        }
    }
}
