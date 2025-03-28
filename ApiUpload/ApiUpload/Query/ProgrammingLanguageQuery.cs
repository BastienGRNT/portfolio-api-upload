namespace ApiUpload.Query;

public class ProgrammingLanguageQuery
{
    public static string CreateProgrammingLanguage = """
                                                     INSERT INTO ProgrammingLanguage (programmingLanguageName, fileGuid, fileExtension, fileName, programmingLanguageUrl) 
                                                     VALUES (@name, @fileGuid, @fileExtension, @fileName, @fileUrl);
                                                     """;
    
    public static string ReadProgrammingLanguage = "SELECT id, programmingLanguageName, programmingLanguageUrl FROM ProgrammingLanguage;";
    
    public static string DeleteProgrammingLanguage = "DELETE FROM ProgrammingLanguage WHERE id = @id;";
    
    public static string UpdateProgrammingLanguage = """
                                       UPDATE ProgrammingLanguage SET 
                                       programmingLanguageName = @name
                                       WHERE id = @Id;
                                       """;
    
    public static string TableProgrammingLanguage = """
                                                    CREATE TABLE IF NOT EXISTS ProgrammingLanguage (
                                                      id SERIAL PRIMARY KEY,
                                                      programmingLanguageName VARCHAR(255),
                                                      fileGuid VARCHAR(255),
                                                      fileExtension VARCHAR(50),
                                                      fileName VARCHAR(255),
                                                      programmingLanguageUrl VARCHAR(255)
                                                    );
                                                    """;
}