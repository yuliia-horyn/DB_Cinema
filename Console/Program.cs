using AutoMapper;
using DAL.Concrete;
using System;

namespace Console_program
{
    class Program
    {
        static IMapper Mapper = SetupMapper();

        private static IMapper SetupMapper()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg => cfg.AddMaps(typeof(MovieDal).Assembly)
                );
            return config.CreateMapper();
        }
        public static void ReadAllUsers()
        {
            var dal = new MovieDal(Mapper);
            var users = dal.GetAllMovies();           
            foreach (var user in users)
            {
                Console.WriteLine(user.ToString());
            }
        }
        public static void ReadAlls()
        {
            var dal = new ShowDal(Mapper);
            var users = dal.GetAllShows();
            foreach (var user in users)
            {
                Console.WriteLine(user.ToString());
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ReadAllUsers();
        }
    }
}
