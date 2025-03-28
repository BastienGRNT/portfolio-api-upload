using ApiUpload.Modele;
using ApiUpload.Query;
using Npgsql;

namespace ApiUpload.Service;

public class FileService
{
    //Function use to upload the file
    public static void UploadFile(FileModele file, string path)
    {
        //Create the directory if is not exist
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        
        string fullPath = path + "/" + file.FileName;

        //Upload Image
        using (var fileStream = new FileStream(fullPath, FileMode.Create))
        {
            file.File.CopyTo(fileStream);
        }
    }

    //Function used to post file
    public static void CreateFile(FileModele file, string type)
    {
        //Inititaliser les valeurs Pour créer l'objet image
        string guid= Guid.NewGuid().ToString();
        string extenssion = Path.GetExtension(file.File.FileName);
        string fullName = guid + extenssion;
        
        var image = new PostFile
        {
            Name = file.FileName,
            FileGuid = guid,
            FileExtension = extenssion,
            FileName = fullName,
            FileUrl = DotNetEnv.Env.GetString("URL") + fullName,
        };
        
        //Find Whats File we want to Upload and Create
        string tableQuery = "";
        string createQuery = "";
        string path = "";
            
        switch (type)
        {
            case "ProgrammingLanguage":
                tableQuery = ProgrammingLanguageQuery.TableProgrammingLanguage;
                createQuery = ProgrammingLanguageQuery.CreateProgrammingLanguage;
                path = DotNetEnv.Env.GetString("PROGRAMMINGLANGUAGE_PATH");
                break;
            case "Technology":
                tableQuery = TechnologyQuery.TableTechnology;
                createQuery = TechnologyQuery.CreateTechnology;
                path = DotNetEnv.Env.GetString("TECHNOLOGY_PATH");
                break;
            case "Tool":
                tableQuery = ToolQuery.TableTool;
                createQuery = ToolQuery.CreateTool;
                path = DotNetEnv.Env.GetString("TOOL_PATH");
                break;
            case "Image":
                tableQuery = ImageQuery.TableImage;
                createQuery = ImageQuery.CreateImage;
                path = DotNetEnv.Env.GetString("IMAGE_PATH");
                break;
        }
        
        //Call Function to upload the file
        UploadFile(file, path);
        
        
        // Connect the SQL Database
        using (var connection = _Sql.Connection.GetConnection())
        {
            //Open the connection if it closed
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            
            //Create SQL Table if not existe
            using (var commande = new NpgsqlCommand(tableQuery, connection))
            {
                commande.ExecuteNonQuery();
            }
            
            //Execute Create Commande
            using (var commande = new NpgsqlCommand(createQuery, connection))
            {
                commande.Parameters.AddWithValue("@name", image.Name);
                commande.Parameters.AddWithValue("@FileGuid", image.FileGuid);
                commande.Parameters.AddWithValue("@FileExtension", image.FileExtension);
                commande.Parameters.AddWithValue("@FileName", image.FileName);
                commande.Parameters.AddWithValue("@FileUrl", image.FileUrl);
                
                commande.ExecuteNonQuery();
            }
        }
    }

    //Function used to get files
    public static List<GetFile> ReadFiles(string type)
    {
        var files = new List<GetFile>();
        
        //Find Whats File we want to Upload and Create
        string readQuery = "";
            
        switch (type)
        {
            case "ProgrammingLanguage":
                readQuery = ProgrammingLanguageQuery.ReadProgrammingLanguage;
                break;
            case "Technology":
                readQuery = TechnologyQuery.ReadTechnology;
                break;
            case "Tool":
                readQuery = ToolQuery.ReadTool;
                break;
            case "Image":
                readQuery = ImageQuery.ReadImage;
                break;
        }

        // Connect the SQL Database
        using (var connection = _Sql.Connection.GetConnection())
        {
            //Open the connection if it closed
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            
            using (var commande = new NpgsqlCommand(readQuery, connection))
            using (var reader = commande.ExecuteReader())
            {
                while (reader.Read())
                {
                    files.Add(new GetFile
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        FileUrl = reader.GetString(2),
                    });
                }
            }
        }
        return files;
    }

    public static void DeleteFile(int id, string type)
    {
        string deleteQuery = "";
            
        switch (type)
        {
            case "ProgrammingLanguage":
                deleteQuery = ProgrammingLanguageQuery.DeleteProgrammingLanguage;
                break;
            case "Technology":
                deleteQuery = TechnologyQuery.DeleteTechnology;
                break;
            case "Tool":
                deleteQuery = ToolQuery.DeleteTool;
                break;
            case "Image":
                deleteQuery = ImageQuery.DeleteImage;
                break;
        }

        // Connect the SQL Database
        using (var connection = _Sql.Connection.GetConnection())
        {
            //Open the connection if it closed
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            using (var commande = new NpgsqlCommand(deleteQuery, connection))
            {
                commande.Parameters.AddWithValue("@id", id);
                
                commande.ExecuteNonQuery();
            }
            
        }
    }

    public static void UpdateFile(PutFile file, string type)
    {
        string updateQuery = "";
            
        switch (type)
        {
            case "ProgrammingLanguage":
                updateQuery = ProgrammingLanguageQuery.UpdateProgrammingLanguage;
                break;
            case "Technology":
                updateQuery = TechnologyQuery.UpdateTechnology;
                break;
            case "Tool":
                updateQuery = ToolQuery.UpdateTool;
                break;
            case "Image":
                updateQuery = ImageQuery.UpdateImage;
                break;
        }

        // Connect the SQL Database
        using (var connection = _Sql.Connection.GetConnection())
        {
            //Open the connection if it closed
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            using (var commande = new NpgsqlCommand(updateQuery, connection))
            {
                commande.Parameters.AddWithValue("@id", file.Id);
                commande.Parameters.AddWithValue("@name", file.Name);

                commande.ExecuteNonQuery();
            }
        }
    }
}