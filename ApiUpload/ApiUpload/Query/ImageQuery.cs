namespace ApiUpload.Query;

public class ImageQuery
{
    public static string CreateImage = """
                                       INSERT INTO Image (imageName, fileGuid, fileExtension, fileName, imageUrl) 
                                       VALUES (@Name, @fileGuid, @fileExtension, @fileName, @fileUrl);
                                       """;

    public static string ReadImage = "SELECT id, imageName, imageUrl FROM Image;";
    
    public static string DeleteImage = "DELETE FROM Image WHERE id = @Id;";

    public static string UpdateImage = """
                                       UPDATE Image SET 
                                       imageName = @name
                                       WHERE id = @Id;
                                       """;
    
    public static string TableImage = """
                                      CREATE TABLE IF NOT EXISTS Image (
                                        id SERIAL PRIMARY KEY,
                                        imageName VARCHAR(255),
                                        fileGuid VARCHAR(255),
                                        fileExtension VARCHAR(50),
                                        fileName VARCHAR(255),
                                        imageUrl VARCHAR(255)
                                      );
                                      """;
}