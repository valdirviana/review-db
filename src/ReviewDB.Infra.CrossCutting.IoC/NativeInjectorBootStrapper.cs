using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ReviewDB.Application.Interfaces.MovieAgreggate;
using ReviewDB.Application.Services.MovieAgreggate;
using ReviewDB.CrossCutting.Bus;
using ReviewDB.Domain.CommandHandlers.MovieAgreggate;
using ReviewDB.Domain.Commands.MovieAgreggate;
using ReviewDB.Domain.Core.Bus;
using ReviewDB.Domain.Core.Events;
using ReviewDB.Domain.Core.Notifications;
using ReviewDB.Domain.Interfaces.UoW;
using ReviewDB.Infra.Data;
using ReviewDB.Infra.Data.UoW;

namespace ReviewDB.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            //services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application
            services.AddScoped<IMovieAppService, MovieAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            //services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
            //services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            //services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterMovieCommand>, MovieCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateMovieCommand>, MovieCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveMovieCommand>, MovieCommandHandler>();

            // Infra - Data
            //services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork<ReviewDBContext>>();
            services.AddScoped<ReviewDBContext>();

            // Infra - Data EventSourcing
            //services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            //services.AddScoped<IEventStore, SqlEventStore>();
            //services.AddScoped<EventStoreSQLContext>();

            // Infra - Identity Services
            //services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            //services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            //services.AddScoped<IUser, AspNetUser>();
        }
    }
}
