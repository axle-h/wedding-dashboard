namespace Axh.Wedding.Application.ViewModels.Admin
{
    using System.Collections.Generic;
    using Axh.Wedding.Application.ViewModels.Account;
    using Axh.Wedding.Application.ViewModels.Page;

    public class AdminPageViewModel : PageViewModelBase
    {
        public IEnumerable<UserViewModel> Users { get; set; }
    }
}
