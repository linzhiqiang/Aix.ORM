using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aix.ORM.Utils
{
    /// <summary>
    /// 创建对象 建议使用CreateInstanceDelegate 进行缓存
    /// 执行方法 建议使用 CreateDelegate<T> 进行缓存
    /// </summary>
    public static class MethodUtils
    {
        /// <summary>
        /// 创建委托  T=Action<int>,Func<string,Task>......  执行方法时 建议使用这个，先进行缓存再调用 性能最好
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <param name="methodInfo"></param>
        /// <param name="genericMethodParameterType"></param>
        /// <returns></returns>
        public static T CreateDelegate<T>(object target, MethodInfo methodInfo, Type[] genericMethodParameterType = null)
        {
            if (methodInfo.IsGenericMethod)
            {
                methodInfo = methodInfo.MakeGenericMethod(genericMethodParameterType);
            }
            var parameterExpression = GetParameterExpression(methodInfo);

            MethodCallExpression methodCall =
                   methodInfo.IsStatic
                   ? Expression.Call(methodInfo, parameterExpression)
                   : Expression.Call(Expression.Constant(target), methodInfo, parameterExpression);

            var lambdaDelegate = Expression.Lambda<T>(methodCall, parameterExpression).Compile();

            return lambdaDelegate;
        }

        /// <summary>
        /// 创建实例委托  CreateInstanceDelegate<Func<string,string>>();
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">类型</param>
        /// <param name="param">构造函数参数类型</param>
        /// <returns></returns>
        public static T CreateInstanceDelegate<T>(Type type, Type[] param)
        {
            var constructor = type.GetConstructor(param);
            var paramExpression = GetParameterExpression(constructor);
            NewExpression newExp = Expression.New(constructor, paramExpression);
            var lambdaExp = Expression.Lambda<T>(newExp, paramExpression);
            return lambdaExp.Compile();
        }

        public static ConstructorInfo GetConstructor(Type type, Type[] param)
        {
            var constructor = type.GetConstructor(param);
            //创建对象 
            // constructor.Invoke();
            //Activator.CreateInstance();
            return constructor;
        }

     

        #region
        private static List<ParameterExpression> GetParameterExpression(MethodBase methodInfo)
        {
            var parameterExpression = new List<ParameterExpression>();
            foreach (var item in methodInfo.GetParameters())
            {
                ParameterExpression paraObj = Expression.Parameter(item.ParameterType);
                parameterExpression.Add(paraObj);
            }

            return parameterExpression;
        }

        
        #endregion

    }
}
