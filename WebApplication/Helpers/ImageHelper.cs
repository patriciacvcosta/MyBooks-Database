using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Helpers
{
    public class ImageHelper
    {
        public static byte[] ConvertImageToByteArray(IFormFile bookImage)
        {
            if (bookImage == null)
            {
                return null;
            }

            byte[] imageBytes;
            using (var reader = bookImage.OpenReadStream())
            {
                imageBytes = new byte[reader.Length];
                for (int i = 0; i < reader.Length; i++)
                {
                    imageBytes[i] = (byte)reader.ReadByte();
                }
            }

            return imageBytes;
        }
    }
}
