using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Problem1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Movie> Movies = new List<Movie>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                var Response = client.GetAsync(@"http://pcbstuou.w27.wh-2.com/webservices/3033/api/Movies?number=100").Result;
                if (Response.IsSuccessStatusCode)
                {
                    var Content = Response.Content.ReadAsStringAsync().Result;
                    Movie M=JsonConvert.DeserializeObject<Movie>(Content);
                    var lines = File.ReadAllLines(Content);
                    int Count = 0;
                    foreach (var line in lines)
                    {
                        if (Count!=0)
                        {
                            var linepieces = line.Split('|');
                            string director_name, genres, actor_1_name, movie_title, plot_keywords, movie_imdb_link, language, country, content_rating;
                            int movie_ID, num_critic_for_reviews, duration, num_voted_users, cast_total_facebook_likes, num_user_for_reviews, title_year, movie_faceook_likes;
                            double gross,budget,imdb_score;
                            movie_ID = Convert.ToInt32(Content[0]);
                            director_name = linepieces[1];
                            num_critic_for_reviews = Convert.ToInt32(linepieces[2]);
                            duration = Convert.ToInt32(linepieces[3]);
                            gross = Convert.ToInt32(linepieces[4]);
                            genres = linepieces[5];
                            actor_1_name = linepieces[6];
                            movie_title = linepieces[7];
                            num_voted_users = Convert.ToInt32(linepieces[8]);
                            cast_total_facebook_likes = Convert.ToInt32(linepieces[9]);
                            plot_keywords = linepieces[10];
                            movie_imdb_link = linepieces[11];
                            num_user_for_reviews = Convert.ToInt32(linepieces[12]);
                            language = linepieces[13];
                            country = linepieces[14];
                            content_rating = linepieces[15];
                            budget = Convert.ToInt32(linepieces[16]);
                            title_year = Convert.ToInt32(linepieces[17]);
                            imdb_score = Convert.ToInt32(linepieces[18]);
                            movie_faceook_likes = Convert.ToInt32(linepieces[19]);
                            //Movie description = new Movie(movie_ID,director_name,num_critic_for_reviews,duration,gross,genres,actor_1_name,movie_title,num_voted_users,cast_total_facebook_likes,
                            //    plot_keywords,movie_imdb_link,num_user_for_reviews,language,country,content_rating,budget,title_year,imdb_score,movie_faceook_likes);
                            //Movies.Add(description);

                        }
                        Count++;
                    }
                    differentgenres();
                    highestscore();
                    Thirtyfive();
                }
            }
        }
        private void differentgenres()
        {
            foreach (var description in Movies)
            {
                if (description.Genres!="")
                {
                    lstDifferentGenres.Items.Add(description);

                }
            }

        }
        private void highestscore()
        {
           
            var equation = Movies.OrderByDescending(x => x.Imdb_Score).FirstOrDefault();
            lsthighestscore.Items.Add(equation);
            
        }
        private void Thirtyfive()
        {
            foreach (var description in Movies)
            {
                var equationthirty = Movies.Where(x =>x.Num_Voted_Users==350000);
                lstmorethan350000.Items.Add(equationthirty);

            }
        }
        
    }
}
