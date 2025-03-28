namespace ApiUpload.Query;

public class ToolQuery
{
    public static string CreateTool = """
                                            INSERT INTO Tool (toolName, fileGuid, fileExtension, fileName, toolUrl) 
                                            VALUES (@name, @fileGuid, @fileExtension, @fileName, @fileUrl);
                                            """;
    
    public static string ReadTool = "SELECT id, toolName, toolUrl FROM Tool;";
    
    public static string DeleteTool = "DELETE FROM Tool WHERE id = @id;";
    
    public static string UpdateTool = """
                                       UPDATE Tool SET 
                                       toolName = @name
                                       WHERE id = @Id;
                                       """;
    
    public static string TableTool = """
                                     CREATE TABLE IF NOT EXISTS Tool (
                                       id SERIAL PRIMARY KEY,
                                       toolName VARCHAR(255),
                                       fileGuid VARCHAR(255),
                                       fileExtension VARCHAR(50),
                                       fileName VARCHAR(255),
                                       toolUrl VARCHAR(255)
                                     );
                                     """;
}