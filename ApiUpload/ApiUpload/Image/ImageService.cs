using ApiUpload._Sql;
using System.IO;

namespace ApiUpload.Image;

public class ImageService
{
    public void PostImage(PostImageModele postImage)
    {
        //Inititaliser les valeurs Pour créer l'objet image
        string guid= Guid.NewGuid().ToString();
        string extenssion = Path.GetExtension(postImage.ImageFile.FileName);
        
        var image = new ImageModele
        {
            TechnologyName = postImage.ImageName,
            FileGuid = guid,
            FileExtension = extenssion,
            FileName = guid + extenssion,
            TechnologieUrl = 
        };
        
        
        // Connect the SQL Database
        using (var connection = _Sql.Connection.GetConnection())
        {
            //Open the connection if it closed
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            
            
            
            
            
        }
    }
}