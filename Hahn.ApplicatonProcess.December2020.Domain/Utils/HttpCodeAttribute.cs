using System;

namespace Hahn.ApplicatonProcess.December2020.Domain.Utils
{
    [AttributeUsage(AttributeTargets.Field)]
    public class HttpCodeAttribute : Attribute
    {
        public HttpCodeAttribute(int value)
        {
            Value = value;
        }

        public int Value { get; }

    }
}
