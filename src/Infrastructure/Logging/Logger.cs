using System;

namespace Infrastructure.Logging
{
    public static class Logger
    {
        // Bandera que permite habilitar o deshabilitar el logging globalmente.
        // Si está en false, los mensajes no se registran.
        public static bool Enabled = true;

        // Método para registrar un mensaje en la consola.
        public static void Log(string message)
        {
            if (!Enabled) return;
            Console.WriteLine("[LOG] " + DateTime.Now + " - " + message);
        }

        // Método auxiliar que ejecuta una acción dentro de un bloque try/catch.
        public static void Try(Action a)
        {
            try { a(); } catch { }
        }
    }
}