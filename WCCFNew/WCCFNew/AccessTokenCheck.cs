using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
using System.IO;
using Facebook;

namespace WCCFNew
{
    class AccessTokenCheck
    {
        private string accessToken;

        public AccessTokenCheck(string token)
        {
            accessToken = token;
        }

        public string getExtendedToken
        {
            get
            {
                return GetExtendedAccessToken(accessToken);
            }
        }

        /// <summary>
        /// Extends AccessToken timeout from 1-2 Hours to 60 Days
        /// </summary>
        /// <param name="ShortLivedToken"></param>
        /// <returns>Returns new accessToken</returns>
        private string GetExtendedAccessToken(string ShortLivedToken)
        {
            FacebookClient client = new FacebookClient();
            string extendedToken = "";
            try
            {
                dynamic result = client.Get("/oauth/access_token", new
                {
                    grant_type = "fb_exchange_token",
                    client_id = "145634995501895",
                    client_secret = "c52bbc56700c90faba4f953075d49889",
                    fb_exchange_token = ShortLivedToken
                });
                extendedToken = result.access_token;
            }
            catch
            {
                extendedToken = ShortLivedToken;
            }
            return extendedToken;
        }
    }
}
