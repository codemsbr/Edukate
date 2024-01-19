namespace Edukate.Helpers
{
    public static class FileExtraction
    {
        public static bool InValidType(this IFormFile file) => file.ContentType.Contains("image");

        public static async Task<string> SaveAsync(this IFormFile file,string path)
        {
            string fileName = Path.Combine(PathConstant.ImgPath,Guid.NewGuid()+file.Name);
            string filepath = Path.Combine(PathConstant.RootPath,fileName);

            using(Stream fs = new FileStream(filepath, FileMode.Create))
            {
                await file.CopyToAsync(fs);
            }
            return fileName;
        }
    }
}
