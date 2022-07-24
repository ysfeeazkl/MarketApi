using MarketProject.Shared.Utilities.Results.Abstract;
using MarketProject.Shared.Utilities.Results.ComplexTypes;
using MarketProject.Shared.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;

namespace MarketProject.Shared.Utilities.FileUploads
{
    public class FileUpload
    {
        private static string _currentDirectory = Environment.CurrentDirectory + "/wwwroot/Uploads/";

        public static IDataResult Upload(IFormFile file, string folderName)
        {
            var fileExists = CheckFileExists(file);
            if (fileExists.ResultStatus == ResultStatus.Error)
                return new DataResult(ResultStatus.Error, fileExists.Message);
            var type = Path.GetExtension(file.FileName);
            var typeValid = CheckFileTypeValid(type);
            if (typeValid.ResultStatus == ResultStatus.Error)
                return new DataResult(ResultStatus.Error, typeValid.Message);
            var randomName = Guid.NewGuid().ToString();
            CheckDirectoryExists(_currentDirectory);
            CreateImageFile(_currentDirectory + randomName + type, file);
            return new DataResult(ResultStatus.Success, (_currentDirectory + $"\\{folderName}\\" + randomName + type).Replace("\\", "/"), randomName + type + file);
        }

        public static IDataResult UploadAlternative(IFormFile file, string folderName, string? oldFilePath = "")
        {
            if (!string.IsNullOrEmpty(oldFilePath) && oldFilePath != null && File.Exists(oldFilePath))
                File.Delete(oldFilePath);
            if (!Directory.Exists(_currentDirectory + folderName))
                Directory.CreateDirectory(_currentDirectory + folderName);

            string fileName = Guid.NewGuid().ToString().Substring(0, 9) + "_" + file.FileName;
            var path = _currentDirectory + folderName + "/" + fileName;

            var type = Path.GetExtension(file.FileName);
            var typeValid = CheckFileTypeValid(type);
            if (typeValid.ResultStatus != ResultStatus.Success)
                return new DataResult(ResultStatus.Error, typeValid.Message);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return new DataResult(ResultStatus.Success, path);
        }
        public static IDataResult Update(IFormFile file, string folderName, string oldImageName)
        {
            var fileExists = CheckFileExists(file);
            if (fileExists.Message != null)
                return new DataResult(ResultStatus.Error, fileExists.Message);
            var type = Path.GetExtension(file.FileName);
            var typeValid = CheckFileTypeValid(type);
            var randomName = Guid.NewGuid().ToString();

            if (typeValid.Message != null)
                return new DataResult(ResultStatus.Error, typeValid.Message);

            DeleteOldImageFile((_currentDirectory + $"\\{folderName}" + oldImageName).Replace("/", "\\"));
            CheckDirectoryExists(_currentDirectory + $"\\{folderName}");
            CreateImageFile(_currentDirectory + $"\\{folderName}" + randomName + type, file);
            return new DataResult(ResultStatus.Success, (_currentDirectory + randomName + type).Replace("\\", "/"));
        }

        public static IDataResult Delete(string path)
        {
            DeleteOldImageFile((_currentDirectory + path).Replace("/", "\\"));
            return new DataResult(ResultStatus.Success, "Başarıyla silindi.");
        }

        private static IDataResult CheckFileExists(IFormFile file)
        {
            if (file != null && file.Length > 0)
                return new DataResult(ResultStatus.Success, "Mevcut.");
            return new DataResult(ResultStatus.Error, "Böyle bir dosya mevcut değil");
        }

        private static IDataResult CheckFileTypeValid(string type)
        {
            type = type.ToLower();
            if (type == ".jpeg" || type == ".png" || type == ".jpg")
                return new DataResult(ResultStatus.Success, "Geçerli dosya");
            return new DataResult(ResultStatus.Error, "Dosya tipi yanlış formatta.");
        }
        private static void CheckDirectoryExists(string directory)
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
        }
        private static void CreateImageFile(string directory, IFormFile file)
        {
            using (FileStream fs = File.Create(directory))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
        }

        private static void DeleteOldImageFile(string directory)
        {
            if (File.Exists(directory.Replace("/", "\\")))
                File.Delete(directory.Replace("/", "\\"));
        }
    }
}

