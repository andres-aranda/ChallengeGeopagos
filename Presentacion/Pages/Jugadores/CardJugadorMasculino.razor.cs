using Dtos;
using Microsoft.AspNetCore.Components;

namespace Presentacion.Pages.Jugadores
{
	public partial class CardJugadorMasculino : ComponentBase
	{
		[Parameter]
		public bool mostrarComoLinea { get; set; } = false;
		[Parameter]
		public JugadorMasculinoDto jugadorMasculino { get; set; } = new JugadorMasculinoDto();
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
			OnClick.InvokeAsync(jugadorMasculino.Id);
		}
	}
}
