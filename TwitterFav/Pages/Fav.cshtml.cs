using CoreTweet;
using CoreTweet.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using TwitterFav.Core;

namespace TwitterFav.Pages
{
    public class FavModel : PageModel
    {
        private readonly ITwitterFavRedirectParameter _twitterFavRedirectParameter;

        [BindProperty]
        public List<MediaEntity> UrlList { get; set; }

        public FavModel(ITwitterFavRedirectParameter twitterFavRedirectParameter)
        {
            _twitterFavRedirectParameter = twitterFavRedirectParameter;
        }

        public void OnGet(string oauth_token, string oauth_verifier)
        {
            var session = _twitterFavRedirectParameter.Pop();
            var tokens = OAuth.GetTokens(session, oauth_verifier);

            ListedResponse<Status> list = tokens.Favorites.List(count => 200);

            UrlList = list.Where(x => x.Entities.Media != null)
                          .SelectMany(x => x.Entities.Media)
                          .ToList();
        }
    }
}
