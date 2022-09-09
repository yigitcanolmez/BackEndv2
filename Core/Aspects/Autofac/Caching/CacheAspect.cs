using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager  cacheManager;
        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            cacheManager = ServiceTool.serviceProvider.GetService<ICacheManager>();

        }
        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            if (cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = cacheManager.Get(key);
                return;
            }
            invocation.Proceed();
            cacheManager.Add(key, invocation.ReturnValue, _duration);
        }

    }
}
