using System;

namespace ServerApi.Entities.Models
{
    public abstract class Entity
    {
        protected Entity() 
            => CreatedOn = DateTime.Now;

        public int Id { get; private set; }

        public DateTime CreatedOn { get; private set; }
    }
}