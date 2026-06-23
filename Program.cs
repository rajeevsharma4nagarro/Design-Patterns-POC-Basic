using E_Library;
using E_Library.Books;
using E_Library.Notifications;
using E_Library.Users;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {

        #region Register services
        var services = new ServiceCollection();
        services.AddSingleton<ELibraryApp>();
        services.AddTransient<INotifyUser, NotifyUser>();
        services.AddScoped<UserFactory>();
        services.AddScoped<IBookManagement, BookManagement>();
        services.AddScoped<IUserManagement, UserManagement>();
        services.AddSingleton<AzureBusNotificationService>();
        #endregion

        var serviceProvider = services.BuildServiceProvider();
        var app = serviceProvider.GetRequiredService<ELibraryApp>();
        app.Run();
    }
}


