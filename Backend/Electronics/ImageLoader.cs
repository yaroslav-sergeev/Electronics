﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Electronics
{
    public static class ImageLoader
    {
        private static async Task<byte[]> GetBytesAsync(string fileName)
        {
            try
            {
                string path = Path.Combine(Environment.CurrentDirectory, $@"wwwroot\images\{fileName}.png");

                byte[] image = await File.ReadAllBytesAsync(path);
                return image;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException();
                //return Array.Empty<byte>();
            }                      
        }

        public static async Task<string> CreateBase64Image(string fileName)
        {
             if (string.IsNullOrEmpty(fileName)) throw new ArgumentNullException();

            try
            {
                using (MemoryStream ms = new MemoryStream(await GetBytesAsync(fileName)))
                {
                    /* Create a new image, saved as a scaled version of the original */
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
            catch(Exception e)
            {
                throw;
            }
            
        }
    }
}
