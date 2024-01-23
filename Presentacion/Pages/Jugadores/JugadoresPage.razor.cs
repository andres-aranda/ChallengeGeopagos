using Dtos;
using Microsoft.AspNetCore.Components;
using Presentacion.Servicios.Interfaces;
using Radzen;

namespace Presentacion.Pages.Jugadores
{

	public partial class JugadoresPage : ComponentBase
	{
		[Inject]
		IJugadoresService jugadoresService { get; set; }

		[Inject]
		DialogService dialogService { get; set; }

		private bool cargando = false;


		IEnumerable<JugadorFemeninoDto> jugadoresFemenino = new List<JugadorFemeninoDto>();
		IEnumerable<JugadorMasculinoDto> jugadoresMasculino = new List<JugadorMasculinoDto>();

		protected override async Task OnInitializedAsync()
		{
			cargando = true;
			jugadoresFemenino = await jugadoresService.ObtenerFemeninos();
			jugadoresMasculino = await jugadoresService.ObtenerMasculinos();
			cargando = false;

		}
		private void CardMasculinoClickbool(int id)
		{
			var jugador = jugadoresMasculino.FirstOrDefault(x => x.Id == id);


		}
		protected async Task AddFemenino()
		{
			var result = await dialogService.OpenAsync<AddJugadorFemenino>("Aguegar Jugadora");
			if (result != null)
			{
				jugadoresFemenino = await jugadoresService.ObtenerFemeninos();
				StateHasChanged();
			}

		}
		protected async Task AddMasculino()
		{
			var result = await dialogService.OpenAsync<AddJugadorMasculino>("Aguegar jugador");
			if (result != null)
			{
				jugadoresMasculino = await jugadoresService.ObtenerMasculinos();
				StateHasChanged();
			}

		}
	}
}
