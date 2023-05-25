using Microsoft.Extensions.Logging;

namespace WebApiPortfolio.Middlewares
{

    public static class LoguearRespuestaHTTPMiddlewareExtentions 
    {
        //hago esto para no exponer la clase que estamos utilizando 'LoguearRespuestaHTTPMiddleware' en startup, y poder llamar a esta funcion directamente sin saber que clase estamos utilizando.
        public static IApplicationBuilder UseLoguearRespuestaHTTP(this IApplicationBuilder app) 
        {
            return app.UseMiddleware<LoguearRespuestaHTTPMiddleware>();
        }
    }


    public class LoguearRespuestaHTTPMiddleware
    {
        private readonly RequestDelegate siguiente;
        private readonly ILogger<LoguearRespuestaHTTPMiddleware> logger;

        public LoguearRespuestaHTTPMiddleware(RequestDelegate siguiente, ILogger<LoguearRespuestaHTTPMiddleware> logger)
        {
            this.siguiente = siguiente;
            this.logger = logger;
        }

        //Invoke o InvokeAsync
        public async Task InvokeAsync (HttpContext contexto) 
        {
            //toda esta parte del codigo se encontraba hardcoded directamente en startup, y la incorporamos de esta manera como una clase de middleware
            using (var ms = new MemoryStream())
            {
                var cuerpoOriginalRespuesta = contexto.Response.Body;
                contexto.Response.Body = ms;

                await siguiente(contexto);

                ms.Seek(0, SeekOrigin.Begin);
                string respuesta = new StreamReader(ms).ReadToEnd();
                ms.Seek(0, SeekOrigin.Begin);

                await ms.CopyToAsync(cuerpoOriginalRespuesta);
                contexto.Response.Body = cuerpoOriginalRespuesta;

                logger.LogInformation(respuesta);
            }
        }
    }
}
