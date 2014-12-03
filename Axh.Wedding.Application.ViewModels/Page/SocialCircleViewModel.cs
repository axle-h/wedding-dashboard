namespace Axh.Wedding.Application.ViewModels.Page
{
    using System;

    public class SocialCircleViewModel
    {
        private const string TwitterUrl = "https://twitter.com/";
        private const string FacebookUrl = "https://www.facebook.com/";
        private const string GooglePlusUrl = "https://plus.google.com/";
        private const string GitHubUrl = "https://github.com/";
        private const string LinkedInUrl = "https://www.linkedin.com/";
        private const string MailTo = "mailto:";

        public SocialCircleViewModel(string url, SocialCircleType type)
        {
            this.Url = GetUrlPrefix(type) + url;
            this.Type = type;
        }

        public string Url { get; set; }

        public SocialCircleType Type { get; set; }

        private static string GetUrlPrefix(SocialCircleType type)
        {
            switch (type)
            {
                case SocialCircleType.Twitter:
                    return TwitterUrl;
                case SocialCircleType.Facebook:
                    return FacebookUrl;
                case SocialCircleType.GooglePlus:
                    return GooglePlusUrl;
                case SocialCircleType.GitHub:
                    return GitHubUrl;
                case SocialCircleType.LinkedIn:
                    return LinkedInUrl;
                case SocialCircleType.Email:
                    return MailTo;
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }
    }
}
