using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aix.ORM.Exceptions
{
    public class ORMErrorCodes
    {
        /// <summary>
        /// 一般错误业务异常
        /// </summary>
        public const int COMMON_BIZ_ERROR_CODE = -100;

        /// <summary>
        /// 内部错误
        /// </summary>
        public const int INTETNAL_ERROR_CODE = -500;
    }
    public class ORMException : Exception
    {
        public int Code { get; set; }
        public ORMException(int code, string message) : base(message)
        {
            this.Code = code;
        }
    }
}
