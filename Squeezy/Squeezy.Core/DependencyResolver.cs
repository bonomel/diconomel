using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Squeezy.Core
{
    public class DependencyResolver
    {
        private readonly DependencyContainer _container;

        public DependencyResolver(DependencyContainer container)
        {
            this._container = container;
        }

        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }

        public object GetService(Type type)
        {
            Dependency dependency = _container.GetDependency(type);
            ConstructorInfo constructor = dependency.Type.GetConstructors().Single(); // only one constructor is allowed for services
            ParameterInfo[] parameters = constructor.GetParameters();

            var parameterImplementations = new object[parameters.Length];

            if (parameters.Length > 0)
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    // recursively get each dependency and each of their dependencies
                    parameterImplementations[i] = GetService(parameters[i].ParameterType);
                }

                // return object using instantiated objects in its constructor
                return Activator.CreateInstance(dependency.Type, parameterImplementations);
            }

            return CreateImplementation(dependency, t => Activator.CreateInstance(t, parameterImplementations));
        }

        public object CreateImplementation(Dependency dependency, Func<Type, object> factory)
        {
            // if the dependency has already been implemented, return it
            if (dependency.IsImplemented)
            {
                return dependency.Implementation;
            }

            // otherwise, create it
            var implementation = factory(dependency.Type);

            // and store it inside the dependency if it is a singleton
            if (dependency.LifetimeScope == LifetimeScope.Singleton)
            {
                dependency.AddImplementation(implementation);
            }

            return implementation;
        }
    }
}
