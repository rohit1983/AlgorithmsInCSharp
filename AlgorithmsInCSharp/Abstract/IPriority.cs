using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public interface IPriority<T> : IComparable
    {
        int Priority { get; set; }
        T item { get; set; }
    }
}
