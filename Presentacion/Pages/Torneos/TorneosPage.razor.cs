using Dtos;
using Microsoft.AspNetCore.Components;
using Presentacion.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Presentacion.Pages.Torneos
{
	public partial class TorneosPage : ComponentBase
	{
		[Inject] 
		private ITorneosService TorneosService { get; set; }
		[Inject] 
		private NavigationManager NavigationManager { get; set; }

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
	}
}
