using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DataContracts.Abstact
{
    public abstract class CollectionFilterDto
    {
        public int Skip { get; set; }

        public int Take { get; set; } = 36;
    }
}
