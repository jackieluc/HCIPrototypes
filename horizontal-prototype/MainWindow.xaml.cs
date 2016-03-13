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
using System.Windows.Threading;

namespace horizontal_prototype
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //initiate real-time timer
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                date_time.Content = DateTime.Now.ToString();
            }, this.Dispatcher);
        }

        private void initialize_date_time(object sender, EventArgs e)
        {
            date_time.Content = DateTime.Now.ToString();
        }

        private void netflix_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://www.netflix.com/Login?locale=en-CA");
            }
            catch { }
        }

        private void movies_Click(object sender, RoutedEventArgs e)
        {
            movieList.Visibility = Visibility.Visible;
            movieListBack.Visibility = Visibility.Visible;
            movieTitle.Visibility = Visibility.Visible;
        }

        private void favourites_button_Click(object sender, RoutedEventArgs e)
        {
            favoritesList.Visibility = Visibility.Visible;
            favoritesListBack.Visibility = Visibility.Visible;
            favoritesTitle.Visibility = Visibility.Visible;
        }

        private void music_button_Click(object sender, RoutedEventArgs e)
        {
            musicList.Visibility = Visibility.Visible;
            musicListBack.Visibility = Visibility.Visible;
            musicTitle.Visibility = Visibility.Visible;
        }

        private void tvshows_button_Click(object sender, RoutedEventArgs e)
        {
            tvshowList.Visibility = Visibility.Visible;
            tvshowListBack.Visibility = Visibility.Visible;
            tvshowTitle.Visibility = Visibility.Visible;
        }

        private void settings_button_Click(object sender, RoutedEventArgs e)
        {
            settings.Visibility = Visibility.Visible;
            settingsBack.Visibility = Visibility.Visible;
            settingsTitle.Visibility = Visibility.Visible;
            videoSettings.Visibility = Visibility.Visible;
            powerSettings.Visibility = Visibility.Visible;
            dataAndTime.Visibility = Visibility.Visible;
            audioSettings.Visibility = Visibility.Visible;
        }

        private void youtube_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://www.youtube.com/");
            }
            catch { }
        }

        private void spotify_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://accounts.spotify.com/en/login?continue=https:%2F%2Fwww.spotify.com%2Fca-en%2Faccount%2Foverview%2F");
            }
            catch { }
        }

        private void Username_form_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Password_form_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Login_button_Click(object sender, RoutedEventArgs e)
        {
            
            Login_button.Visibility = Visibility.Hidden;
            Login.Visibility = Visibility.Hidden;
            Username_form.Visibility = Visibility.Hidden;
            Password.Visibility = Visibility.Hidden;
            Password_form.Visibility = Visibility.Hidden;
            
        }

        private void closeMovieList(object sender, RoutedEventArgs e)
        {
            movieList.Visibility = Visibility.Hidden;
            movieListBack.Visibility = Visibility.Hidden;
            movieTitle.Visibility = Visibility.Hidden;
        }

        private void closeTvList(object sender, RoutedEventArgs e)
        {
            tvshowList.Visibility = Visibility.Hidden;
            tvshowListBack.Visibility = Visibility.Hidden;
            tvshowTitle.Visibility = Visibility.Hidden;
        }

        private void closeFavoritesList(object sender, RoutedEventArgs e)
        {
            favoritesList.Visibility = Visibility.Hidden;
            favoritesListBack.Visibility = Visibility.Hidden;
            favoritesTitle.Visibility = Visibility.Hidden;
        }

        private void closeMusicList(object sender, RoutedEventArgs e)
        {
            musicList.Visibility = Visibility.Hidden;
            musicListBack.Visibility = Visibility.Hidden;
            musicTitle.Visibility = Visibility.Hidden;
        }

        private void closeSettings(object sender, RoutedEventArgs e)
        {
            settings.Visibility = Visibility.Hidden;
            settingsBack.Visibility = Visibility.Hidden;
            settingsTitle.Visibility = Visibility.Hidden;
            videoSettings.Visibility = Visibility.Hidden;
            powerSettings.Visibility = Visibility.Hidden;
            dataAndTime.Visibility = Visibility.Hidden;
            audioSettings.Visibility = Visibility.Hidden;
        }
    }
}
