using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorPrototype.Utility
{
    public static class CSVFileUtil
    {
        /// <summary>
        /// Creates a new csv file with the given file name and contents in the current app location
        /// under the app directory under a folder called CSV.
        /// </summary>
        /// <typeparam name="T">The type of the collection</typeparam>
        /// <param name="fileName">The name of the file you want saved minus the extension.</param>
        /// <param name="collection">A collection of enumerable content</param>
        /// <returns>A byte array containing the csv file contents.</returns>
        public static byte[] CreateCSVFile<T>(string fileName, IEnumerable<T> collection)
        {
            string csvContents = string.Join(",", collection);
            //File.WriteAllText(fileName + ".csv", csvContents);

            byte[] bytes = null;
            string path = AppDomain.CurrentDomain.BaseDirectory;

            if(!Directory.Exists(Path.Combine(path,"CSV")))
            {
                Directory.CreateDirectory(Path.Combine(path, "CSV"));
            }

            using (var fs = new FileStream(Path.Combine(path,"CSV", fileName + ".csv"), FileMode.Create, FileAccess.ReadWrite))
            {
                using (var ms = new MemoryStream())
                {
                    TextWriter tw = new StreamWriter(ms);
                    tw.Write(csvContents);
                    tw.Flush();
                    ms.Position = 0;
                    bytes = ms.ToArray();
                    //or save to disk using FileStream (fs)
                    ms.WriteTo(fs);
                }
            }
            return bytes;
        }


        /// <summary>
        /// Creates a new csv file with the given file name and contents in the current app location
        /// under the app directory under a folder called CSV.
        /// </summary>
        /// <typeparam name="T">The type of the collection</typeparam>
        /// <param name="fileName">The name of the file you want saved minus the extension.</param>
        /// <param name="collection">A collection of enumerable content</param>
        /// <returns>A byte array containing the csv file contents.</returns>
        public static async Task<byte[]> CreateCSVFileAsync<T>(string fileName, IEnumerable<T> collection)
        {
            string csvContents = string.Join(",", collection);
            //File.WriteAllText(fileName + ".csv", csvContents);

            byte[] bytes = null;
            string path = AppDomain.CurrentDomain.BaseDirectory;

            if (!Directory.Exists(Path.Combine(path, "CSV")))
            {
                Directory.CreateDirectory(Path.Combine(path, "CSV"));
            }

            using (var fs = new FileStream(Path.Combine(path, "CSV", fileName + ".csv"), FileMode.Create, FileAccess.ReadWrite))
            {
                using (var ms = new MemoryStream())
                {
                    TextWriter tw = new StreamWriter(ms);
                    await tw.WriteAsync(csvContents);
                    await tw.FlushAsync();
                    ms.Position = 0;
                    bytes = ms.ToArray();
                    //or save to disk using FileStream (fs)
                    ms.WriteTo(fs);
                }
            }
            return bytes;
        }

        /// <summary>
        /// A convenient wrapper method to convert a byte array back into a string
        /// </summary>
        /// <param name="array"></param>
        /// <returns>A string array</returns>
        public static string GetStringFromBytes(byte[] array)
        {
            return Encoding.Default.GetString(array);
        }
    }
}
