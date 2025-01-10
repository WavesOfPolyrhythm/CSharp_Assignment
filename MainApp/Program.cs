using Business.Interfaces;
using Business.Repositories;
using Business.Services;
using MainApp.Dialogs;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Authentication.ExtendedProtection;

var serviceCollection = new ServiceCollection();
serviceCollection.AddSingleton<IUserRepository, UserRepository>();
serviceCollection.AddSingleton<IUserService, UserService>();
serviceCollection.AddSingleton<IFileService, FileService>();
serviceCollection.AddSingleton<MenuDialogs>();

var serviceProvider = serviceCollection.BuildServiceProvider();
var menuDialogs = serviceProvider.GetRequiredService<MenuDialogs>();
menuDialogs.ShowMenu();
