using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Byte_Hunter_3D
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (StartUp game = new StartUp())
            {
                game.Run();
            }
        }
    }
#endif
}
