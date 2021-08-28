using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileHelper
{
    public class FileUpload
    {
        private const string DefaultImage = "default.jpg";

        private static string directory = Environment.CurrentDirectory + @"\wwwroot\";
        private static string path = Path.Combine(directory, "Images");

        public static IDataResult<string> Add(IFormFile formFile)
        {
            try
            {
                if (formFile == null)
                    return new SuccessDataResult<string>(Path.Combine(path, DefaultImage));

                string fileName = CreateNewFileName(formFile.FileName);
                CheckPathExists(path);
                CreateImageFileByName(formFile, fileName);

                return new SuccessDataResult<string>(Path.Combine(path, fileName));
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<string>(exception.Message);
            }
        }

        public static IDataResult<string> Update(IFormFile formFile, string oldImagePath)
        {
            if (formFile == null || !File.Exists($@"{path}\{oldImagePath}"))
                return new ErrorDataResult<string>("Dosya mevcut değil");

            DeleteOldImageFile(oldImagePath);
            CheckPathExists(path);

            string fileName = CreateNewFileName(formFile.FileName);
            CreateImageFileByName(formFile, fileName);
            return new SuccessDataResult<string>(Path.Combine(path, fileName));
        }

        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
                return new SuccessResult();
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }
        }

        public static string GetDefaultImagePath()
        {
            return Path.Combine(path, DefaultImage);
        }

        private static string CreateNewFileName(string fileName)
        {
            string[] file = fileName.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            string extension = file[1];
            var guid = Guid.NewGuid();

            string newFileName = $"{guid}.{extension}";
            return newFileName;
        }

        private static void CreateImageFileByName(IFormFile formFile, string fileName)
        {
            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                formFile.CopyTo(stream);
                stream.Flush();
            }
        }

        private static void CheckPathExists(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        private static void DeleteOldImageFile(string path)
        {
            File.Delete(path.Replace("/", "\\"));
        }
    }
}
