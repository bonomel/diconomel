using System;
using System.Linq;
using System.Reflection;

namespace Squeezy.Core
{
    public class DependencyResolver
    {
        private readonly DependencyContainer container;

        public DependencyResolver(DependencyContainer container)
        {
            this.container = container;
        }

        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }

        public object GetService(Type type)
        {
            Type dependency = container.GetDependency(type);
            ConstructorInfo constructor = dependency.GetConstructors().Single(); // only one constructor is allowed for services
            ParameterInfo[] parameters = constructor.GetParameters();

            var parameterImplementations = new object[parameters.Length];

            if (parameters.Length > 0)
            {
                // parameters exist on the constructor
                for (int i = 0; i < parameters.Length; i++)
                {
                    // recursively get each dependency and each of their dependencies
                    parameterImplementations[i] = GetService(parameters[i].ParameterType);
                }

                // return object using instantiated objects in its constructor
                return Activator.CreateInstance(dependency, parameterImplementations);
            }

            // return object using parameterless contructor
            return Activator.CreateInstance(dependency);
        }
    }
}
