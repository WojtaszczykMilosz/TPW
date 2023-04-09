using System;
using System.Collections.Generic;
using System.Text;

namespace Dane
{
    public class DataApiFactory
    {
        public static AbstractDataApi CreateDataApi() { return new DataApi(); }

    }
}
