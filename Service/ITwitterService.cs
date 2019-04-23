using System.Collections.Generic;
using Tweetr.Models;

namespace Tweetr.Service
{
    public interface ITwitterService
    {
        List<Tweet> GetTweets();
    }
}