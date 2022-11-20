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
    /// Interaction logic for ShowCRUD.xaml
    /// </summary>
    public partial class ShowCRUD : Window
    {
        public ShowCRUD()
        {
            InitializeComponent();
            GetShow();

            AddNewShowGrid.DataContext = NewShow;
        }
        static IMapper Mapper = SetupMapper();
        ShowDTO NewShow = new ShowDTO();
        ShowDTO selectedShow = new ShowDTO();

        private static IMapper SetupMapper()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg => cfg.AddMaps(typeof(ShowDal).Assembly)
                );
            return config.CreateMapper();
        }


        private void GetShow()
        {
            var dal = new ShowDal(Mapper);

            var productsList = dal.GetAllShows();
            ShowDG.ItemsSource = productsList;
        }

        private void AddShow(object s, RoutedEventArgs e)
        {
            var dal = new ShowDal(Mapper);

            NewShow = dal.CreateShow(NewShow);

            GetShow();
            NewShow = new ShowDTO();
            AddNewShowGrid.DataContext = NewShow;
        }

        private void DeleteShow(object s, RoutedEventArgs e)
        {
            var productToBeDeleted = (s as FrameworkElement).DataContext as ShowDTO;

            var dal = new ShowDal(Mapper);
            dal.DeleteShow(productToBeDeleted);
            GetShow();
        }

        private void UpdateShowForEdit(object s, RoutedEventArgs e)
        {
            
            selectedShow = (s as FrameworkElement).DataContext as ShowDTO;
            UpdateShowGrid.DataContext = selectedShow;
        }

        private void UpdateShow(object s, RoutedEventArgs e)
        {
            var dal = new ShowDal(Mapper);
            dal.UpdateShow(selectedShow);
            GetShow();
        }

        private void ShowDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
