using System.Collections.Generic;
using System.Linq;

namespace ServiceLocator {
    public class ServiceLocator {
        public static ServiceLocator Current { get; private set; }

        static HashSet<IService> services = new();

        public static void Initialize() {
            if (Current != null) {
                return;
            }
            
            Current = new ServiceLocator();
        }

        public static T GetService<T>() where T : IService {
            var obj = services.SingleOrDefault(x => x is T);
            return (T)obj;
        }

        public static void Register<T>(T service) where T : IService {
            services.Add(service);
        }
        
        public static void Unregister<T>(T service) where T : IService {
            services.Remove(service);
        }
    }
}
