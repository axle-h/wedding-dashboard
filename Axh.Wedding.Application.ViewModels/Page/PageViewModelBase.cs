namespace Axh.Wedding.Application.ViewModels.Page
{
    public abstract class PageViewModelBase
    {
        protected PageViewModelBase(string title)
        {
            this.Title = title;
        }

        public string Title { get; set; }
    }
}
