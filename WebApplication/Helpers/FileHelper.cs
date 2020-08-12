using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Helpers
{
    public class FileHelper
    {
        public static byte[] ConvertFileToByteArray(IFormFile file)
        {
            if (file == null)
            {
                return null;
            }

            byte[] fileBytes;
            using (var reader = file.OpenReadStream())
            {
                fileBytes = new byte[reader.Length];
                for (int i = 0; i < reader.Length; i++)
                {
                    fileBytes[i] = (byte)reader.ReadByte();
                }
            }

            return fileBytes;
        }
    }
}
