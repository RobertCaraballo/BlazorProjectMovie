using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorAppProjectMovie.Client.Pages.Helpers
{
    public partial class Counter : ComponentBase
    {

        [Inject] ServiciosSingleton singlenton { get; set; }
        [Inject] ServiciosTransistorio Transistorio { get; set; }
        [Inject] IJSRuntime JS { get; set; }
        //[Inject] IJSRuntime js

        //IJSObjectReference jsoref;
        protected int currentCount = 0;
        static int currentCountStatic = 0;



        //protected override async Task OnAfterRenderAsync(bool firstRender)
        //{
        //    if (firstRender)
        //    {
        //        //    jsoref = await js.InvokeAsync<IJSObjectReference>("import", "js/Utilities.js");
        //    }
        //}

        [JSInvokable]
        public async Task IncrementCount()
        {
            currentCount++;
            singlenton.valor = currentCount;
            Transistorio.valor = currentCount;
            currentCountStatic++;
            await JS.InvokeVoidAsync("pruebaPuntoNetStatic");

        }

        protected async Task IncrementCountJS()
        {
            //await jsoref.InvokeVoidAsync("pruebaPuntoNetInstancia", DotNetObjectReference.Create(this));

        }

        [JSInvokable]
        public static Task<int> GetCurrentCount() => Task.FromResult(currentCountStatic);
    }
}
