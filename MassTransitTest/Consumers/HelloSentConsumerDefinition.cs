using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit;

namespace MassTransitTest.Consumers
{
    public class HelloSentConsumerDefinition : ConsumerDefinition<HelloSentConsumer>
    {
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<HelloSentConsumer> consumerConfigurator,
            IRegistrationContext context)
        {
            consumerConfigurator.UseMessageRetry(c => c.Interval(3, 1000));
        }
    }
}

