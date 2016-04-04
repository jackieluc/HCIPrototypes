using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
        private Boolean in_social = false;
        private Boolean in_account = false;

        private Boolean notify = false;
        private Boolean gotNotification = false;

        private Boolean feed_open = true;
        private Boolean john_tvshow_favorite = false;
        private Boolean john_movies_favorite = false;
        private Boolean john_music_favorite = false;
        private Boolean alex_tvshow_favorite = false;
        private Boolean alex_movies_favorite = false;
        private Boolean alex_music_favorite = false;
        private Boolean john_logged_on = false;
        private Boolean alex_logged_on = false;

        private Boolean video_played = false;
        private Boolean video_playing = false;

        public MainWindow()
        {
            InitializeComponent();
            IsPlaying(false);
            //initiate real-time timer
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                date_time.Content = DateTime.Now.ToString();
            }, this.Dispatcher);

            DispatcherTimer notificationTimer = new DispatcherTimer(TimeSpan.FromMilliseconds(1), DispatcherPriority.Send, delegate {
                if (Keyboard.IsKeyDown(Key.N) && !notify)
                {
                    notifyUser();
                }
                if (Keyboard.IsKeyDown(Key.Left) && web_browser.Visibility == Visibility.Visible)
                {
                    web_browser.Visibility = Visibility.Hidden;
                }
                if (Keyboard.IsKeyDown(Key.Right) && web_browser.Visibility == Visibility.Hidden)
                {
                    web_browser.Visibility = Visibility.Visible;
                }
            }, this.Dispatcher);
        }

         private void notifyUser()
         {
            if (!notify && social_button.Visibility == Visibility.Visible)
            {
                social_button.Visibility = Visibility.Hidden;

                if (!in_social)
                    notify_button.Visibility = Visibility.Visible;
                else if (in_social)
                    social_button.Visibility = Visibility.Visible;

                notify = true;

                if (john_logged_on && !alex_logged_on)
                {
                    Button notification = new Button();
                    notification.Content = new TextBlock()
                    {
                        Height = 95,
                        FontSize = 16,
                        Text = "Alex Wong recommends you to watch Marvel's The Avengers! Click to watch the official website trailer!",
                        TextAlignment = TextAlignment.Center,
                        VerticalAlignment = System.Windows.VerticalAlignment.Center,
                        HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                        TextWrapping = TextWrapping.Wrap
                    };

                    notification.Click += notification_Click;

                    john_notifications_feed.Children.Add(notification);
                }
                else
                {
                    Button notification = new Button();
                    notification.Content = new TextBlock()
                    {
                        Height = 95,
                        FontSize = 16,
                        Text = "John Smith recommends you to watch Marvel's The Avengers! Click to watch the official website trailer!",
                        TextAlignment = TextAlignment.Center,
                        VerticalAlignment = System.Windows.VerticalAlignment.Center,
                        HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                        TextWrapping = TextWrapping.Wrap
                    };

                    notification.Click += notification_Click;

                    alex_notifications_feed.Children.Add(notification);
                }
            }
        }

         private void notification_Click(object sender, RoutedEventArgs e)
         {
             social_browser.Visibility = Visibility.Visible;
             social_browser.Navigate("http://marvel.com/avengers_movie/");
         }

        private void initialize_date_time(object sender, EventArgs e)
        {
            date_time.Content = DateTime.Now.ToString();
        }

        private void netflix_Click(object sender, RoutedEventArgs e)
        {
            web_browser.Visibility = Visibility.Visible;
            web_browser.Navigate("https://www.netflix.com/Login?locale=en-CA");
        }

        private void movies_Click(object sender, RoutedEventArgs e)
        {
            movieList.Visibility = Visibility.Visible;
            movieListBack.Visibility = Visibility.Visible;
            movieTitle.Visibility = Visibility.Visible;
            avengers_movies.Visibility = Visibility.Visible;
            transformer_movies.Visibility = Visibility.Visible;
            civilwar_trailer.Visibility = Visibility.Visible;
        }

        private void favourites_button_Click(object sender, RoutedEventArgs e)
        {
            favoritesList.Visibility = Visibility.Visible;
            favoritesListBack.Visibility = Visibility.Visible;
            favoritesTitle.Visibility = Visibility.Visible;

            if (john_logged_on == true && john_movies_favorite == true)
            {
                avengers_favorites.Visibility = Visibility.Visible;
            }
            if (john_logged_on == true && john_tvshow_favorite == true)
            {
                suits_favorites.Visibility = Visibility.Visible;
            }
            if (john_logged_on == true && john_music_favorite == true)
            {
                bieber_favorites.Visibility = Visibility.Visible;
            }

            if (alex_logged_on == true && alex_tvshow_favorite == true)
            {
                suits_favorites.Visibility = Visibility.Visible;
            }
            if (alex_logged_on == true && alex_movies_favorite == true)
            {
                avengers_favorites.Visibility = Visibility.Visible;
            }
            if (alex_logged_on == true && alex_music_favorite == true)
            {
                bieber_favorites.Visibility = Visibility.Visible;
            }

        }

        private void music_button_Click(object sender, RoutedEventArgs e)
        {
            musicList.Visibility = Visibility.Visible;
            musicListBack.Visibility = Visibility.Visible;
            musicTitle.Visibility = Visibility.Visible;
            deadmau5_music.Visibility = Visibility.Visible;
            selenagomez_music.Visibility = Visibility.Visible;
            justinbieber_music.Visibility = Visibility.Visible;
        }

        private void tvshows_button_Click(object sender, RoutedEventArgs e)
        {
             tvshowList.Visibility = Visibility.Visible;
             tvshowListBack.Visibility = Visibility.Visible;
             tvshowTitle.Visibility = Visibility.Visible;
             naruto_tvshows.Visibility = Visibility.Visible;
             suits_tvshows.Visibility = Visibility.Visible;
             vampirediaries_tvshows.Visibility = Visibility.Visible;
             pokemon_tvshows.Visibility = Visibility.Visible;
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
            web_browser.Visibility = Visibility.Visible;
            web_browser.Navigate("https://www.youtube.com");
        }

        private void spotify_button_Click(object sender, RoutedEventArgs e)
        {
            web_browser.Visibility = Visibility.Visible;
            web_browser.Navigate("https://www.spotify.com/ca-en/");
        }

        private void Username_form_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Password_form_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Login_button_Click(object sender, RoutedEventArgs e)
        {
            if (Username_form.Text.Equals("john.smith@gmail.com") && Password_form.Password.Equals("JCREntertainment"))
            {
                john_logged_on = true;

                Login_button.Visibility = Visibility.Hidden;
                Login.Visibility = Visibility.Hidden;
                Username_form.Visibility = Visibility.Hidden;
                Password.Visibility = Visibility.Hidden;
                Password_form.Visibility = Visibility.Hidden;
                login_failed_msg.Visibility = Visibility.Hidden;

                if (gotNotification)
                {
                    notify_button.Visibility = Visibility.Visible;
                    gotNotification = false;
                }
                else
                    social_button.Visibility = Visibility.Visible;

                account_button.Visibility = Visibility.Visible;
                logout_button.Visibility = Visibility.Visible;
            }
            else if (Username_form.Text.Equals("alex.wong@gmail.com") && Password_form.Password.Equals("CPSC481"))
            {
                alex_logged_on = true;

                Login_button.Visibility = Visibility.Hidden;
                Login.Visibility = Visibility.Hidden;
                Username_form.Visibility = Visibility.Hidden;
                Password.Visibility = Visibility.Hidden;
                Password_form.Visibility = Visibility.Hidden;
                login_failed_msg.Visibility = Visibility.Hidden;

                if (gotNotification)
                {
                    notify_button.Visibility = Visibility.Visible;
                    gotNotification = false;
                }
                else
                    social_button.Visibility = Visibility.Visible;

                account_button.Visibility = Visibility.Visible;
                logout_button.Visibility = Visibility.Visible;
            }
            else {
                login_failed_msg.Visibility = Visibility.Visible;
            }
        }

        private void closeMovieList(object sender, RoutedEventArgs e)
        {
            movieList.Visibility = Visibility.Hidden;
            movieListBack.Visibility = Visibility.Hidden;
            movieTitle.Visibility = Visibility.Hidden;
            avengers_movies.Visibility = Visibility.Hidden;
            transformer_movies.Visibility = Visibility.Hidden;
            civilwar_trailer.Visibility = Visibility.Hidden;
        }

        private void closeTvList(object sender, RoutedEventArgs e)
        {
            tvshowList.Visibility = Visibility.Hidden;
            tvshowListBack.Visibility = Visibility.Hidden;
            tvshowTitle.Visibility = Visibility.Hidden;
            naruto_tvshows.Visibility = Visibility.Hidden;
            suits_tvshows.Visibility = Visibility.Hidden;
            vampirediaries_tvshows.Visibility = Visibility.Hidden;
            pokemon_tvshows.Visibility = Visibility.Hidden;
        }

        private void closeFavoritesList(object sender, RoutedEventArgs e)
        {
            favoritesList.Visibility = Visibility.Hidden;
            favoritesListBack.Visibility = Visibility.Hidden;
            favoritesTitle.Visibility = Visibility.Hidden;
            bieber_favorites.Visibility = Visibility.Hidden;
            suits_favorites.Visibility = Visibility.Hidden;
            avengers_favorites.Visibility = Visibility.Hidden;
        }

        private void closeMusicList(object sender, RoutedEventArgs e)
        {
            musicList.Visibility = Visibility.Hidden;
            musicListBack.Visibility = Visibility.Hidden;
            musicTitle.Visibility = Visibility.Hidden;
            deadmau5_music.Visibility = Visibility.Hidden;
            selenagomez_music.Visibility = Visibility.Hidden;
            justinbieber_music.Visibility = Visibility.Hidden;
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

        private void textbox_clear(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = String.Empty;
            textBox.GotFocus -= textbox_clear;
        }

        private void logout_button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = new MessageBoxResult();
            messageBoxResult = MessageBox.Show("Are you sure you want to log out?", "Log Out", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {

                Login_button.Visibility = Visibility.Visible;
                Login.Visibility = Visibility.Visible;
                Username_form.Visibility = Visibility.Visible;
                Password.Visibility = Visibility.Visible;
                Password_form.Visibility = Visibility.Visible;

                logout_button.Visibility = Visibility.Hidden;
                account_button.Visibility = Visibility.Hidden;
                account_title.Visibility = Visibility.Hidden;
                account_page.Visibility = Visibility.Hidden;
                backAccount_button.Visibility = Visibility.Hidden;
                
                social_button.Visibility = Visibility.Hidden;
                notify_button.Visibility = Visibility.Hidden;
                social_feed_title.Visibility = Visibility.Hidden;
                social_feed.Visibility = Visibility.Hidden;
                backSocial_button.Visibility = Visibility.Hidden;

                separator.Visibility = Visibility.Hidden;
                side_notify.Visibility = Visibility.Hidden;
                side_facebook.Visibility = Visibility.Hidden;
                side_twitter.Visibility = Visibility.Hidden;
                john_notifications_feed.Visibility = Visibility.Hidden;
                alex_notifications_feed.Visibility = Visibility.Hidden;
                social_browser.Visibility = Visibility.Hidden;

                notify = false;

                john_logged_on = false;
                alex_logged_on = false;

                Username_form.Text = "Username";
                Password_form.Password = "";
            }
            else if (!feed_open)
            {
                social_feed.Visibility = Visibility.Hidden;
                social_feed_title.Visibility = Visibility.Hidden;
                separator.Visibility = Visibility.Hidden;

                side_facebook.Visibility = Visibility.Hidden;
                side_twitter.Visibility = Visibility.Hidden;
                john_notifications_feed.Visibility = Visibility.Hidden;
                alex_notifications_feed.Visibility = Visibility.Hidden;

                feed_open = true;
            }
        }

        private void avengers_movies_Click(object sender, RoutedEventArgs e)
        {
            avengersTitle.Visibility = Visibility.Visible;
            avengersBackground.Visibility = Visibility.Visible;
            avengersBack.Visibility = Visibility.Visible;
            recommendAvengers.Visibility = Visibility.Visible;
            favoriteAvengers.Visibility = Visibility.Visible;
            avengersSynopisis.Visibility = Visibility.Visible;
            avengersIcon.Visibility = Visibility.Visible;
            playAvengers.Visibility = Visibility.Visible;

            movieList.Visibility = Visibility.Hidden;
            movieListBack.Visibility = Visibility.Hidden;
            movieTitle.Visibility = Visibility.Hidden;
            avengers_movies.Visibility = Visibility.Hidden;
            transformer_movies.Visibility = Visibility.Hidden;
            civilwar_trailer.Visibility = Visibility.Hidden;
        }

        private void transformer_movies_Click(object sender, RoutedEventArgs e)
        {

        }

        private void naruto_tvshows_Click(object sender, RoutedEventArgs e)
        {

        }

        private void suits_tvshows_Click(object sender, RoutedEventArgs e)
        {
            naruto_tvshows.Visibility = Visibility.Hidden;
            suits_tvshows.Visibility = Visibility.Hidden;
            vampirediaries_tvshows.Visibility = Visibility.Hidden;
            pokemon_tvshows.Visibility = Visibility.Hidden;
            tvshowTitle.Visibility = Visibility.Hidden;
            tvshowListBack.Visibility = Visibility.Hidden;
            tvshowList.Visibility = Visibility.Hidden;

            suitsTitle.Visibility = Visibility.Visible;
            suitsBackground.Visibility = Visibility.Visible;
            suitsBack.Visibility = Visibility.Visible;
            recommendSuits.Visibility = Visibility.Visible;
            favoriteSuits.Visibility = Visibility.Visible;
            suitsSynopisis.Visibility = Visibility.Visible;
            suitsS1.Visibility = Visibility.Visible;
            suitsS2.Visibility = Visibility.Visible;
            suitsS3.Visibility = Visibility.Visible;
            suitsS4.Visibility = Visibility.Visible;
            suitsS5.Visibility = Visibility.Visible;
            suitsS1Label.Visibility = Visibility.Visible;
            suitsS2Label.Visibility = Visibility.Visible;
            suitsS3Label.Visibility = Visibility.Visible;
            suitsS4Label.Visibility = Visibility.Visible;
            suitsS5Label.Visibility = Visibility.Visible;
            //suitsS5Label.Visibility = Visibility.Hidden;

        }

        private void vampirediaries_tvshows_Click(object sender, RoutedEventArgs e)
        {

        }

        private void pokemon_tvshows_Click(object sender, RoutedEventArgs e)
        {

        }

        private void suits_favorites_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deadmau5_music_Click(object sender, RoutedEventArgs e)
        {

        }

        private void justinbieber_music_Click(object sender, RoutedEventArgs e)
        {
            bieberTitle.Visibility = Visibility.Visible;
            bieberBackground.Visibility = Visibility.Visible;
            bieberBack.Visibility = Visibility.Visible;
            recommendBieber.Visibility = Visibility.Visible;
            favoriteBieber.Visibility = Visibility.Visible;
            bieberMusicList.Visibility = Visibility.Visible;
            bieberIcon.Visibility = Visibility.Visible;
            playAllBieber.Visibility = Visibility.Visible;

            justinbieber_music.Visibility = Visibility.Hidden;
            deadmau5_music.Visibility = Visibility.Hidden;
            selenagomez_music.Visibility = Visibility.Hidden;
            musicTitle.Visibility = Visibility.Hidden;
            musicListBack.Visibility = Visibility.Hidden;
            musicList.Visibility = Visibility.Hidden;
        }

        private void selenagomez_music_Click(object sender, RoutedEventArgs e)
        {

        }

        private void backSuits(object sender, RoutedEventArgs e)
        {
            suitsTitle.Visibility = Visibility.Hidden;
            suitsBackground.Visibility = Visibility.Hidden;
            suitsBack.Visibility = Visibility.Hidden;
            recommendSuits.Visibility = Visibility.Hidden;
            favoriteSuits.Visibility = Visibility.Hidden;
            suitsSynopisis.Visibility = Visibility.Hidden;
            suitsS1.Visibility = Visibility.Hidden;
            suitsS2.Visibility = Visibility.Hidden;
            suitsS3.Visibility = Visibility.Hidden;
            suitsS4.Visibility = Visibility.Hidden;
            suitsS5.Visibility = Visibility.Hidden;
            suitsS1Label.Visibility = Visibility.Hidden;
            suitsS2Label.Visibility = Visibility.Hidden;
            suitsS3Label.Visibility = Visibility.Hidden;
            suitsS4Label.Visibility = Visibility.Hidden;
            suitsS5Label.Visibility = Visibility.Hidden;

            naruto_tvshows.Visibility = Visibility.Visible;
            suits_tvshows.Visibility = Visibility.Visible;
            vampirediaries_tvshows.Visibility = Visibility.Visible;
            pokemon_tvshows.Visibility = Visibility.Visible;
            tvshowTitle.Visibility = Visibility.Visible;
            tvshowListBack.Visibility = Visibility.Visible;
            tvshowList.Visibility = Visibility.Visible;


        }

        private void suitsRecommend(object sender, RoutedEventArgs e)
        {
            if (john_logged_on && !alex_logged_on)
            {
                Button notification = new Button();
                notification.Content = new TextBlock()
                {
                    Height = 95,
                    FontSize = 16,
                    Text = "John Smith recommends you to watch Suits! Click to watch the official trailer!",
                    TextAlignment = TextAlignment.Center,
                    VerticalAlignment = System.Windows.VerticalAlignment.Center,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                    TextWrapping = TextWrapping.Wrap
                };

                notification.Click += suits_Click;

                alex_notifications_feed.Children.Add(notification);
                MessageBox.Show("Recommendation sent!", "", MessageBoxButton.OK);
                gotNotification = true;
            }
            else if (alex_logged_on && !john_logged_on){
                Button notification = new Button();
                notification.Content = new TextBlock()
                {
                    Height = 95,
                    FontSize = 16,
                    Text = "Alex recommends you to watch Suits! Click to watch the official trailer!",
                    TextAlignment = TextAlignment.Center,
                    VerticalAlignment = System.Windows.VerticalAlignment.Center,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                    TextWrapping = TextWrapping.Wrap
                };

                notification.Click += suits_Click;

                john_notifications_feed.Children.Add(notification);
                MessageBox.Show("Recommendation sent!", "", MessageBoxButton.OK);
                gotNotification = true;
            }
            else MessageBox.Show("Please log in to send recommendations!", "", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void suits_Click(object sender, RoutedEventArgs e)
        {
            social_browser.Visibility = Visibility.Visible;
            social_browser.Navigate("http://www.usanetwork.com/suits");
        }

        private void suitsFavorite(object sender, RoutedEventArgs e)
        {
            if (john_logged_on)
            {
                john_tvshow_favorite = true;
                MessageBox.Show("Added to favorites!", "", MessageBoxButton.OK);
            }
            else if (alex_logged_on)
            {
                alex_tvshow_favorite = true;
                MessageBox.Show("Added to favorites!", "", MessageBoxButton.OK);
            }
            else MessageBox.Show("Please log in to add to favorites!", "", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void suitsS1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void suitsS2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void suitsS3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void suitsS4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void suitsS5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void backAvengers(object sender, RoutedEventArgs e)
        {
            avengersTitle.Visibility = Visibility.Hidden;
            avengersBackground.Visibility = Visibility.Hidden;
            avengersBack.Visibility = Visibility.Hidden;
            recommendAvengers.Visibility = Visibility.Hidden;
            favoriteAvengers.Visibility = Visibility.Hidden;
            avengersSynopisis.Visibility = Visibility.Hidden;
            avengersIcon.Visibility = Visibility.Hidden;
            playAvengers.Visibility = Visibility.Hidden;

            movieList.Visibility = Visibility.Visible;
            movieListBack.Visibility = Visibility.Visible;
            movieTitle.Visibility = Visibility.Visible;
            avengers_movies.Visibility = Visibility.Visible;
            transformer_movies.Visibility = Visibility.Visible;
            civilwar_trailer.Visibility = Visibility.Visible;
        }

        private void avengersRecommend(object sender, RoutedEventArgs e)
        {
            if (john_logged_on && !alex_logged_on)
            {
                Button notification = new Button();
                notification.Content = new TextBlock()
                {
                    Height = 95,
                    FontSize = 16,
                    Text = "John Smith recommends you to watch Marvel's The Avengers! Click to watch the official trailer!",
                    TextAlignment = TextAlignment.Center,
                    VerticalAlignment = System.Windows.VerticalAlignment.Center,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                    TextWrapping = TextWrapping.Wrap
                };

                notification.Click += notification_Click;

                alex_notifications_feed.Children.Add(notification);
                MessageBox.Show("Recommendation sent!", "", MessageBoxButton.OK);
                gotNotification = true;
            }
            else if (alex_logged_on && !john_logged_on)
            {
                Button notification = new Button();
                notification.Content = new TextBlock()
                {
                    Height = 95,
                    FontSize = 16,
                    Text = "Alex Wong recommends you to watch Marvel's The Avengers! Click to watch the official trailer!!",
                    TextAlignment = TextAlignment.Center,
                    VerticalAlignment = System.Windows.VerticalAlignment.Center,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                    TextWrapping = TextWrapping.Wrap
                };

                notification.Click += notification_Click;

                john_notifications_feed.Children.Add(notification);
                MessageBox.Show("Recommendation sent!", "", MessageBoxButton.OK);
                gotNotification = true;
            }
            else MessageBox.Show("Please log in to send recommendations!", "", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void avengersFavorite(object sender, RoutedEventArgs e)
        {
            if (john_logged_on == true)
            {
                john_movies_favorite = true;
                MessageBox.Show("Added to favorites!", "", MessageBoxButton.OK);
            }
            else if (alex_logged_on == true)
            {
                alex_movies_favorite = true;
                MessageBox.Show("Added to favorites!", "", MessageBoxButton.OK);
            }
            else MessageBox.Show("Please log in to add to favorites!", "", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void avengersPlay(object sender, RoutedEventArgs e)
        {

        }

        private void open_feed(object sender, RoutedEventArgs e)
        {
            if (in_account)
            {
                in_social = false;
                in_account = false;
            }

            if (!in_social)
            {
                notify_button.Visibility = Visibility.Hidden;
                social_button.Visibility = Visibility.Visible;
                notify = false;

                in_social = true;
                social_feed.Visibility = Visibility.Visible;
                social_feed_title.Visibility = Visibility.Visible;
                backSocial_button.Visibility = Visibility.Visible;

                separator.Visibility = Visibility.Visible;
                side_notify.Visibility = Visibility.Visible;
                side_facebook.Visibility = Visibility.Visible;
                side_twitter.Visibility = Visibility.Visible;

                if (john_logged_on && !alex_logged_on)
                    john_notifications_feed.Visibility = Visibility.Visible;
                else if (alex_logged_on && !john_logged_on)
                    alex_notifications_feed.Visibility = Visibility.Visible;

                account_page.Visibility = Visibility.Hidden;
                account_title.Visibility = Visibility.Hidden;
                backAccount_button.Visibility = Visibility.Hidden;
            }
            else backSocial(sender, e);
        }

        private void backSocial(object sender, RoutedEventArgs e)
        {
            social_feed.Visibility = Visibility.Hidden;
            social_feed_title.Visibility = Visibility.Hidden;
            backSocial_button.Visibility = Visibility.Hidden;

            separator.Visibility = Visibility.Hidden;
            side_notify.Visibility = Visibility.Hidden;
            side_facebook.Visibility = Visibility.Hidden;
            side_twitter.Visibility = Visibility.Hidden;
            john_notifications_feed.Visibility = Visibility.Hidden;
            alex_notifications_feed.Visibility = Visibility.Hidden;
            social_browser.Visibility = Visibility.Hidden;
            
            in_social = false;

            if (in_account)
            {
                account_page.Visibility = Visibility.Visible;
                account_title.Visibility = Visibility.Visible;
                backAccount_button.Visibility = Visibility.Visible;
            }
        }

        private void account_settings(object sender, RoutedEventArgs e)
        {
            if (in_social)
            {
                in_social = false;
                in_account = false;
            }
            if (!in_account)
            {
                in_account = true;
                account_page.Visibility = Visibility.Visible;
                account_title.Visibility = Visibility.Visible;
                backAccount_button.Visibility = Visibility.Visible;
                separator.Visibility = Visibility.Visible;

                social_feed.Visibility = Visibility.Hidden;
                social_feed_title.Visibility = Visibility.Hidden;
                backSocial_button.Visibility = Visibility.Hidden;

                side_notify.Visibility = Visibility.Hidden;
                side_facebook.Visibility = Visibility.Hidden;
                side_twitter.Visibility = Visibility.Hidden;
                john_notifications_feed.Visibility = Visibility.Hidden;
                alex_notifications_feed.Visibility = Visibility.Hidden;
                social_browser.Visibility = Visibility.Hidden;
            }
            else backAccount(sender, e);

        }

        private void backAccount(object sender, RoutedEventArgs e)
        {
            account_page.Visibility = Visibility.Hidden;
            account_title.Visibility = Visibility.Hidden;
            backAccount_button.Visibility = Visibility.Hidden;
            separator.Visibility = Visibility.Hidden;
            in_account = false;

            if (in_social)
            {
                notify_button.Visibility = Visibility.Hidden;
                social_button.Visibility = Visibility.Visible;
                notify = false;

                in_social = true;
                social_feed.Visibility = Visibility.Visible;
                social_feed_title.Visibility = Visibility.Visible;
                backSocial_button.Visibility = Visibility.Visible;

                side_notify.Visibility = Visibility.Visible;
                side_facebook.Visibility = Visibility.Visible;
                side_twitter.Visibility = Visibility.Visible;

                if (john_logged_on && !alex_logged_on)
                    john_notifications_feed.Visibility = Visibility.Visible;
                else if (alex_logged_on && !john_logged_on)
                    alex_notifications_feed.Visibility = Visibility.Visible;
            }
        }

        private void backBieber(object sender, RoutedEventArgs e)
        {
            bieberTitle.Visibility = Visibility.Hidden;
            bieberBackground.Visibility = Visibility.Hidden;
            bieberBack.Visibility = Visibility.Hidden;
            recommendBieber.Visibility = Visibility.Hidden;
            favoriteBieber.Visibility = Visibility.Hidden;
            bieberMusicList.Visibility = Visibility.Hidden;
            bieberIcon.Visibility = Visibility.Hidden;
            playAllBieber.Visibility = Visibility.Hidden;

            justinbieber_music.Visibility = Visibility.Visible;
            deadmau5_music.Visibility = Visibility.Visible;
            selenagomez_music.Visibility = Visibility.Visible;
            musicTitle.Visibility = Visibility.Visible;
            musicListBack.Visibility = Visibility.Visible;
            musicList.Visibility = Visibility.Visible;
        }

        private void bieberRecommend(object sender, RoutedEventArgs e)
        {
            if (john_logged_on && !alex_logged_on)
            {
                Button notification = new Button();
                notification.Content = new TextBlock()
                {
                    Height = 95,
                    FontSize = 16,
                    Text = "John Smith recommends you to listen to Justin Bieber's album titled \"Believe\"! Click to view in iTunes!",
                    TextAlignment = TextAlignment.Center,
                    VerticalAlignment = System.Windows.VerticalAlignment.Center,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                    TextWrapping = TextWrapping.Wrap
                };

                notification.Click += jb_Click;

                alex_notifications_feed.Children.Add(notification);
                MessageBox.Show("Recommendation sent!", "", MessageBoxButton.OK);
                gotNotification = true;
            }
            else if (alex_logged_on && !john_logged_on)
            {
                Button notification = new Button();
                notification.Content = new TextBlock()
                {
                    Height = 95,
                    FontSize = 16,
                    Text = "Alex Wong recommends you to listen to Justin Bieber's album titled \"Believe\"! Click to view in iTunes!",
                    TextAlignment = TextAlignment.Center,
                    VerticalAlignment = System.Windows.VerticalAlignment.Center,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                    TextWrapping = TextWrapping.Wrap
                };

                notification.Click += jb_Click;

                john_notifications_feed.Children.Add(notification);
                MessageBox.Show("Recommendation sent!", "", MessageBoxButton.OK);
                gotNotification = true;
            }
            else MessageBox.Show("Please log in to send recommendations!", "", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void jb_Click(object sender, RoutedEventArgs e)
        {
            social_browser.Visibility = Visibility.Visible;
            social_browser.Navigate("https://itunes.apple.com/us/movie/justin-biebers-believe/id806447738");
        }

        private void bieberFavorite(object sender, RoutedEventArgs e)
        {
            if (john_logged_on == true)
            {
                john_music_favorite = true;
                MessageBox.Show("Added to favorites!", "", MessageBoxButton.OK);
            }
            else if (alex_logged_on == true)
            {
                alex_music_favorite = true;
                MessageBox.Show("Added to favorites!", "", MessageBoxButton.OK);
            }
            else MessageBox.Show("Please log in to add to favorites!", "", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void bieberPlayAll(object sender, RoutedEventArgs e)
        {

        }

        private void bieber_favorites_Click(object sender, RoutedEventArgs e)
        {

        }

        private void avengers_favorites_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deadmau5_favorites_Click(object sender, RoutedEventArgs e)
        {

        }

        private void transformers_favorites_Click(object sender, RoutedEventArgs e)
        {

        }

        private void sidebar_notify(object sender, RoutedEventArgs e)
        {
            social_browser.Visibility = Visibility.Hidden;

            if (john_logged_on)
                john_notifications_feed.Visibility = Visibility.Visible;
            else if (alex_logged_on)
                alex_notifications_feed.Visibility = Visibility.Visible;

        }

        private void sidebar_facebook(object sender, RoutedEventArgs e)
        {
            john_notifications_feed.Visibility = Visibility.Hidden;
            alex_notifications_feed.Visibility = Visibility.Hidden;

            social_browser.Navigate("http://www.facebook.com");
            social_browser.Visibility = Visibility.Visible;
        }

        private void sidebar_twitter(object sender, RoutedEventArgs e)
        {
            john_notifications_feed.Visibility = Visibility.Hidden;
            alex_notifications_feed.Visibility = Visibility.Hidden;

            social_browser.Navigate("http://www.twitter.com");
            social_browser.Visibility = Visibility.Visible;
        }

        private void civilwar_click(object sender, RoutedEventArgs e)
        {
            civilwarTitle.Visibility = Visibility.Visible;
            civilwarBackground.Visibility = Visibility.Visible;
            civilwarBack.Visibility = Visibility.Visible;
            recommendCivilwar.Visibility = Visibility.Visible;
            favoriteCivilwar.Visibility = Visibility.Visible;
            civilwarSynopisis.Visibility = Visibility.Visible;
            civilwarIcon.Visibility = Visibility.Visible;
            playCivilwar.Visibility = Visibility.Visible;

            movieList.Visibility = Visibility.Hidden;
            movieListBack.Visibility = Visibility.Hidden;
            movieTitle.Visibility = Visibility.Hidden;
            avengers_movies.Visibility = Visibility.Hidden;
            transformer_movies.Visibility = Visibility.Hidden;
            civilwar_trailer.Visibility = Visibility.Hidden;
        }

        private void backCivilwar(object sender, RoutedEventArgs e)
        {
            civilwarTitle.Visibility = Visibility.Hidden;
            civilwarBackground.Visibility = Visibility.Hidden;
            civilwarBack.Visibility = Visibility.Hidden;
            recommendCivilwar.Visibility = Visibility.Hidden;
            favoriteCivilwar.Visibility = Visibility.Hidden;
            civilwarSynopisis.Visibility = Visibility.Hidden;
            civilwarIcon.Visibility = Visibility.Hidden;
            playCivilwar.Visibility = Visibility.Hidden;

            movieList.Visibility = Visibility.Visible;
            movieListBack.Visibility = Visibility.Visible;
            movieTitle.Visibility = Visibility.Visible;
            avengers_movies.Visibility = Visibility.Visible;
            transformer_movies.Visibility = Visibility.Visible;
            civilwar_trailer.Visibility = Visibility.Visible;
        }

        private void civilwarRecommend(object sender, RoutedEventArgs e)
        {

        }

        private void civilwarFavorite(object sender, RoutedEventArgs e)
        {

        }

        private void civilwarPlay(object sender, RoutedEventArgs e)
        {
            if (video_played == true)
            {
                resumeBackground.Visibility = Visibility.Visible;
                resumeButton.Visibility = Visibility.Visible;
                restartButton.Visibility = Visibility.Visible;
                cancelButton.Visibility = Visibility.Visible;
            }
            else
            {
                civilwarTitle.Visibility = Visibility.Hidden;
                civilwarBackground.Visibility = Visibility.Hidden;
                civilwarBack.Visibility = Visibility.Hidden;
                recommendCivilwar.Visibility = Visibility.Hidden;
                favoriteCivilwar.Visibility = Visibility.Hidden;
                civilwarSynopisis.Visibility = Visibility.Hidden;
                civilwarIcon.Visibility = Visibility.Hidden;
                playCivilwar.Visibility = Visibility.Hidden;

                MediaPlayer.Visibility = Visibility.Visible;
                civilwarTrailerBack.Visibility = Visibility.Visible;
                civilwarTrailerBackground.Visibility = Visibility.Visible;
                btnPlay.Visibility = Visibility.Visible;
                btnStop.Visibility = Visibility.Visible;
                btnMoveForward.Visibility = Visibility.Visible;
                btnMoveBack.Visibility = Visibility.Visible;
                btnPlay.IsEnabled = true;
            }
        }

        private void backCivilwarTrailer(object sender, RoutedEventArgs e)
        {
            if (video_playing == true)
            {
                MediaPlayer.Pause();
                video_playing = false;
                btnPlay.Visibility = Visibility.Visible;
                btnPause.Visibility = Visibility.Hidden;
                IsPlaying(false);
                btnPlay.IsEnabled = true;
            }
            MediaPlayer.Visibility = Visibility.Hidden;
            civilwarTrailerBack.Visibility = Visibility.Hidden;
            civilwarTrailerBackground.Visibility = Visibility.Hidden;
            btnPlay.Visibility = Visibility.Hidden;
            btnStop.Visibility = Visibility.Hidden;
            btnMoveForward.Visibility = Visibility.Hidden;
            btnMoveBack.Visibility = Visibility.Hidden;

            civilwarTitle.Visibility = Visibility.Visible;
            civilwarBackground.Visibility = Visibility.Visible;
            civilwarBack.Visibility = Visibility.Visible;
            recommendCivilwar.Visibility = Visibility.Visible;
            favoriteCivilwar.Visibility = Visibility.Visible;
            civilwarSynopisis.Visibility = Visibility.Visible;
            civilwarIcon.Visibility = Visibility.Visible;
            playCivilwar.Visibility = Visibility.Visible;
        }

        private void IsPlaying(bool flag)
        {
            btnPlay.IsEnabled = flag;
            btnStop.IsEnabled = flag;
            btnMoveBack.IsEnabled = flag;
            btnMoveForward.IsEnabled = flag;
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            IsPlaying(true);
            video_played = true;
            video_playing = true;
            if (btnPlay.Visibility == Visibility.Visible && btnPause.Visibility == Visibility.Hidden)
            {
                MediaPlayer.Play();
                btnPause.Visibility = Visibility.Visible;
                btnPlay.Visibility = Visibility.Hidden;
            }
            else
            {
                MediaPlayer.Pause();
                btnPlay.Visibility = Visibility.Visible;
                btnPause.Visibility = Visibility.Hidden;
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Pause();
            btnPlay.Visibility = Visibility.Visible;
            btnPause.Visibility = Visibility.Hidden; 
            IsPlaying(false);
            btnPlay.IsEnabled = true;
        }

        private void btnMoveBack_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Position -= TimeSpan.FromSeconds(10);
        }

        private void btnMoveForward_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Position += TimeSpan.FromSeconds(10);
            btnMoveForward.Visibility = Visibility.Visible;
        }

        private void cancel_click(object sender, RoutedEventArgs e)
        {
            resumeBackground.Visibility = Visibility.Hidden;
            resumeButton.Visibility = Visibility.Hidden;
            restartButton.Visibility = Visibility.Hidden;
            cancelButton.Visibility = Visibility.Hidden;
        }

        private void restart_click(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Position = TimeSpan.Zero;
            civilwarTitle.Visibility = Visibility.Hidden;
            civilwarBackground.Visibility = Visibility.Hidden;
            civilwarBack.Visibility = Visibility.Hidden;
            recommendCivilwar.Visibility = Visibility.Hidden;
            favoriteCivilwar.Visibility = Visibility.Hidden;
            civilwarSynopisis.Visibility = Visibility.Hidden;
            civilwarIcon.Visibility = Visibility.Hidden;
            playCivilwar.Visibility = Visibility.Hidden;
            resumeBackground.Visibility = Visibility.Hidden;
            resumeButton.Visibility = Visibility.Hidden;
            restartButton.Visibility = Visibility.Hidden;
            cancelButton.Visibility = Visibility.Hidden;

            MediaPlayer.Visibility = Visibility.Visible;
            civilwarTrailerBack.Visibility = Visibility.Visible;
            civilwarTrailerBackground.Visibility = Visibility.Visible;
            btnPlay.Visibility = Visibility.Visible;
            btnStop.Visibility = Visibility.Visible;
            btnMoveForward.Visibility = Visibility.Visible;
            btnMoveBack.Visibility = Visibility.Visible;
            btnPlay.IsEnabled = true;
        }

        private void resume_click(object sender, RoutedEventArgs e)
        {
            civilwarTitle.Visibility = Visibility.Hidden;
            civilwarBackground.Visibility = Visibility.Hidden;
            civilwarBack.Visibility = Visibility.Hidden;
            recommendCivilwar.Visibility = Visibility.Hidden;
            favoriteCivilwar.Visibility = Visibility.Hidden;
            civilwarSynopisis.Visibility = Visibility.Hidden;
            civilwarIcon.Visibility = Visibility.Hidden;
            playCivilwar.Visibility = Visibility.Hidden;
            resumeBackground.Visibility = Visibility.Hidden;
            resumeButton.Visibility = Visibility.Hidden;
            restartButton.Visibility = Visibility.Hidden;
            cancelButton.Visibility = Visibility.Hidden;

            MediaPlayer.Visibility = Visibility.Visible;
            civilwarTrailerBack.Visibility = Visibility.Visible;
            civilwarTrailerBackground.Visibility = Visibility.Visible;
            btnPlay.Visibility = Visibility.Visible;
            btnStop.Visibility = Visibility.Visible;
            btnMoveForward.Visibility = Visibility.Visible;
            btnMoveBack.Visibility = Visibility.Visible;
            btnPlay.IsEnabled = true;
        }
    }
}
