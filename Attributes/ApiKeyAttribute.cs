﻿using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ControlBiblioteca
{
    // Esta clase define un atributo personalizado para la validación de una Api Key.
    // Puede aplicarse a clases y métodos, y actúa como un filtro de acción asincrónico.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        // Método que se ejecuta antes de la ejecución de una acción (método del controlador) en ASP.NET Core.
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Intenta obtener el valor del encabezado "ApiKey" de la solicitud HTTP.
            if (!context.HttpContext.Request.Headers.TryGetValue("ApiKey", out var extractedApiKey))
            {
                // Si no se encuentra el encabezado "ApiKey", se establece el resultado de la solicitud
                // con un código de estado 401 (No autorizado) y un mensaje de error.
                context.Result = new ContentResult()
                {
                    StatusCode = 401, // Código de estado HTTP 401: No autorizado
                    Content = "No se envió el Api Key" // Mensaje de error
                };
                return; // Termina la ejecución del método, no se continúa con la acción del controlador
            }

            // Verifica si el valor del encabezado "ApiKey" coincide con el valor esperado ("Hola123").
            if (!extractedApiKey.Equals("Hola123"))
            {
                // Si el ApiKey es incorrecto, se establece el resultado de la solicitud
                // con un código de estado 401 (No autorizado) y un mensaje de error.
                context.Result = new ContentResult()
                {
                    StatusCode = 401, // Código de estado HTTP 401: No autorizado
                    Content = "Api Key inválido" // Mensaje de error
                };
                return; // Termina la ejecución del método, no se continúa con la acción del controlador
            }

            // Si el ApiKey es válido, continúa con la ejecución de la acción del controlador.
            await next();
        }
    }
}