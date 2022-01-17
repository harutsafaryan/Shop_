using Microsoft.Extensions.DependencyInjection;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using XmlManager;

namespace Products
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var mainForm = serviceProvider.GetRequiredService<Shop>();
                Application.Run(mainForm);
            }

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Shop());
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddXmlManager()
                    .AddServices()
                    .AddScoped<Shop>();
        }
    }
}
