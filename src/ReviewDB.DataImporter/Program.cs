using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ReviewDB.DataImporter
{
    public class Program
    {
        private static ServiceProvider _provider;

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

            _provider = services
                .BuildServiceProvider();

            var movieAppService = _provider.GetService<IMovieAppService>();

            LoadJsonAsync();
        }

        public static async Task LoadJsonAsync()
        {
            using (StreamReader r = new StreamReader("movie_ids_09_26_2018.json"))
            {
                string json = r.ReadToEnd();
                List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
                var bestMovies1 = items.Where(x => x.popularity >= 20).ToList();

                try
                {
                    //Stopwatch stopwatch3 = new Stopwatch();
                    //stopwatch3.Start();
                    //try
                    //{
                    //    foreach (var bestMovie in bestMovies1)
                    //    {
                    //        Console.WriteLine($"Movie: {bestMovie.original_title} - Popularity: {bestMovie.popularity}");
                    //        var movieViewModel = new MovieViewModel()
                    //        {
                    //            TmdbId = bestMovie.id,
                    //            OriginalTitle = bestMovie.original_title,
                    //            Adult = bestMovie.adult
                    //        };

                    //        await movieAppService3.Register(movieViewModel);
                    //    }

                    //}
                    //catch (Exception ex)
                    //{
                    //    var exception = ex;
                    //}
                    //stopwatch3.Stop();





                    Task taskA = new Task(() =>
                    {
                        try
                        {
                            foreach (var bestMovie in bestMovies1)
                            {
                                //Console.WriteLine($"Movie: {bestMovie.original_title} - Popularity: {bestMovie.popularity}");
                                var movieViewModel = new MovieViewModel()
                                {
                                    TmdbId = bestMovie.id,
                                    OriginalTitle = bestMovie.original_title,
                                    Adult = bestMovie.adult
                                };

                               _provider.GetService<IMovieAppService>().Register(movieViewModel);
                            }

                        }
                        catch (Exception ex)
                        {
                            var exception = ex;
                        }
                    });

                    taskA.Start();
                    Stopwatch stopwatch2 = new Stopwatch();
                    stopwatch2.Start();
                    taskA.Wait();
                    stopwatch2.Stop();



                    //Task taskB = new Task(() =>
                    //{
                    //    try
                    //    {
                    //        Parallel.ForEach(bestMovies2, new ParallelOptions { MaxDegreeOfParallelism = 1 }, (bestMovie) =>
                    //        {
                    //            Console.WriteLine($"Movie: {bestMovie.original_title} - Popularity: {bestMovie.popularity}");
                    //            var movieViewModel = new MovieViewModel()
                    //            {
                    //                TmdbId = bestMovie.id,
                    //                OriginalTitle = bestMovie.original_title,
                    //                Adult = bestMovie.adult
                    //            };
                    //            movieAppService2.Register(movieViewModel);
                    //        });
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        var exception = ex;
                    //    }
                    //});

                    //Stopwatch stopwatch1 = new Stopwatch();
                    //taskB.Start();
                    //stopwatch1.Start();
                    //taskB.Wait();
                    //stopwatch1.Stop();





                    //Console.WriteLine("Time elapsed Parallel: {0}", stopwatch1.Elapsed);
                    Console.WriteLine("Time elapsed: {0}", stopwatch2.Elapsed);
                    //Console.WriteLine("Time elapsed: {0} ALONE FOR", stopwatch3.Elapsed);
                    Console.WriteLine("Movies count: {0}", bestMovies1.Count());

                    Console.ReadKey();

                }
                catch (Exception ex)
                {
                    var exception = ex;
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
