using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Common
{
    public class ImageBox
    {
        private static string imageFolderPath = "\\images\\";
        private static string imageNotFound = "\\images\\imagenotfound.jpg";
        public static string ImageObjectPath(string objectName,int id,int? imageOrder, IHostingEnvironment _hostingEnvironment)
        {
            string imagePath;
            if (imageOrder != null)
            {
                imagePath = imageFolderPath + objectName + "\\" + id + "_" + imageOrder + ".jpg";
            }
            else
            {
                imagePath= imageFolderPath + objectName + "\\" + id + ".jpg";
            }
            var imageSrc = File.Exists(_hostingEnvironment.WebRootPath+ imagePath)
                               ? imagePath : imageNotFound;

            return imageSrc;
        }
    }
}
 