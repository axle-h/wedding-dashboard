namespace Axh.Wedding.Application.ViewModels.Page
{
    using Axh.Wedding.Application.ViewModels.Account;

    public abstract class PageViewModelBase
    {
        public string ApplicationTitle { get; set; }

        public string ApplicationSubTitle { get; set; }

        public HeaderViewModel Header { get; set; }

        public FooterViewModel Footer { get; set; }

        public UserViewModel User { get; set; }
    }
}
