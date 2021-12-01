using System;
using System.Collections.Generic;
using System.Linq;

namespace Squeezy.Core
{
    public class DependencyContainer
    {
        private readonly List<Type> dependencies = new();

        public void AddDependency(Type type)
        {
            dependencies.Add(type);
        }

        public void AddDependency<T>()
        {
            dependencies.Add(typeof(T));
        }

        public Type GetDependency(Type type)
        {
            return dependencies.First(t => t.Name == type.Name);
        }
    }
}
