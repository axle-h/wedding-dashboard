namespace Axh.Wedding.Application.ViewModels.Page
{
    public class HeaderImageViewModel
    {
        public string Url { get; set; }

        /// <summary>
        /// True if text on top of the header image needs to be light
        /// </summary>
        public bool IsLight { get; set; }

        public bool ExtraVerticalMargin { get; set; }

        public string Title { get; set; }
        
        public string SubTitle { get; set; }

        public string ButtonUrl { get; set; }

        public string ButtonText { get; set; }
    }
}
