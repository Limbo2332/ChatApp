namespace ChatApp.Common.Helpers
{
    public static class FileNameGeneratorHelper
    {
        public static string GenerateUniqueFileName(string fileName)
        {
            var newFileName = Path.GetFileName(fileName);
            var extension = Path.GetExtension(newFileName);
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(newFileName);
            var fileGuid = Guid.NewGuid();

            return $"{fileNameWithoutExtension}___{fileGuid}{extension}";
        }
    }
}
