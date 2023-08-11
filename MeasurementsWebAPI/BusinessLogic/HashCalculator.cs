using MeasurementsWebAPI.BusinessLogic.Interfaces;
using System.Runtime.InteropServices;

namespace MeasurementsWebAPI.BusinessLogic
{
    public class HashCalculator : IDisposable
    {
        private bool disposed = false;

        public HashCalculator()
        {

        }

        [DllImport("MeasurementsDLL", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool InitializeDLL(char startChar, int length, out char hashChar, out int hashLength);

        
        public void CalculateATMHash(string description)
        {
            var startChar = description[0];
            var length = 3;
            char hashChar;
            int hashLength;

            bool result = InitializeDLL(startChar, length, out hashChar, out hashLength);

            if (result)
            {
                Console.WriteLine(hashChar); 
                Console.WriteLine(hashLength);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {

                }
                disposed = true;
            }
        }

        ~HashCalculator() 
        { 
            Dispose(false);
        }
    }
}
