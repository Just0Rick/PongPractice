using System;
using System.IO;

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
                using (TextWriter fichero = new StreamWriter(new FileStream("Error log.txt", FileMode.Create)))
                {
                    fichero.WriteLine("ERROR: " + Environment.NewLine + ex.Message);
                }

            }
        }
    }
#endif
}
