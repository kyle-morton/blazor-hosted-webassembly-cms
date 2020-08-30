using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorCMS.Web.Services
{
    public enum UIMessageType
    {
        Success, 
        Error,
        Warning,
        Info
    }

    public interface IUINotificationService
    {
        Task SendMessage(string message, UIMessageType type = UIMessageType.Success);
    }

    public class UINotificationService : IUINotificationService
    {
        private IJSRuntime _jsRuntime { get; set; }
        public UINotificationService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
        public async Task SendMessage(string message, UIMessageType type = UIMessageType.Success)
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
