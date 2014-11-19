namespace Axh.Wedding.Application.ViewModels.Page
{
    public class HeaderViewModel
    {
        public string HeaderBackgroundUrl { get; set; }

        public string PageTitle { get; set; }

        public string PageSubTitle { get; set; }

        /// <summary>
        /// True if the text on top of the header image needs to be light
        /// </summary>
        public bool IsLight { get; set; }
    }
}
