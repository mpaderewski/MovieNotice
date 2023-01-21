using TMDbLib.Client;

namespace MovieNotice.API.Data
{
    public class RemoteMovieApi : IRemoteMovieApi
    {
        private static readonly Lazy<RemoteMovieApi> _lazy = new Lazy<RemoteMovieApi>( () => new RemoteMovieApi() );
        private TMDbClient _client;

        public RemoteMovieApi()
        {
            _client = new TMDbClient("0064b34021951fd3ae08591131d3577d");
        }

        public TMDbClient GetClient()
        {
            return _lazy.Value._client;
        }
        public static RemoteMovieApi Instance { get { return _lazy.Value; } }

    }
}
