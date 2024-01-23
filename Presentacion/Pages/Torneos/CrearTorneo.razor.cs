using Dtos;
using Microsoft.AspNetCore.Components;
using Presentacion.Servicios.Interfaces;
using Radzen;

namespace Presentacion.Pages.Torneos
{
	public partial class CrearTorneo : ComponentBase
	{
		private bool torneoMasculino1 = false;
		private bool ErrorTupla = false;

		[Inject]
		public NavigationManager NavigationManager { get; set; }
		[Inject]
		public IJugadoresService JugadoresService { get; set; }
		[Inject]
		public ITorneosService TorneosService { get; set; }
		[Inject]
		public DialogService dialogService { get; set; }



		private List<JugadorMasculinoDto> jugadoresMasculinos { get; set; } = new List<JugadorMasculinoDto>();
		private List<JugadorFemeninoDto> jugadoresFemeninos { get; set; } = new List<JugadorFemeninoDto>();

		private List<JugadorMasculinoDto> jugadoresMasculinosSeleccionados { get; set; } = new List<JugadorMasculinoDto>();
		private List<JugadorFemeninoDto> jugadoresFemeninosSeleccionados { get; set; } = new List<JugadorFemeninoDto>();

		private bool torneoMasculino { get => torneoMasculino1; set => torneoMasculino1 = value; }
		private bool cargando = false;

		private async Task ObtenerJugadores()
		{
			cargando = true;
			var resulJugadoresMasculinos = await JugadoresService.ObtenerMasculinos();
			var resulJugadoresFemeninos = await JugadoresService.ObtenerFemeninos();

			if (resulJugadoresMasculinos != null)
				this.jugadoresMasculinos = resulJugadoresMasculinos.ToList();

			if (resulJugadoresFemeninos != null)
				this.jugadoresFemeninos = resulJugadoresFemeninos.ToList();

			cargando = false;
		}
		private void SeleccionarJugadorMasculino(int id)
		{
			var jugador = jugadoresMasculinos.FirstOrDefault(j => j.Id == id);
			if (jugador != null)
			{
				if (jugadoresMasculinosSeleccionados.Contains(jugador))
					jugadoresMasculinosSeleccionados.Remove(jugador);
				else
					jugadoresMasculinosSeleccionados.Add(jugador);
			}
		}
		private void SeleccionarJugadorFemenino(int id)
		{
			var jugador = jugadoresFemeninos.FirstOrDefault(j => j.Id == id);
			if (jugador != null)
			{
				if (jugadoresFemeninosSeleccionados.Contains(jugador))
					jugadoresFemeninosSeleccionados.Remove(jugador);
				else
					jugadoresFemeninosSeleccionados.Add(jugador);
			}
		}

		private async Task CrearNuevoTorneo()
		{
			if (!ValidarTupla())
				return;
			var result = true;
			if (torneoMasculino)
			{
				result = await TorneosService.CrearTorneoMasculino(jugadoresMasculinosSeleccionados);
			}
			else
			{
				result = await TorneosService.CrearTorneoFemenino(jugadoresFemeninosSeleccionados);
			}
			if (result)
			{
				await dialogService.Alert("Torneo creado correctamente");
				NavigationManager.NavigateTo("/Torneos");
			}
			else
			{
				await dialogService.Alert("No se pudo crear el torneo");
			}

		}
		private async Task CrearNuevoTorneoYFinalizar()
		{
			if (!ValidarTupla())
				return;

			TorneoDto? result = null;

			if (torneoMasculino)
			{
				result = await TorneosService.CrearTorneoMasculinoYFinalizar(jugadoresMasculinosSeleccionados);
			}
			else
			{
				result = await TorneosService.CrearTorneoFemeninoYFinalizar(jugadoresFemeninosSeleccionados);
			}
			if (result != null)
			{
				await dialogService.Alert($"Torneo creado y finalizado correctamente El ganador fue {result.Ganador}");
				NavigationManager.NavigateTo("/Torneos");
			}
			else
			{
				await dialogService.Alert("No se pudo crear el torneo");
			}

		}

		private bool ValidarTupla()
		{
			if (torneoMasculino)
			{
				if (jugadoresMasculinosSeleccionados.Count > 0 &&
					jugadoresMasculinosSeleccionados.Count % 2 == 0
					&& (jugadoresMasculinosSeleccionados.Count / 2) % 2 == 0)
				{
					ErrorTupla = false;
					return true;
				}
				else
				{
					ErrorTupla = true;
					return false;
				}
			}
			else
			{
				if (jugadoresFemeninosSeleccionados.Count > 0
					&& jugadoresFemeninosSeleccionados.Count % 2 == 0
					&& (jugadoresFemeninosSeleccionados.Count / 2) % 2 == 0)
				{
					ErrorTupla = false;
					return true;
				}
				else
				{
					ErrorTupla = true;
					return false;
				}
			}
		}

		override protected async Task OnInitializedAsync()
		{
			base.OnInitialized();
			await ObtenerJugadores();
		}
		private void OnChangeTipoTorneo()
		{
			jugadoresFemeninosSeleccionados.Clear();
			jugadoresMasculinosSeleccionados.Clear();
		}

	}
}
