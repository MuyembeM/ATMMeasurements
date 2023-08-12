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
        public static extern bool CalculateAtmHash(in byte startChar, int length, out byte hashChar, out int hashLength);
            
        public string GetHash(string description)
        {
            try
            {
                // Convert string to byte array using UTF-8 encoding
                byte[] byteArray = Encoding.UTF8.GetBytes(description);
                // Declare 100-byte array
                byte[] hash = new byte[100];

                var hashLength = 0;

                if (CalculateAtmHash(in byteArray[0], byteArray.Length, out hash[0], out hashLength))
                {
                    // Copy populated elements in hash to new byte array
                    var filledArray = new byte[hashLength];
                    Array.Copy(hash, 0, filledArray, 0, hashLength);

                    // Convert byte array back to string using UTF-8 encoding
                    var utfString = Encoding.UTF8.GetString(filledArray);
                    return utfString;
                }
                
            }
            catch (Exception)
            {

                throw;
            }

            return null;
            
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
