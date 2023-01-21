using System.Runtime.Serialization;

namespace MovieNotice.API.Exceptions
{
    [Serializable]
    internal class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }

    }
}