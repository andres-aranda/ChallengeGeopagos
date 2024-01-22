using Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Presentacion.Servicios;
using Presentacion.Servicios.Interfaces;
using Radzen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Presentacion.Pages.Jugadores
{
	public partial class AddJugadorFemenino : ComponentBase
	{

		#region Injects

		[Inject]
		public IJugadoresService JugadoresService { get; set; }

		[Inject]
		protected DialogService DialogService { get; set; }

		#endregion

		#region Propiedades
		protected JugadorFemeninoDto jugadorFemenino { get; set; }=		new JugadorFemeninoDto();

		#endregion

		protected override async Task OnInitializedAsync()
		{
			jugadorFemenino = new JugadorFemeninoDto();
		}
		protected async Task FormSubmit()
		{
			await JugadoresService.CrearFemenino(jugadorFemenino);
			DialogService.Close(jugadorFemenino);
		}

		#region Metodos de Apoyo
		protected async Task CancelButtonClick(MouseEventArgs args)
		{
			DialogService.Close(null);
		}
		#endregion

	}
}
