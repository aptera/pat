// Code generated by Microsoft (R) AutoRest Code Generator 1.2.2.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace TotallyNotRobots.Movies.Web.ApiClient.Models
{
    using Microsoft.Rest;
    using TotallyNotRobots.Movies.Web;
    using TotallyNotRobots.Movies.Web.ApiClient;
    using Newtonsoft.Json;
    using System.Linq;

    public partial class Movie
    {
        /// <summary>
        /// Initializes a new instance of the Movie class.
        /// </summary>
        public Movie()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Movie class.
        /// </summary>
        public Movie(string genre, int? id = default(int?), string title = default(string), System.DateTime? releaseDate = default(System.DateTime?), double? price = default(double?), string rating = default(string))
        {
            ID = id;
            Title = title;
            ReleaseDate = releaseDate;
            Genre = genre;
            Price = price;
            Rating = rating;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ID")]
        public int? ID { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Title")]
        public string Title { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ReleaseDate")]
        public System.DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Genre")]
        public string Genre { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Price")]
        public double? Price { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Rating")]
        public string Rating { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Genre == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Genre");
            }
            if (Title != null)
            {
                if (Title.Length > 60)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "Title", 60);
                }
                if (Title.Length < 3)
                {
                    throw new ValidationException(ValidationRules.MinLength, "Title", 3);
                }
            }
            if (Genre != null)
            {
                if (Genre.Length > 30)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "Genre", 30);
                }
                if (Genre.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "Genre", 0);
                }
                if (!System.Text.RegularExpressions.Regex.IsMatch(Genre, "^[A-Z]+[a-zA-Z''-'\\s]*$"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "Genre", "^[A-Z]+[a-zA-Z''-'\\s]*$");
                }
            }
            if (Price > 100)
            {
                throw new ValidationException(ValidationRules.InclusiveMaximum, "Price", 100);
            }
            if (Price < 1)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "Price", 1);
            }
            if (Rating != null)
            {
                if (Rating.Length > 5)
                {
                    throw new ValidationException(ValidationRules.MaxLength, "Rating", 5);
                }
                if (Rating.Length < 0)
                {
                    throw new ValidationException(ValidationRules.MinLength, "Rating", 0);
                }
                if (!System.Text.RegularExpressions.Regex.IsMatch(Rating, "^[A-Z]+[a-zA-Z''-'\\s]*$"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "Rating", "^[A-Z]+[a-zA-Z''-'\\s]*$");
                }
            }
        }
    }
}
