using E_Library;
using E_Library.Books;
using E_Library.Notifications;
using E_Library.Patterns.Decorator;
using E_Library.Patterns.Facades;
using E_Library.Users;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {

        #region Register services
        var services = new ServiceCollection();
        services.AddSingleton<ELibraryApp>();
        services.AddSingleton<AzureBusNotificationService>();

        services.AddTransient<Notification>();
        services.AddTransient<INotifyUser, NotifyUser>();
        
        services.AddScoped<UserFactory>();
        services.AddScoped<UserAndBookGenerate>();
        services.AddScoped<IBookManagement, BookManagement>();
        services.AddScoped<IUserManagement, UserManagement>();
        services.AddScoped<IReservingBook, ReservingBook>();
        #endregion

        var serviceProvider = services.BuildServiceProvider();
        var app = serviceProvider.GetRequiredService<ELibraryApp>();
        app.Run();
    }
}


