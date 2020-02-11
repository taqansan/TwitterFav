using static CoreTweet.OAuth;

namespace TwitterFav.Core
{
    public interface ITwitterFavRedirectParameter
    {
        public void Push(OAuthSession value);

        public OAuthSession Pop();
    }

    public class TwitterFavRedirectParameter : ITwitterFavRedirectParameter
    {
        private OAuthSession oAuthSession { get; set; }

        public void Push(OAuthSession value)
        {
            oAuthSession = value;
        }

        public OAuthSession Pop()
        {
            return oAuthSession;
        }
    }
}
