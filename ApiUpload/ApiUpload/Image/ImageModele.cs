namespace ApiUpload.Image;

public class PostImageModele
{
    public string ImageName { get; set; }
    public IFormFile ImageFile { get; set; }
}

public class ImageModele
{
    public int Id { get; set; }
    public string TechnologyName { get; set; }
    public string FileGuid { get; set; }
    public string FileExtension { get; set; }
    public string FileName { get; set; }
    public string TechnologieUrl { get; set; }
}