using CoreTweet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TwitterFav.Core;

namespace TwitterFav.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly TwitterKey _options;
        private readonly ITwitterFavRedirectParameter _twitterFavRedirectParameter;

        public IndexModel(IOptions<TwitterKey> options,
            ILogger<IndexModel> logger,
            ITwitterFavRedirectParameter twitterFavRedirectParameter)
        {
            _logger = logger;
            _options = options.Value;
            _twitterFavRedirectParameter = twitterFavRedirectParameter;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPostOauth()
        {
            //OAuth2Token apponly = OAuth2.GetToken(
            //    "XgeJNQP4occamflfayvfoHH3o",
            //    "1PoyN3spdK7tfUMWluVYuuSCrVKHoF9hTI9UPw0g6rRLmYVJOd");

            //foreach (var status in apponly.Search.Tweets(q => "tea"))
            //{
            //    Console.WriteLine("{0}: {1}", status.User.ScreenName, status.Text);
            //}

            var oAuthSession = OAuth.Authorize(_options.Apikey, _options.ApiSecretkey,
                                        "https://localhost:44380/Fav");

            // セッション情報にOAuthSessionの内容を保存
            //pageRedirectParameter.Push(oAuthSession);
            _twitterFavRedirectParameter.Push(oAuthSession);

            return Redirect(oAuthSession.AuthorizeUri.OriginalString);
        }
    }
}
