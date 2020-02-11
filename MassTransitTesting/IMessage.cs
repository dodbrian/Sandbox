using System;
using MassTransit;

namespace MassTransitTest
{
    public interface IMessage : CorrelatedBy<Guid>
    {
    }
}
