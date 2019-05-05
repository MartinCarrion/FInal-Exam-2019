using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace Question1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        List<Movie> movies = new List<Movie>();
        List<Movie> IMDBScores = new List<Movie>();

        public MainWindow()
        {
            InitializeComponent();
            ClearAll();
        }
        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            using (var client = new HttpClient())//JSON WEB
            {
                var response = client.GetAsync(@"http://pcbstuou.w27.wh-2.com/webservices/3033/api/Movies?number=100").Result;
                var content = response.Content.ReadAsStringAsync().Result;
                movies = JsonConvert.DeserializeObject<List<Movie>>(content);
            }
            Question1(movies);
            Question2(movies);
            Question3(movies, 350000);
            Question4(movies);
            Question5(movies);
        }
        private void Question1(List<Movie> movies)
        {
            //Genres(movies);//List all different genres for the movies
            Dictionary<string, int> genres = new Dictionary<string, int>();
            foreach (var movie in movies)
            {
                if (movie.genres.Contains('|'))
                {
                    var gs = movie.genres.Split('|');
                    foreach (var g in gs)
                    {
                        if (genres.ContainsKey(g))
                        {
                            genres[g] = genres[g] + 1;
                        }
                        else
                        {
                            genres.Add(g, 1);
                        }
                    }
                }
                else
                {
                    if (genres.ContainsKey(movie.genres))
                    {
                        genres[movie.genres] = genres[movie.genres] + 1;
                    }
                    else
                    {
                        genres.Add(movie.genres, 1);
                    }
                }
            }
            foreach (var key in genres.Keys)
            {
                lstGenres.Items.Add($"{ key} ({ genres[key].ToString("N0")})");
            }

        }
        private void Question2(List<Movie> movies)
        {
            foreach (var movie in movies)
            {
                if (IMDBScores.Count < 1)
                {
                    IMDBScores.Add(movie);
                    continue;
                }
                else
                {
                    if (IMDBScores[0].imdb_score < movie.imdb_score)//we have a new high score
                    {
                        IMDBScores.Clear();
                        IMDBScores.Add(movie);
                    }
                    else if (IMDBScores[0].imdb_score == movie.imdb_score)
                    {
                        IMDBScores.Add(movie);
                    }
                    else
                    {

                    }
                }
            }
            if (IMDBScores.Count() > 1)
            {
                string content = "";
                foreach (var m in IMDBScores)
                {
                    content += m.movie_title + '\n';
                }
                txtHighestIMDBScore.Text = content;
            }
            else
            {
                Hyperlink h = new Hyperlink();
                h.NavigateUri = new Uri(IMDBScores[0].movie_imdb_link);
                h.Inlines.Add(IMDBScores[0].movie_title);
                h.RequestNavigate += LinkOnRequestNavigate;
                txtHighestIMDBScore.Inlines.Add(h);
            }
        }
        private void LinkOnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.ToString());
        }
        private void Question3(List<Movie> movies, int v)
        {
            foreach (var movie in movies)
            {
                if (movie.num_voted_users >= v)
                {
                    Hyperlink h = new Hyperlink();
                    h.NavigateUri = new Uri(movie.movie_imdb_link);
                    h.Inlines.Add(movie.movie_title);
                    h.RequestNavigate += LinkOnRequestNavigate;
                    lstVotedUsers.Items.Add(h);
                }
            }
        }
        private void Question4(List<Movie> movies)
        {
            int count = 0;
            foreach (var movie in movies)
            {
                if (movie.director_name == "Anthony Russo")
                {
                    count++;
                }
            }
            txtAnthonyRusso.Text = count.ToString("N0");
        }
        private void Question5(List<Movie> movies)
        {
            int count = 0;
            foreach (var movie in movies)
            {
                if (movie.actor_1_name == "Robert Downey Jr.")
                {
                    count++;
                }
                txtRobertDowney.Text = count.ToString("N0");
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtRobertDowney.Inlines.Clear();
            txtHighestIMDBScore.Inlines.Clear();
            txtAnthonyRusso.Inlines.Clear();
            lstGenres.Items.Clear();
            lstVotedUsers.Items.Clear();

        }
        private void ClearAll()
        {
            txtAnthonyRusso.Inlines.Clear();
            txtHighestIMDBScore.Inlines.Clear();
            txtRobertDowney.Inlines.Clear();
            lstGenres.Items.Clear();
            lstVotedUsers.Items.Clear();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txtAnthonyRusso.Inlines.Clear();
            txtHighestIMDBScore.Inlines.Clear();
            txtRobertDowney.Inlines.Clear();
            lstGenres.Items.Clear();
            lstVotedUsers.Items.Clear();
            txtAnthonyRusso.Text = "";
            txtHighestIMDBScore.Text = "";
            txtRobertDowney.Text = "";
        }
    }
}
