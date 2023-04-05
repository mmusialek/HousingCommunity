using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Hacomm.AuthServer.ViewModels.Authorization;

public class LogoutViewModel
{
    [BindNever]
    public string? RequestId { get; set; }
}
