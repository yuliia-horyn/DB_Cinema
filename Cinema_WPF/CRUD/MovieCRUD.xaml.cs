using AutoMapper;
using DAL.Concrete;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cinema_WPF.CRUD
{
    /// <summary>
    /// Interaction logic for MovieCRUD.xaml
    /// </summary>
    public partial class MovieCRUD : Window
    {
        public MovieCRUD()
        {
            InitializeComponent();
            GetMovie();

            AddNewMovieGrid.DataContext = NewMovie;
        }
        static IMapper Mapper = SetupMapper();
        MovieDTO NewMovie = new MovieDTO();
        MovieDTO selectedMovie = new MovieDTO();

        private static IMapper SetupMapper()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg => cfg.AddMaps(typeof(MovieDal).Assembly)
                );
            return config.CreateMapper();
        }

        private void GetMovie()
        {
            var dal = new MovieDal(Mapper);

            var moviesList = dal.GetAllMovies();
            MovieDG.ItemsSource = moviesList;
        }

        private void AddMovie(object s, RoutedEventArgs e)
        {
            var dal = new MovieDal(Mapper);

            NewMovie = dal.CreateMovie(NewMovie);

            GetMovie();
            NewMovie = new MovieDTO();
            AddNewMovieGrid.DataContext = NewMovie;
        }

        private void DeleteMovie(object s, RoutedEventArgs e)
        {
            var categoryToBeDeleted = (s as FrameworkElement).DataContext as MovieDTO;

            var dal = new MovieDal(Mapper);
            dal.DeleteMovie(categoryToBeDeleted);
            GetMovie();
        }

        private void UpdateMovieForEdit(object s, RoutedEventArgs e)
        {
            selectedMovie = (s as FrameworkElement).DataContext as MovieDTO;
            UpdateMovieGrid.DataContext = selectedMovie;
        }

        private void UpdateMovie(object s, RoutedEventArgs e)
        {
            var dal = new MovieDal(Mapper);
            dal.UpdateMovie(selectedMovie);
            GetMovie();
        }
    }
}
