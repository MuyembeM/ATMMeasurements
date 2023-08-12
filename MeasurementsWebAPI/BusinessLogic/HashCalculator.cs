using MeasurementsWebAPI.BusinessLogic.Interfaces;
using System.Runtime.InteropServices;
using System.Text.Unicode;
using System.Text;

namespace MeasurementsWebAPI.BusinessLogic
{
    public class HashCalculator : IDisposable
    {
        private bool disposed = false;

        public HashCalculator()
        {

        }

        [DllImport("MeasurementsDLL", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CalculateAtmHash(in char startChar, int length, out char hashChar, out int hashLength);
            
        public string GetHash(string description)
        {
            // Convert string to byte array using UTF-8 encoding
            byte[] byteArray = Encoding.UTF8.GetBytes(description);
            // Declare 100-byte array
            byte[] hash = new byte[100];

            var startChar = (char)byteArray[0];
            var length = byteArray.Length;
            var hashChar = (char)hash[0];
            var hashLength = 0;

            //CalculateAtmHash(in startChar, length, out hashChar, out hashLength);

            return hash.ToString();
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
