namespace BlazorAppProjectMovie.Client.Pages.Helpers
{
    public class MostrarMensajes : IMostrarMensaje
    {
        public async Task MostrarMensajeError(string mensaje)
        {
            await Task.FromResult(0);
        }
    }
}
