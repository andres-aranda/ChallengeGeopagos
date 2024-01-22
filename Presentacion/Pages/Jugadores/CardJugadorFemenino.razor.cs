using Dtos;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Presentacion.Pages.Jugadores
{
	public partial class CardJugadorFemenino : ComponentBase
	{
		[Parameter]
		public JugadorFemeninoDto jugadorFemenino { get; set; } = new JugadorFemeninoDto();

		[Parameter]
		public bool mostrarComoLinea { get; set; } = false;

		[Parameter]
		public bool permitirSeleccion { get; set; } = false;

		public bool seleccionado { get; set; } = false;

		private string backcolor { get; set; }

		[Parameter]
		public EventCallback<int> OnClick { get; set; }

		public void OnClickHandler()
		{
			if (!permitirSeleccion)
				return;

			if (seleccionado)
			{
				seleccionado = false;
				backcolor = "";
			}
			else
			{
				seleccionado = true;
				backcolor = "#FFF9C4";
			}
			OnClick.InvokeAsync(jugadorFemenino.Id);
		}

	}
}
