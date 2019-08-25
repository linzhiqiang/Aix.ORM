using Aix.ORM.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aix.ORM.Utils
{
    internal static class AssertUtils
    {
        public static void IsTrue(bool condition, string errorText)
            => IsTrue(condition, ORMErrorCodes.COMMON_BIZ_ERROR_CODE, errorText);

        public static void IsTrue(bool condition, int code, string errorText)
        {
            if (!condition)
            {
                throw new ORMException(code, errorText ?? "异常");
            }
        }

        public static void IsNotNull(object obj, string errorText)
        {
            IsTrue(obj != null, errorText);
        }

        public static void IsNotNull(object obj, int code, string errorText)
        {
            IsTrue(obj != null, code, errorText);
        }

        public static void IsNotEmpty(string obj, string errorText)
        {
            IsTrue(!string.IsNullOrEmpty(obj), errorText);
        }
        public static void IsNotEmpty(string obj, int code, string errorText)
        {
            IsTrue(!string.IsNullOrEmpty(obj), code, errorText);
        }

        public static void ThrowException(int code, string errorText)
        {
            IsTrue(false, errorText);
        }

    }
}
