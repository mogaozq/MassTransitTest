using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;
using MassTransitTest.Contracts;
using Microsoft.Extensions.Logging;

namespace MassTransitTest.Consumers
{
    public class HelloSentConsumer : IConsumer<HelloSent>
    {
        private readonly ILogger<HelloSentConsumer> _logger;

        public HelloSentConsumer(ILogger<HelloSentConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<HelloSent> context)
        {
            _logger.LogInformation($"Helloooo {context.Message.Name}");
            return Task.CompletedTask;
        }
    }
}
