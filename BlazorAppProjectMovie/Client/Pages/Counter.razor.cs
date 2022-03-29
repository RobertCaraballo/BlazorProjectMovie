using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using static BlazorAppProjectMovie.Client.Shared.MainLayout;

namespace BlazorAppProjectMovie.Client.Pages
{
    public partial class Counter
    {
        [Inject] ServiciosSingleton singlenton { get; set; }
        [Inject] ServiciosTransistorio Transistorio { get; set; }

        [Inject] IJSRuntime JS { get; set; }



        IJSObjectReference modulo;

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

            //modulo = await JS.InvokeAsync<IJSObjectReference>("import", "./js/JavaScript.js");
            //await modulo.InvokeVoidAsync("mostrarAlerta");


            currentCount++;
            singlenton.valor = currentCount;
            Transistorio.valor = currentCount;
            currentCountStatic++;
            await JS.InvokeVoidAsync("pruebaPuntoNetStatic");

        }

        protected async Task IncrementCountJS()
        {
            await JS.InvokeVoidAsync("pruebaPuntoNetInstancia", DotNetObjectReference.Create(this));

        }

        [JSInvokable]
        public static Task<int> GetCurrentCountt() => Task.FromResult(currentCountStatic);
    }
}
