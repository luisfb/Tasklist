using System.Collections.Generic;

namespace Tasklist.Domain.Entities
{
    public abstract class EntityBase
    {
        public long Id { get; protected set; }
        public IList<string> ValidationErrors { get; protected set; } = new List<string>();
        public abstract bool IsValid();
    }
}
