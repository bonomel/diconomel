using System;
using System.Linq;
using System.Reflection;

namespace Diconomel.Core
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
            Type dependency = container.GetDependency(typeof(T));
            ConstructorInfo constructor = dependency.GetConstructors().Single(); // only one constructor is allowed for services
            ParameterInfo[] parameters = constructor.GetParameters();

            var parameterImplementations = new object[parameters.Length];

            if (parameters.Length > 0)
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    parameterImplementations[i] = Activator.CreateInstance(parameters[i].ParameterType);
                }

                return (T)Activator.CreateInstance(dependency, parameterImplementations);
            }

            return (T) Activator.CreateInstance(dependency);
        }
    }
}
