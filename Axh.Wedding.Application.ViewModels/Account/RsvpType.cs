namespace Axh.Wedding.Application.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public enum RsvpType
    {
        [Display(ResourceType = typeof(Resources.Resources), Name = "User_RsvpType_None")]
        None = 0,

        [Display(ResourceType = typeof(Resources.Resources), Name = "User_RsvpType_Day")]
        Day = 1,

        [Display(ResourceType = typeof(Resources.Resources), Name = "User_RsvpType_Evening")]
        Evening = 2
    }
}
