using MovieNotice.API.Settings;
using TMDbLib.Client;

namespace MovieNotice.API.Data
{
    public sealed class RemoteMovieApi : IRemoteMovieApi
    {
        
        private readonly AuthenitactionSettings _authenitactionSettings;
        private TMDbClient _client;

        public RemoteMovieApi(AuthenitactionSettings authenitactionSettings)
        {
            this._authenitactionSettings = authenitactionSettings;
            _client = new TMDbClient(_authenitactionSettings.TMDbAuthKey);

        }

        public TMDbClient GetClient()
        {
            if(_client == null )
            {
                _client = new TMDbClient(_authenitactionSettings.TMDbAuthKey);
            }
            return _client;
        }

    }
}
