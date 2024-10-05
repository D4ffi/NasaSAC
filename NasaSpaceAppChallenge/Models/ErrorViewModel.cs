namespace NasaSpaceAppChallenge.Models;

/*
 * Esta clase es un modelo de datos que se utiliza para mostrar errores.
 * Contiene una propiedad que almacena el identificador de la solicitud.
 * La propiedad ShowRequestId se utiliza para determinar si se debe mostrar el identificador de la solicitud.
 */
public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}