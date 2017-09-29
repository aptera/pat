// Code generated by Microsoft (R) AutoRest Code Generator 1.2.2.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace TotallyNotRobots.Movies.Api.Integration.Tests.ApiClient
{
    using Models;
    using System.Threading;
    using System.Threading.Tasks;
    using TotallyNotRobots.Movies;
    using TotallyNotRobots.Movies.Api;
    using TotallyNotRobots.Movies.Api.Integration;
    using TotallyNotRobots.Movies.Api.Integration.Tests;

    /// <summary>
    /// Extension methods for Seed.
    /// </summary>
    public static partial class SeedExtensions
    {
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static void PostData(this ISeed operations)
            {
                operations.PostDataAsync().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task PostDataAsync(this ISeed operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.PostDataWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

    }
}
