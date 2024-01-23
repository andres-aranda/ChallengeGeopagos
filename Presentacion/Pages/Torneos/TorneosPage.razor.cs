using Dtos;
using Microsoft.AspNetCore.Components;
using Presentacion.Servicios.Interfaces;
using Radzen;

namespace Presentacion.Pages.Torneos
{
	public partial class TorneosPage : ComponentBase
	{
		[Inject]
		private ITorneosService TorneosService { get; set; }
		[Inject]
		private NavigationManager NavigationManager { get; set; }
		[Inject]
		private DialogService DialogService { get; set; }

		private List<TorneoDto> Torneos { get; set; } = new List<TorneoDto>();

		private bool cargando = false;

		protected override async Task OnInitializedAsync()
		{
			cargando = true;
			Torneos = (await TorneosService.ObtenerTodos()).ToList();
			cargando = false;
		}
		private void AddTorneo()
		{
			NavigationManager.NavigateTo($"/CrearTorneo");
		}
		private async void BorrarTorneo(int id)
		{
			var result = await TorneosService.BorrarTorneo(id);
			if (result)
			{
				await DialogService.Alert($"Se elimino el torneo {id}", "Borrado");

				Torneos = (await TorneosService.ObtenerTodos()).ToList();
			}
			else
			{
				await DialogService.Alert($"No se pudo eliminar el torneo {id}", "Error");
			}
		}
		private async void FinalizarTorneo(int id)
		{
			var result = await TorneosService.FinalizarTorneo(id);
			if (result != null)
			{
				await DialogService.Alert($"El ganador es {result.Ganador}", "El torneo finalizo Correctamente");

				Torneos = (await TorneosService.ObtenerTodos()).ToList();
			}
			else
			{
				await DialogService.Alert($"No se pudo eliminar el torneo {id}", "Error");
			}
		}

	}
}
