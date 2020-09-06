using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorCMS.Web.Services.UI
{
    public enum UIMessageType
    {
        Success, 
        Error,
        Warning,
        Info
    }

    public interface INotificationService
    {
        Task SendMessageAsync(string message, UIMessageType type = UIMessageType.Success);
    }

    public class NotificationService : INotificationService
    {
        private IJSRuntime _jsRuntime { get; set; }
        public NotificationService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
        public async Task SendMessageAsync(string message, UIMessageType type = UIMessageType.Success)
        {
            switch (type)
            {
                case UIMessageType.Success:
                    await _jsRuntime.InvokeVoidAsync("toastr.success", message);
                    break;
                case UIMessageType.Error:
                    await _jsRuntime.InvokeVoidAsync("toastr.error", message);
                    break;
                case UIMessageType.Info:
                    await _jsRuntime.InvokeVoidAsync("toastr.info", message);
                    break;
                case UIMessageType.Warning:
                    await _jsRuntime.InvokeVoidAsync("toastr.warning", message);
                    break;
            }
        }
    }
}
