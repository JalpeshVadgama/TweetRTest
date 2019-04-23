using LinqToTwitter;
using Microsoft.Extensions.Options;
using Tweetr.Models;
using System.Linq;
using System.Collections.Generic;

namespace Tweetr.Service
{
    public class TwitterService : ITwitterService
    {
        private readonly TwitterApiSetting _twitterApiSetting;
        private readonly TwitterContext _twitterContext;

        public TwitterService(IOptions<TwitterApiSetting> twitterApiSetting)
        {
            _twitterApiSetting = twitterApiSetting.Value;

            var auth = new SingleUserAuthorizer
            {
                CredentialStore = new InMemoryCredentialStore()
                {
                    ConsumerKey = _twitterApiSetting.ConsumerKey,
                    ConsumerSecret = _twitterApiSetting.ConsumerSecrect,
                    OAuthToken = _twitterApiSetting.OAuthToken,
                    OAuthTokenSecret = _twitterApiSetting.OAuthTokenSecrect
                }
            };
            this._twitterContext = new TwitterContext(auth);
        }

        public List<Tweet> GetTweets()
        {
            var tweets =
                from tw in _twitterContext.Status
                where
                    tw.Type == StatusType.User &&
                    tw.ScreenName == "jalpesh"
                select tw;
            // handle exceptions, twitter service might be down
            try
            {
                // map to list
                return tweets
                    .Take(10)
                    .Select(t =>
                        new Tweet
                        {
                            Username = t.ScreenName,
                            FullName = t.User.Name,
                            Text = t.Text
                        })
                    .ToList();
            }
            catch (System.Exception ex) { }
            // return empty
            return new List<Tweet>();
        }
    }
}
