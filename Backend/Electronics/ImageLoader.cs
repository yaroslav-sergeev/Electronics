using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Electronics
{
    public static class ImageLoader
    {
        public static async Task<byte[]> GetBytesAsync(string fileName)
        {
            try
            {
                string path = Path.Combine(Environment.CurrentDirectory, "wwwroot/images", $@"\{fileName}");

                byte[] image = await File.ReadAllBytesAsync(path);
                return image;
            }
            catch (Exception)
            {
                return Array.Empty<byte>();
            }
                       
        }
    }
}
