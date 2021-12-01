using System;
using System.Collections.Generic;
using System.Linq;

namespace Squeezy.Core
{
    public class DependencyContainer
    {
        private readonly List<Dependency> _dependencies = new();

        public void AddSingleton<T>()
        {
            _dependencies.Add(new Dependency(typeof(T), LifetimeScope.Singleton));
        }

        public void AddTransient<T>()
        {
            _dependencies.Add(new Dependency(typeof(T), LifetimeScope.Transient));
        }

        public Dependency GetDependency(Type type)
        {
            return _dependencies.First(t => t.Type.Name == type.Name);
        }
    }
}
