using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aix.ORM.Utils
{
    /// <summary>
    ///通用方法调用委托
    /// </summary>
    /// <param name="instance">调用方法的对象 静态方法为null</param>
    /// <param name="parameters">参数列表</param>
    /// <returns></returns>
    public delegate object MethodInvoker(object instance, params object[] parameters);

    public delegate object ConstructorInvoker(params object[] parameters);

    public static class MethodUtils
    {
        /// <summary>
        /// 创建实例委托 可以进行缓存，提高效率  CreateInstanceDelegate<Func<构造参数1,构造参数2，...,创建的对象>>();
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">类型</param>
        /// <param name="param">构造函数参数类型</param>
        /// <returns></returns>
        public static T CreateInstanceDelegate<T>(Type type, Type[] param, Type[] genericMethodParameterType = null)
        {
            // if (type.IsConstructedGenericType)
            if (type.IsGenericTypeDefinition)
            {
                type = type.MakeGenericType(genericMethodParameterType);
            }
            var constructor = type.GetConstructor(param);

            var paramExpression = GetParameterExpression(constructor);
            NewExpression newExp = Expression.New(constructor, paramExpression);
            var lambdaExp = Expression.Lambda<T>(newExp, paramExpression);
            return lambdaExp.Compile();
        }

        /// <summary>
        /// 创建构造函数委托
        /// </summary>
        /// <param name="type"></param>
        /// <param name="param"></param>
        /// <param name="genericMethodParameterType"></param>
        /// <returns></returns>
        public static ConstructorInvoker CreateInstanceCommonDelegate(Type type, Type[] param, Type[] genericMethodParameterType = null)
        {
            if (type.IsGenericTypeDefinition)
            {
                type = type.MakeGenericType(genericMethodParameterType);
            }
            var constructor = type.GetConstructor(param);
            //转参数
            // 转换委托方法参数 参数 object[]
            var parametersExpr = Expression.Parameter(typeof(object[]));

            //转换方法的参数 把传入的object[]参数转为原来的类型
            var originalParameterExpr = new List<Expression>();
            int index = 0;
            foreach (var item in constructor.GetParameters())
            {
                originalParameterExpr.Add(Expression.Convert(Expression.ArrayIndex(parametersExpr, Expression.Constant(index)), item.ParameterType));
                index++;
            }
            NewExpression newExp = Expression.New(constructor, originalParameterExpr);
            var lambdaExp = Expression.Lambda<ConstructorInvoker>(newExp, parametersExpr);
            return lambdaExp.Compile();
        }

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
            if (methodInfo.IsGenericMethodDefinition)
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
        /// 把任何方法调用，转换为public delegate object MethodInvoker(object instance, params object[] parameters);
        /// 转为异步调用时   var newResult= await ResultAsync(result, methodInfo.ReturnType);
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <param name="genericMethodParameterType"></param>
        /// <returns></returns>
        public static MethodInvoker CreateCommonDelegate(MethodInfo methodInfo, Type[] genericMethodParameterType = null)
        {
            if (methodInfo.IsGenericMethodDefinition)
            {
                methodInfo = methodInfo.MakeGenericMethod(genericMethodParameterType);
            }

            // 转换委托对象参数 target为object
            var targetParameterExpr = Expression.Parameter(typeof(object));
            // 转换委托方法参数 参数 object[]
            var parametersExpr = Expression.Parameter(typeof(object[]));

            //转换方法的参数 把传入的object[]参数转为原来的类型
            var originalParameterExpr = new List<Expression>();
            int index = 0;
            foreach (var item in methodInfo.GetParameters())
            {
                originalParameterExpr.Add(Expression.Convert(Expression.ArrayIndex(parametersExpr, Expression.Constant(index)), item.ParameterType));
                index++;
            }

            Expression methodCallExpr =
                  methodInfo.IsStatic
                  ? Expression.Call(methodInfo, originalParameterExpr)
                  : Expression.Call(Expression.Convert(targetParameterExpr, methodInfo.DeclaringType), methodInfo, originalParameterExpr);

            //methodCall = ConvertReturn(methodCall, typeof(object));
            methodCallExpr = ConvertReturnToObject(methodCallExpr);
            var lambdaDelegate = Expression.Lambda<MethodInvoker>(methodCallExpr, targetParameterExpr, parametersExpr).Compile();
            return lambdaDelegate;
        }

        /// <summary>
        /// 异步反射调用方法
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="methodInfo"></param>
        /// <param name="parameters"></param>
        /// <param name="genericMethodParameterType"></param>
        /// <returns></returns>
        public static object InvokeMethodAsync(object obj, MethodInfo methodInfo, object[] parameters, Type[] genericMethodParameterType = null)
        {
            if (methodInfo.IsGenericMethodDefinition)
            {
                // 这里要求泛型参数的具体类型 如 T M1<T>(T item);//即方法名称后尖括号内的具体类型
                methodInfo = methodInfo.MakeGenericMethod(genericMethodParameterType);
            }

            var result = methodInfo.Invoke(obj, parameters);
            return result;
            //Type returnType = methodInfo.ReturnType;
            //return await ResultAsync(result, returnType);
        }

        /// <summary>
        /// 结果转异步 一般是直接转了 如 result as Task<int>,一般框架中通用调用时会用到
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static async Task<object> ResultAsync(object value, Type type)
        {
            if (value == null) return null;
            if (type == typeof(Task))
            {
                await (value as Task);
                return null;
            }
            else if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(Task<>))//IsGenericType
            {
                return type.GetProperty("Result").GetValue(value);
                //dynamic dynTask = value;//安装 Microsoft.CSharp
                //return await dynTask;
            }
            return value;
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

        private static Expression ConvertReturnToObject(Expression methodCallExpr)
        {
            if (methodCallExpr.Type == typeof(void))
            {
                // return Expression.Block(methodCall, Expression.Constant(null));
                return Expression.Block(methodCallExpr, Expression.Default(typeof(object))); //都可以
            }
            else if (methodCallExpr.Type.IsValueType) //引用类型都是object就不用转了
            {
                return Expression.Convert(methodCallExpr, typeof(object));
            }
            return methodCallExpr;
        }
        private static Expression ConvertReturn(Expression methodCallExpr, Type ConvertType)
        {
            if (methodCallExpr.Type == typeof(void))
            {
                // 添加默认返回值。
                return Expression.Block(methodCallExpr, Expression.Default(ConvertType));
            }

            if (ConvertType == typeof(void))
            {
                // return methodCall;//好像void返回原始的也可以
                return Expression.Block(methodCallExpr, Expression.Empty());
            }

            // 需要强制转换。
            return Expression.Convert(methodCallExpr, ConvertType);
        }

        private static ConstructorInfo GetConstructor(Type type, Type[] param)
        {
            var constructor = type.GetConstructor(param);
            //创建对象 
            // constructor.Invoke();
            //Activator.CreateInstance();
            return constructor;
        }
        /*
       private static List<ParameterExpression> GetParameterExpression(Type[] param)
       {
           var parameterExpression = new List<ParameterExpression>();
           foreach (var item in param)
           {
               ParameterExpression paraObj = Expression.Parameter(item);
               parameterExpression.Add(paraObj);
           }

           return parameterExpression;
       }
       */
        #endregion
    }
}
