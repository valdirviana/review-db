using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ReviewDB.Application.AutoMapper;
using ReviewDB.Application.Interfaces.MovieAgreggate;
using ReviewDB.Application.ViewModel;
using ReviewDB.Domain.CommandHandlers.MovieAgreggate;
using ReviewDB.Infra.CrossCutting.IoC;
using ReviewDB.Infra.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ReviewDB.DataImporter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");          

            IServiceCollection services = new ServiceCollection();

            services.AddDbContext<ReviewDBContext>(c =>
                c.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Integrated Security=true;Initial Catalog=ReviewDB;"));

            services.AddMediatR(typeof(MovieCommandHandler).GetTypeInfo().Assembly);
            services.AddAutoMapper();

            // Registering Mappings automatically only works if the 
            // Automapper Profile classes are in ASP.NET project
            AutoMapperConfig.RegisterMappings();

            NativeInjectorBootStrapper.RegisterServices(services);

            var provider = services
                .BuildServiceProvider();

            var movieAppService = provider.GetService<IMovieAppService>();

            LoadJsonAsync(movieAppService);
        }

        public static async Task LoadJsonAsync(IMovieAppService movieAppService)
        {
            using (StreamReader r = new StreamReader("movie_ids_09_26_2018.json"))
            {
                string json = r.ReadToEnd();
                List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
                var bestMovies = items.Where(x => x.popularity >= 1);

                var counter = 1;
                var multiplier = 100;

                Parallel.ForEach(bestMovies, (bestMovie) =>
                {


                });

                foreach (var bestMovie in bestMovies)
                {
                    Console.WriteLine($"Movie: {bestMovie.original_title} - Popularity: {bestMovie.popularity}");
                    var movieViewModel = new MovieViewModel()
                    {
                        TmdbId = bestMovie.id,
                        OriginalTitle = bestMovie.original_title,
                        Adult = bestMovie.adult
                    };

                    if(counter > multiplier)
                    {
                        GC.Collect();
                        multiplier += 100;
                        Console.WriteLine("***************************************************************************");
                        Console.WriteLine("***************************************************************************");
                        Console.WriteLine("***************************************************************************");
                    }
                    
                    counter++;
                    try
                    {
                        await Task.Run(() => movieAppService.Register(movieViewModel));    
                    }
                    catch (Exception ex)
                    {
                        var exception = ex;
                    }
                    
                }
            }
        }
    }

    public class Item
    {
        public bool adult;
        public int id;
        public string original_title;
        public double popularity;
        public bool video;
    }
}
