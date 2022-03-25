using Microsoft.JSInterop;

namespace BlazorAppProjectMovie.Client.Pages.Helpers
{
    public static class USRuntimeExtensionMethods
    {
        public static async ValueTask<bool> Confirm(this IJSRuntime js, string mensaje)
        {
            return await js.InvokeAsync<bool>("confirm", mensaje);
        }
    }
}
