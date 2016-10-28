using Microsoft.AspNetCore.Hosting;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Fabric;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace EasyMaintain.CoreMVCWeb
{
    public class Program
    {
        // Entry point for the application.
        public static void Main(string[] args)
        {
            ServiceRuntime.RegisterServiceAsync("CoreMVCWebType", context => new WebHostingService(context, "ServiceEndpoint")).GetAwaiter().GetResult();

            Thread.Sleep(Timeout.Infinite);
        }

        /// <summary>
        /// A specialized stateless service for hosting ASP.NET Core web apps.
        /// </summary>
        internal sealed class WebHostingService : StatelessService, ICommunicationListener
        {
            private readonly string _endpointName;

            private IWebHost _webHost;

            public WebHostingService(StatelessServiceContext serviceContext, string endpointName)
                : base(serviceContext)
            {
                _endpointName = endpointName;
            }

            #region StatelessService

            protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
            {
                return new[] { new ServiceInstanceListener(_ => this) };
            }

            #endregion StatelessService

            #region ICommunicationListener

            void ICommunicationListener.Abort()
            {
                _webHost?.Dispose();
            }

            Task ICommunicationListener.CloseAsync(CancellationToken cancellationToken)
            {
                _webHost?.Dispose();

                return Task.FromResult(true);
            }

            Task<string> ICommunicationListener.OpenAsync(CancellationToken cancellationToken)
            {
                var endpoint = FabricRuntime.GetActivationContext().GetEndpoint(_endpointName);

                string serverUrl = $"{endpoint.Protocol}://{FabricRuntime.GetNodeContext().IPAddressOrFQDN}:{endpoint.Port}";

                _webHost = new WebHostBuilder().UseKestrel()
                                               .UseContentRoot(Directory.GetCurrentDirectory())
                                               .UseStartup<Startup>()
                                               .UseUrls(serverUrl)
                                               .Build();

                _webHost.Start();

                return Task.FromResult(serverUrl);
            }

      /*      private string nginxProcessName = "";
        private string getConfigPath()
        {
            var codePackage = this.Context.CodePackageActivationContext.CodePackageName;
            var configPackage = this.Context.CodePackageActivationContext.GetConfigurationPackageObject("Config");
            var codePath = this.Context.CodePackageActivationContext.GetCodePackageObject(codePackage).Path;
            return Path.Combine(configPackage.Path, "conf\\nginx.conf");
        }
        private bool isNginxRunning()
        {
            if (!string.IsNullOrEmpty(nginxProcessName))
            {
                var processes = Process.GetProcessesByName(nginxProcessName);
                return processes.Length != 0;
            }
            else
                return false;
        }
        private void launchNginxProcess(string arguments)
        {
            var codePackage = this.Context.CodePackageActivationContext.CodePackageName;
            var configPackage = this.Context.CodePackageActivationContext.GetConfigurationPackageObject("Config");
            var codePath = this.Context.CodePackageActivationContext.GetCodePackageObject(codePackage).Path;
            var res = File.Exists(Path.Combine(codePath, "nginx-1.11.5.exe"));
            var nginxStartInfo = new ProcessStartInfo(Path.Combine(codePath, "nginx-1.11.5.exe"));
            nginxStartInfo.WorkingDirectory = codePath;
            nginxStartInfo.UseShellExecute = false;
            nginxStartInfo.Arguments = arguments;
            var nginxProcess = new Process();
            nginxProcess.StartInfo = nginxStartInfo;
            nginxProcess.Start();
            nginxProcessName = nginxProcess.ProcessName;
        }

            protected override async Task RunAsync(CancellationToken cancellationToken)
            {
                this.Context.CodePackageActivationContext.ConfigurationPackageModifiedEvent += CodePackageActivationContext_ConfigurationPackageModifiedEvent;

                launchNginxProcess("-c " + getConfigPath());

                while (true)
                {
                    if (cancellationToken.IsCancellationRequested)
                        launchNginxProcess("-s quit");
                    cancellationToken.ThrowIfCancellationRequested();
                    await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
                    if (!isNginxRunning())
                        launchNginxProcess("-c " + getConfigPath());
                }
            }

            private void CodePackageActivationContext_ConfigurationPackageModifiedEvent(object sender, PackageModifiedEventArgs<ConfigurationPackage> e)
            {
                launchNginxProcess("-s quit");
                while (isNginxRunning())
                    Task.Delay(TimeSpan.FromSeconds(1));
                launchNginxProcess("-c " + Path.Combine(e.NewPackage.Path, "conf\\nginx.conf"));
            }
            */
            #endregion ICommunicationListener
        }
    }
}
