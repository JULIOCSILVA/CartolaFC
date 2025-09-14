using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Cartola.Helper.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Get the Description from the DescriptionAttribute.
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum enumValue)
        {
            var member = enumValue.GetType()
                       .GetMember(enumValue.ToString())
                       .FirstOrDefault();

            return member?.GetCustomAttribute<DescriptionAttribute>()?
                       .Description ?? string.Empty;
        }
    }
}
