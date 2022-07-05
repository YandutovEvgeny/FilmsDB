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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FilmsDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FilmsDBContext context;
        public MainWindow()
        {
            InitializeComponent();
            context = new FilmsDBContext();
            TBAnnotation.TextWrapping = TextWrapping.Wrap;
            RefreshList();
        }

        /*private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyFilm film = new MyFilm()
            {
                Name = "Дюна",
                Annotation = "Наследник знаменитого дома Атрейдесов Пол отправляется вместе с семьей на одну из самых опасных планет во Вселенной — Арракис.",
                Status = "Посмотрено",
                Photo = "https://yandex.ru/images/search?pos=0&from=tabbar&img_url=https%3A%2F%2Fscontent-hel3-1.cdninstagram.com%2Fv%2Ft51.2885-15%2Fe35%2Fp1080x1080%2F242222121_2940603296153160_2946749854998286517_n.jpg%3F_nc_ht%3Dscontent-hel3-1.cdninstagram.com%26_nc_cat%3D100%26_nc_ohc%3DbJ8e3NQfLNcAX8oy9L4%26edm%3DABfd0MgBAAAA%26ccb%3D7-4%26oh%3D61f207721513eff17ce6302f36c27358%26oe%3D614EC6E6%26_nc_sid%3D7bff83&text=дюна+постер&rpt=simage&lr=45"
            };
            context.Films.Add(film); //Добавляем в базу объект
            context.SaveChanges();  //Сохраняем изменения
        }*/

        public void RefreshList()
        {
            LBNames.Items.Clear();
            foreach (MyFilm film in context.Films)
            {
                LBNames.Items.Add(film.Name);
            }
        }

        private void LBNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LBNames.SelectedIndex != -1)
            {
                int i = LBNames.SelectedIndex;
                LName.Content = context.Films.ToList()[i].Name;
                IPhoto.Source = new BitmapImage(new Uri(context.Films.ToList()[i].Photo));
                TBAnnotation.Text = context.Films.ToList()[i].Annotation;
                if (context.Films.ToList()[i].Status == "Посмотрено")
                    LName.Foreground = new SolidColorBrush(Color.FromRgb(0, 200, 0));
                else
                    LName.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }
        }
    }
}
