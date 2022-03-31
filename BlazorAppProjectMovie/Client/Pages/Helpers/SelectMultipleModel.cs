namespace BlazorAppProjectMovie.Client.Pages.Helpers
{
    public struct SelectMultipleModel
    {

        public SelectMultipleModel(string Llave, string Valor){
            llave = Llave;
            valor  = Valor;

        }

        public string llave { get; set; }
        public string valor { get; set; }
    }
}
