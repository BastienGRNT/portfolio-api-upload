namespace ApiUpload.Query;

public class TechnologyQuery
{
    public static string CreateTechnology = """
                                            INSERT INTO Technology (technologyName, fileGuid, fileExtension, fileName, technologyUrl) 
                                            VALUES (@name, @fileGuid, @fileExtension, @fileName, @fileUrl);
                                            """;
    
    public static string ReadTechnology = "SELECT id, technologyName, technologyUrl FROM Technology;";
    
    public static string DeleteTechnology = "DELETE FROM Technology WHERE id = @id;";
    
    public static string UpdateTechnology = """
                                           UPDATE Technology SET 
                                           technologyName = @name
                                           WHERE id = @Id;
                                           """;
    
    public static string TableTechnology = """
                                           CREATE TABLE IF NOT EXISTS Technology (
                                             id SERIAL PRIMARY KEY,
                                             technologyName VARCHAR(255),
                                             fileGuid VARCHAR(255),
                                             fileExtension VARCHAR(50),
                                             fileName VARCHAR(255),
                                             technologyUrl VARCHAR(255)
                                           );
                                           """;

}