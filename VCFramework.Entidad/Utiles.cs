using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;
using System.IO;

namespace VCFramework.Entidad
{
    public class Utiles
    {
        public static string GetMd5Hash(string input)
        {
            StringBuilder sBuilder = new StringBuilder();
            using (MD5 md5Hash = MD5.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        public static bool VerifyMd5Hash(string input, string hash)
        {
            // Hash the input.
            using (MD5 md5Hash = MD5.Create())
            {
                string hashOfInput = GetMd5Hash(input);

                // Create a StringComparer an compare the hashes.
                StringComparer comparer = StringComparer.OrdinalIgnoreCase;

                if (0 == comparer.Compare(hashOfInput, hash))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static int DiferenciaDias(DateTime fechaIni, DateTime fechaTer)
        {
            //TimeSpan ts = fechaTer - fechaIni;
            //int differenceInDays = ts.Days;

            //return differenceInDays;

            DateTime desde = fechaIni;
            DateTime hasta = fechaTer;
            int dias_habiles = 0;

            while (desde < hasta)
            {
                int numero_dia = Convert.ToInt16(desde.DayOfWeek.ToString("d"));
                if (numero_dia == 1 || numero_dia == 2 || numero_dia == 3 || numero_dia == 4 || numero_dia == 5)
                {
                    dias_habiles++;
                }
                desde = desde.AddDays(1);
            }
            return dias_habiles;
        }
    }
}
