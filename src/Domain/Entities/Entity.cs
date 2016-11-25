using System;
using Common;

namespace Domain.Entities
{
    public abstract class Entity : IEntity<Guid>
    {
        public Guid Id { get; set; }
    }
}