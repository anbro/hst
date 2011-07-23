using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Hst.Core.Storage.Ef
{
    public static class EfDynamicProxyAssemblies
    {
        private static readonly object _lock = new object();
        private static readonly HashSet<Assembly> _assembliesWithDynamicProxies = new HashSet<Assembly>();

        private static readonly HashSet<Type> _dynamixProxies = new HashSet<Type>();

        static EfDynamicProxyAssemblies()
        {
            AppDomain.CurrentDomain.AssemblyLoad += CurrentDomain_AssemblyLoad;
        }

        private static void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {
            if (args == null || args.LoadedAssembly == null || string.IsNullOrEmpty(args.LoadedAssembly.FullName))
                return;

            lock (_lock)
            {
                if (args.LoadedAssembly.FullName.StartsWith("EntityFrameworkDynamicProxies") &&
                    !_assembliesWithDynamicProxies.Contains(args.LoadedAssembly))
                {
                    //Types aren't generated yet, so we can't add them to _dynamixEntityProxies
                    _assembliesWithDynamicProxies.Add(args.LoadedAssembly);
                }
            }
        }

        public static IEnumerable<Type> GetTypes()
        {
            lock (_lock)
            {
                if (_assembliesWithDynamicProxies.Count < 1)
                    return new Type[] { };

                var types = _assembliesWithDynamicProxies.SelectMany(a => a.GetTypes());
                _dynamixProxies.UnionWith(types);
            }

            return _dynamixProxies;
        }
    }
}
