using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace photosynthesis.state
{
    public enum Token : int
    {
        None = 0,
        SmallTree = 1,
        MediumTree = 2,
        LargeTree = 3,
        Seed = 4,
    }
}
