using System.Reflection;

namespace BookStore.Application
{
    public static class IocConfig
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly().GetExportedTypes()
                .Where(s => typeof(IServiceBase).IsAssignableFrom(s)).ToList();

            var classes = assembly.Where(c => c.IsClass && c.IsPublic).ToList();

            var interfaces = assembly.Where(c => c.IsInterface && c.IsPublic).ToList();

            foreach (var clss in classes)
            {
                var face = interfaces.FirstOrDefault(x => x.Name.Contains(clss.Name, StringComparison.OrdinalIgnoreCase));
                if (face is not null)
                    services.AddScoped(face, clss);
            }
        }
    }
}
