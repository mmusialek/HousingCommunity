using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Vetheria.AuthServer.ViewModels.Authorization;

public class LogoutViewModel
{
    [BindNever]
    public string? RequestId { get; set; }
}
