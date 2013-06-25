using System;

namespace Flip.Web.Routing
{
    public class RangeRouteConstraint<TValue> : RequiredRouteConstraint<TValue>
        where TValue : IComparable<TValue>
    {
        public RangeRouteConstraint(TValue start, TValue end)
        {
            if (start == null)
            {
                GC.SuppressFinalize(this);
                throw new ArgumentException("start may not be null");
            } 
            if (end == null)
            {
                GC.SuppressFinalize(this);
                throw new ArgumentException("end may not be null");
            }
            if (start.CompareTo(end) >= 0)
            {
                GC.SuppressFinalize(this);
                throw new ArgumentException("start must be less than end");
            }
            Start = start;
            End = end;
        }

        public TValue Start { get; private set; }
        public TValue End { get; private set; }

        protected override bool MatchValue(TValue value)
        {
            return Start.CompareTo(value) >= 0 && End.CompareTo(value) <= 0;
        }
    }
}