using System.Net;

namespace hchavezS7Deber.Views;

public partial class vAgregarProd : ContentPage
{
	public vAgregarProd()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("codigo", txtCodigo.Text);
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("categoria", txtCategoria.Text);
            parametros.Add("proveedor", txtProveedor.Text);
            parametros.Add("precio", txtPrecio.Text);
            cliente.UploadValues("http://localhost/appmovil/post.php", "POST", parametros);
            Navigation.PushAsync(new vProducto());
        }
        catch (Exception ex)
        {
            DisplayAlert("Alerta", ex.Message, "Cerrar");
        }
    }
}