using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FilmsDB
{
    /// <summary>
    /// Interaction logic for InsertFilm.xaml
    /// </summary>
    public partial class InsertFilm : Window
    {
        OpenFileDialog openFileDialog;
        FilmsDBContext context;
        public InsertFilm()
        {
            InitializeComponent();
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "jpg|*.jpg|png|*.png";
            CBStatus.Items.Add("Просмотрено");
            CBStatus.Items.Add("Не просмотрено");
            context = new FilmsDBContext();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(openFileDialog.ShowDialog() == true)
            {
                IPoster.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MyFilm film = new MyFilm();
            film.Name = TBFilmName.Text;
            film.Annotation = TBAnnotation.Text;
            film.Status = CBStatus.Text;
            film.Photo = openFileDialog.FileName;

            context.Films.Add(film);    //Добавление в БД
            context.SaveChanges();

            Close();
        }
    }
}
