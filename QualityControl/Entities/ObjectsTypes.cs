using System;
using System.Collections.Generic;

namespace QualityControl.Entities
{
    public partial class ObjectsTypes
    {
        public ObjectsTypes()
        {
            Objects = new HashSet<Objects>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Objects> Objects { get; set; }
    }
}
