﻿using System;
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
        private Boolean feed_open = true;
        private Boolean tvshow_favorite = false;
        private Boolean movies_favorite = false;
        private Boolean music_favorite = false;

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
            avengers_movies.Visibility = Visibility.Visible;
            transformer_movies.Visibility = Visibility.Visible;
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
            

            //LOGIN LOGIC HERE. If not authorized, don't log in, otherwise login

            account_button.Visibility = Visibility.Visible;
            logout_button.Visibility = Visibility.Visible;
        }

        private void closeMovieList(object sender, RoutedEventArgs e)
        {
            movieList.Visibility = Visibility.Hidden;
            movieListBack.Visibility = Visibility.Hidden;
            movieTitle.Visibility = Visibility.Hidden;
            avengers_movies.Visibility = Visibility.Hidden;
            transformer_movies.Visibility = Visibility.Hidden;
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

        private void open_feed(object sender, RoutedEventArgs e)
        {
            //Toggle open/close the social media feed
            if (feed_open)
            {
                media_feed.Visibility = Visibility.Visible;
                media_feed_title.Visibility = Visibility.Visible;

                feed_open = false;
            }
            else if (!feed_open)
            {
                media_feed.Visibility = Visibility.Hidden;
                media_feed_title.Visibility = Visibility.Hidden;

                feed_open = true;
            }
        }

        private void logout_button_Click(object sender, RoutedEventArgs e)
        {
            Login_button.Visibility = Visibility.Visible;
            Login.Visibility = Visibility.Visible;
            Username_form.Visibility = Visibility.Visible;
            Password.Visibility = Visibility.Visible;
            Password_form.Visibility = Visibility.Visible;

            logout_button.Visibility = Visibility.Hidden;
            account_button.Visibility = Visibility.Hidden;

            //LOGOUT LOGIC HERE
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

        }

        private void suitsFavorite(object sender, RoutedEventArgs e)
        {

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
        }

        private void avengersRecommend(object sender, RoutedEventArgs e)
        {

        }

        private void avengersFavorite(object sender, RoutedEventArgs e)
        {

        }

        private void avengersPlay(object sender, RoutedEventArgs e)
        {

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

        }

        private void bieberFavorite(object sender, RoutedEventArgs e)
        {

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
    }
}
