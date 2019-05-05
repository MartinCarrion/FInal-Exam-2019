using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    class Movie
    {//"movie_facebook_likes": 197000 }

        public int Movie_ID { get; set; }
        public string Director_Name { get; set; }
        public int Num_critic_for_reviews { get; set; }
        public int Duration { get; set; }
        public double Gross { get; set; }
        public string Genres { get; set; }
        public string Actor_1_Name { get; set; }
        public string Movie_Title { get; set; }
        public int Num_Voted_Users { get; set; }
        public int Cast_Total_Facebook_Likes { get; set; }
        public string Plot_Keywords { get; set; }
        public string Movie_imdb_Link { get; set; }
        public int Num_User_For_Reviews { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Content_Rating { get; set; }
        public double Budget { get; set; }
        public int Title_Year { get; set; }
        public double Imdb_Score { get; set; }
        public int Movie_Facebook_Likes { get; set; }

        public Movie()
        {
            Movie_ID = 0;
            Director_Name = "";
            Num_critic_for_reviews = 0;
            Duration = 0;
            Gross = 0.00;
            Genres = "";
            Actor_1_Name = "";
            Movie_Title = "";
            Num_Voted_Users = 0;
            Cast_Total_Facebook_Likes = 0;
            Plot_Keywords = "";
            Movie_imdb_Link = "";
            Num_User_For_Reviews = 0;
            Language = "";
            Country = "";
            Content_Rating = "";
            Budget = 0.00;
            Title_Year = 0;
            Imdb_Score = 0.00;
            Movie_Facebook_Likes = 0;

        }
        //public Movie(int movie_ID, string director_name, int num_critic_for_reviews, int duration, double gross, string genres, string actor_1_name, string movie_title,
        //  int num_voted_users, int cast_total_facebook_likes, string plot_keywords, string movie_imdb_link, int num_user_for_reviews, string language, string country,
        //   string content_rating, double budget, int title_year, double imdb_score, int movie_faceook_likes)
        //{
        //    Movie_ID = movie_ID;
        //    Director_Name = director_name;
        //    Num_critic_for_reviews = num_critic_for_reviews;
        //    Duration = duration;
        //    Gross = gross;
        //    Genres = genres;
        //    Actor_1_Name = actor_1_name;
        //    Movie_Title = movie_title;
        //    Num_Voted_Users = num_voted_users;
        //    Cast_Total_Facebook_Likes = cast_total_facebook_likes;
        //    Plot_Keywords = plot_keywords;
        //    Movie_imdb_Link = movie_imdb_link;
        //    Num_User_For_Reviews = num_user_for_reviews;
        //    Language = language;
        //    Country = country;
        //    Content_Rating = content_rating;
        //    Budget = budget;
        //    Title_Year = title_year;
        //    Imdb_Score = imdb_score;
        //    Movie_Facebook_Likes = movie_faceook_likes;

        //}






    }
}
