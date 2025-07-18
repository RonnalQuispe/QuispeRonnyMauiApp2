using System.Threading.Tasks;
using MauiApp2.Repositories;

namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        private FilesRepository _filesRepository;

        public MainPage()
        {
            _filesRepository = new FilesRepository();
            InitializeComponent();
            CargarInformacionArchivo();
        }

        private async Task CargarInformacionArchivo()
        {
            
            string texto = await _filesRepository.DevuelveInformacionArchivoAsync();
            LabelArchivo.Text = texto;
        }

        private async void BtnGuardarArchivo_Clicked(object sender, EventArgs e)
        {
            string texto = TxtArchivo.Text;
            await _filesRepository.GenerarArchivoAsync(texto);
            await CargarInformacionArchivo();
        }

    }
}
