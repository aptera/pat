// Code generated by Microsoft (R) AutoRest Code Generator 1.2.2.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace TotallyNotRobots.Movies.Api.Integration.Tests.ApiClient
{
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using TotallyNotRobots.Movies;
    using TotallyNotRobots.Movies.Api;
    using TotallyNotRobots.Movies.Api.Integration;
    using TotallyNotRobots.Movies.Api.Integration.Tests;

    /// <summary>
    /// Extension methods for Reviews.
    /// </summary>
    public static partial class ReviewsExtensions
    {
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='movieID'>
            /// </param>
            public static IList<Review> Get(this IReviews operations, int movieID)
            {
                return operations.GetAsync(movieID).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='movieID'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<Review>> GetAsync(this IReviews operations, int movieID, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(movieID, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='movieID'>
            /// </param>
            /// <param name='review'>
            /// </param>
            public static Review Post(this IReviews operations, int movieID, Review review)
            {
                return operations.PostAsync(movieID, review).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='movieID'>
            /// </param>
            /// <param name='review'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Review> PostAsync(this IReviews operations, int movieID, Review review, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.PostWithHttpMessagesAsync(movieID, review, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
