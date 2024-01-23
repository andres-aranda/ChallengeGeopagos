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
	public partial class AddJugadorMasculino : ComponentBase
	{

		#region Injects

		[Inject]
		public IJugadoresService JugadoresService { get; set; }

		[Inject]
		protected DialogService DialogService { get; set; }

		#endregion

		#region Propiedades
		protected JugadorMasculinoDto jugadorMasculino { get; set; }=		new JugadorMasculinoDto();

		#endregion

		protected override async Task OnInitializedAsync()
		{
			jugadorMasculino = new JugadorMasculinoDto();
		}
		protected async Task FormSubmit()
		{
			await JugadoresService.CrearMasculino(jugadorMasculino);
			DialogService.Close(jugadorMasculino);
		}

		#region Metodos de Apoyo
		protected async Task CancelButtonClick(MouseEventArgs args)
		{
			DialogService.Close(null);
		}
		#endregion
		void OnChange(string value)
		{
			if (value.Length == 1)
				jugadorMasculino.Nombre.Trim();
		}
	}
}
