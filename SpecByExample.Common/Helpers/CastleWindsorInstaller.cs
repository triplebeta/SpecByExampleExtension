using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.MicroKernel.SubSystems.Configuration;
using SpecByExample.Common;

namespace SpecByExample.Common
{
    /// <summary>
    /// Installer
    /// </summary>
    public class CastleWindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Register all Selenium Page Objects
            container.Register(Classes.FromAssemblyInDirectory(new AssemblyFilter(Environment.CurrentDirectory)).BasedOn<BaseSeleniumPage>());
        }
    }
}
