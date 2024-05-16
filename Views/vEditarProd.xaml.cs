namespace hchavezS7Deber.Views;


using Newtonsoft.Json;
using System.Net;

public partial class vEditarProd : ContentPage
{
	public vEditarProd(Estudiante datos)
	{
		InitializeComponent();
        txtCodigo.Text = datos.codigo.ToString();
        txtNombre.Text = datos.nombre;
        txtProveedor.Text = datos.proveedor;
        txtPrecio.Text = datos.precio.ToString();
        txtCategoria.Text = datos.categoria;
    }
    
    //metodo actualizar
    private async void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            string codigo = txtCodigo.Text;
            string url = $"http://localhost/appmovil/post.php?codigo={codigo}";


            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("categoria", txtCategoria.Text);
            parametros.Add("proveedor", txtProveedor.Text);
            parametros.Add("precio", txtPrecio.Text);


            using (WebClient cliente = new WebClient())
            {
                byte[] respuestaBytes = cliente.UploadValues(url, "PUT", parametros);

                string respuestaString = System.Text.Encoding.UTF8.GetString(respuestaBytes);

                await DisplayAlert("Éxito", "El estudiante se ha actualizado correctamente.", "Aceptar");
                await Navigation.PushAsync(new vProducto());
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Ocurrió un error al actualizar el estudiante: {ex.Message}", "Aceptar");
        }
    }


    //metodo eliminar
    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {

        string codigo = txtCodigo.Text;

        try
        {
            HttpClient cliente = new HttpClient();
            HttpResponseMessage respuesta = await cliente.DeleteAsync($"http://localhost/appmovil/post.php?codigo={codigo}");
            respuesta.EnsureSuccessStatusCode();

            await DisplayAlert("Éxito", "El estudiante se ha eliminado correctamente.", "Aceptar");
            await Navigation.PushAsync(new vProducto());
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Ocurrió un error al eliminar el estudiante: {ex.Message}", "Aceptar");
        }

    }
}