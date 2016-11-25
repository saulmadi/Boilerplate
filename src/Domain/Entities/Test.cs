using System;

namespace Domain.Entities
{
    public class Test : Entity
    {
        public Test(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; protected set; }
    }
}