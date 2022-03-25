function pruebaPuntoNetStatic() {

    DotNet.invokeMethodAsync("BlazorAppProjectMovie.Client", "GetCurrentCountt")
        .then(resultado => {
            console.log("count form js " + resultado);

        });
}

function pruebaPuntoNetInstancia(dotnetHelper) {
    dotnetHelper.invokeMethodAsync("IncrementCount");
}