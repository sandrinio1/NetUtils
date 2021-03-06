using System;
using System.Collections.Generic;
using System.Linq;

namespace NetUtils
{
    public static class EnumExtensions
    {
        /// <summary>
        /// A FX 3.5 way to mimic the FX4 "HasFlag" method.
        /// </summary>
        /// <param name="variable">The tested enum.</param>
        /// <param name="value">The value to test.</param>
        /// <returns>True if the flag is set. Otherwise false.</returns>
        public static bool HasFlag(this Enum variable, Enum value)
        {
            // check if from the same type.
            if (variable.GetType() != value.GetType())
            {
                throw new ArgumentException("The checked flag is not from the same type as the checked variable.");
            }

            ulong num = Convert.ToUInt64(value);
            ulong num2 = Convert.ToUInt64(variable);

            return (num2 & num) == num;
        }
        public static IEnumerable<Type> GetSubTypes(this Enum enumType)
        {
            return Enum.GetValues(enumType.GetType()).Cast<object>().Cast<Type>().ToList();
        }

        public static IEnumerable<string> EnumerateNames(this Enum enumToEnumerate)
        {
            var names = new List<string>();
            foreach (var subType in Enum.GetValues(enumToEnumerate.GetType()))
            {
                names.Add(subType.ToString());
            }
            return names;
        }
    }
}