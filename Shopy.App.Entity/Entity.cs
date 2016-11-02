using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopy.App.Entity
{
    public abstract class Entity
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public override bool Equals(object obj)
        {
            Entity other = obj as Entity;
            if (obj == null && (object)other == null) return true;
            if (obj == null || (object)other == null) return false;

            if (string.IsNullOrEmpty(other.Id) && string.IsNullOrEmpty(this.Id))
                return base.Equals(obj);
            return other.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {Id}";
        }

        public static bool operator ==(Entity entity, Entity other)
        {
            if (object.ReferenceEquals(entity, other))
                return true;
            if ((object)entity == null || (object)other == null)
                return false;

            return entity.Equals(other);
        }

        public static bool operator !=(Entity entity, Entity other)
        {
            return !(entity == other);
        }
    }
}
