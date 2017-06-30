using System;

namespace Pong
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                using (var game = new PongGame())
                    game.Run();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("Presione una tecla para continuar . . .");
                Console.ReadKey(true);
            }
        }
    }
#endif
}
