using System;
using MassTransit;

namespace MassTransitTesting
{
    public interface IMessage : CorrelatedBy<Guid>
    {
    }
}
