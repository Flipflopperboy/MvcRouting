using System;

namespace Flip.Web.Routing
{
    public static class ParameterBuilderExtensions
    {
        public static IParameterBuilder InRange<TValue>(this IParameterBuilder builder, TValue start, TValue end)
            where TValue : IComparable<TValue>
        {
            builder.AddConstraint(new RangeRouteConstraint<TValue>(start, end));
            return builder;
        }
    }
}