namespace Axh.Wedding.Application.ViewModels.Page
{
    public abstract class PageViewModelBase
    {
        public string ApplicationTitle { get; set; }

        public string ApplicationSubTitle { get; set; }

        public HeaderViewModel Header { get; set; }

    }
}
