using System;
using System.Collections.Generic;
using System.Text;

namespace Logika
{
    public class LogicApiFactory
    {

        public static AbstractLogicApi CreateLogicApi() { return new LogicApi(); }
    }
}
