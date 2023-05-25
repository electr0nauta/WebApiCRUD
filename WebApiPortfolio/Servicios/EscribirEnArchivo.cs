namespace WebApiPortfolio.Servicios
{
    public class EscribirEnArchivo : IHostedService
    {
        private readonly IWebHostEnvironment env;
        private readonly string nombreArchivo = "Archivo1.txt";
        private Timer timer;

        public EscribirEnArchivo(IWebHostEnvironment env)
        {
            this.env = env;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(Dowork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));//hago que escriba en el log archivo1 de manera recurrente cada 5s
            Escribir("Proceso iniciado");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            timer.Dispose();
            Escribir("Proceso Finalizado");
            return Task.CompletedTask;
        }

        private void Dowork(object state) 
        {
            Escribir("Proceso en ejecución :" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));//va a ser lo que se escribe en el log, en este caso un string mas la fecha y el tiempo.
        }

        private void Escribir(string mensaje) 
        {
            var ruta = $@"{env.ContentRootPath}\wwwroot\{nombreArchivo}";
            using(StreamWriter writer = new StreamWriter(ruta, append: true)) 
            {
                writer.WriteLine(mensaje);
            }
        }
    }
}
