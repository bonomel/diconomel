using System;

namespace Squeezy.Core
{
    public class Dependency
    {
        public Type Type { get; set; }
        public LifetimeScope LifetimeScope { get; set; }
        public object Implementation { get; set; }
        public bool IsImplemented { get; set; }

        public Dependency(Type type, LifetimeScope lifetimeScope)
        {
            Type = type;
            LifetimeScope = lifetimeScope;
        }

        public void AddImplementation(object implementation)
        {
            Implementation = implementation;
            IsImplemented = true;
        }
    }
}
