namespace ApiUpload.Modele;

public class FileModele
{
    public string FileName { get; set; }
    public IFormFile File { get; set; }
}

public class PostFile
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string FileGuid { get; set; }
    public string FileExtension { get; set; }
    public string FileName { get; set; }
    public string FileUrl { get; set; }
}

public class GetFile
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string FileUrl { get; set; }
}

public class PutFile
{
    public int Id { get; set; }
    public string Name { get; set; }
}