using System;
using Common;

namespace Domain.DomainEvents
{
    public class TestCreated : IEvent
    {
        public Guid TestId { get; private set; }

        public TestCreated(Guid testId)
        {
            TestId = testId;
        }
    }
}