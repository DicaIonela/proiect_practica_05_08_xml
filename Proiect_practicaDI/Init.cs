using System;
using NivelStocareDate;
using LibrarieClase;
namespace Proiect_practicaDI
{
    public static class Init
    {
        public static void Initialize(out Utilizator[] utilizatori)
        {
            // Initialize objects from app.config
            utilizatori = ConfigHelper.GetUtilizatori();
        }

        public static void InitializeTB(out TestBench[] testBenchuri)
        {
            // Initialize objects from app.config
            testBenchuri=ConfigHelper.Gettb();
        }
    }
}
