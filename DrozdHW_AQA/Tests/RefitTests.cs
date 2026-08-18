using System;
using System.Collections.Generic;
using System.Text;
using Refit;
using Microsoft.Extensions.DependencyInjection;
using DrozdHW_AQA.Interfaces;

namespace DrozdHW_AQA.Tests.Tests
{
    public class RefitTests
    {
        private IUserApi api;

        [OneTimeSetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddRefitClient<IUserApi>()
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri("https://reqres.in/api");
                });
            var provider = services.BuildServiceProvider();
            api = provider.GetRequiredService<IUserApi>();
        }

    }
}
