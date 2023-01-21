using TMDbLib.Client;

namespace MovieNotice.API.Data
{
    public interface IRemoteMovieApi
    {
        public static RemoteMovieApi Instance;

        public TMDbClient GetClient();
  
    }
}
