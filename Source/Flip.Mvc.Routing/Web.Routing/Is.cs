using System.Web.Mvc;

namespace Flip.Web.Routing
{
    public static class Is
    {
        public static ParameterBuilder Optional()
        {
            return new ParameterBuilder {Default = UrlParameter.Optional};
        }

        public static ParameterBuilder Required()
        {
            return new ParameterBuilder();
        }

        public static ParameterBuilder Required<TValue>(TValue defaultValue)
        {
            return new ParameterBuilder {Default = defaultValue};
        }
    }
}