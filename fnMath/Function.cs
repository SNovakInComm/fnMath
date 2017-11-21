using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fnMath
{
    interface Function<T>
    {
        T Evaluate(T x);

        T Evaluate(T[] X);
    }
}
