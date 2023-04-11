namespace Dane
{
    public class DataApiFactory
    {
        public static AbstractDataApi CreateDataApi() { return new DataApi(); }

    }
}
