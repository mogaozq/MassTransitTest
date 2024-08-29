using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using MassTransitTest.Contracts;
using Microsoft.Extensions.Hosting;

namespace MassTransitTest.HostedServices
{
    internal class HelloMessageSenderService : BackgroundService
    {
        private readonly IBus _bus;

        public HelloMessageSenderService(IBus bus)
        {
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _bus.Publish(new HelloSent()
                {
                    Name = "Moga " + new Random().Next()
                });

                await Task.Delay(1000);
            }
        }
    }
}
