﻿namespace InfoSystem.Core.Entities
{
    public abstract class BaseEntity : Identity
    {
        public BaseEntity() { }
        public string EntityId { get; set; }
    }
}
