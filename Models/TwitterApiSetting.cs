using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tweetr.Models
{
    public class TwitterApiSetting
    {
        public string ConsumerKey { get; set; }
        public string ConsumerSecrect { get; set; }
        public  string OAuthToken { get; set; }
        public string OAuthTokenSecrect { get; set; }
    }
}
