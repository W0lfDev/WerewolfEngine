using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werewolf.Engine.EngineManagement
{
    public class AssetCoder
    {
        public static bool IsEncoded()
        {
            if (File.ReadAllText(EngineInstance.MainDirectory + @"\encoded.bool").ToLower() == "true")
            {
                return true;
            }

            return false;
        }

        public static async Task Encode()
        {
            string[] allFiles = Directory.GetFiles(EngineInstance.MainDirectory, "*", SearchOption.AllDirectories);

            foreach (string filePath in allFiles)
            {
                byte[] fileBytes = await File.ReadAllBytesAsync(filePath);
                string encodedFile = Base64Encode(fileBytes);

                await File.WriteAllTextAsync(filePath, encodedFile);
            }

            await File.WriteAllTextAsync(EngineInstance.MainDirectory + @"\encoded.bool", "true");
        }

        public static async Task Decode()
        {
            string[] allFiles = Directory.GetFiles(EngineInstance.MainDirectory, "*", SearchOption.AllDirectories);

            foreach (string filePath in allFiles)
            {
                string fileContents = await File.ReadAllTextAsync(filePath);
                string decodedFile = Base64Decode(fileContents);

                await File.WriteAllTextAsync(filePath, decodedFile);
            }
        }

        private static string Base64Encode(byte[] data)
        {
            return Convert.ToBase64String(data);
        }

        private static string Base64Decode(string encoded)
        {
            try
            {
                byte[] data = Convert.FromBase64String(encoded);
                return Encoding.UTF8.GetString(data);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Base64 string.");
                return string.Empty;
            }
        }
    }
}
