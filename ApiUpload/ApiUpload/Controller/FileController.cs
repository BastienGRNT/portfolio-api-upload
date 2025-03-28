using Microsoft.AspNetCore.Mvc;
using ApiUpload.Modele;
using ApiUpload.Service;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiUpload.Controller;

[ApiController]
[Route("/api/[controller]")]
public class FileController : ControllerBase
{
    [HttpPost("{type}")]
    public IActionResult Post(
        [FromRoute] string type, 
        [FromForm] FileModele file)
    {
        try
        {
            FileService.CreateFile(file, type);
            return Ok($"File of type '{type}' uploaded successfully.");
        }
        catch(Exception erreur)
        {
            return BadRequest($"Error uploading file of type '{type}': {erreur.Message}");
        }
    }

    [HttpGet("{type}")]
    public IActionResult Get(
        [FromRoute] string type)
    {
        try
        {
            var files = FileService.ReadFiles(type);
            return Ok(files.Count > 0 ? files : $"No files found for type '{type}'.");
        }
        catch(Exception erreur)
        {
            return BadRequest($"Error retrieving files of type '{type}': {erreur.Message}");
        }
    }
    
    [HttpPut("{type}")]
    public IActionResult Put(
        [FromRoute] string type, 
        [FromBody] PutFile file)
    {
        try
        {
            FileService.UpdateFile(file, type);
            return Ok($"File of type '{type}' updated successfully.");
        }
        catch(Exception erreur)
        {
            return BadRequest($"Error updating file of type '{type}': {erreur.Message}");
        }
    }
    
    [HttpDelete("{type}/{id}")]
    public IActionResult Delete(
        [FromRoute] string type, 
        [FromRoute] int id)
    {
        try
        {
            FileService.DeleteFile(id, type);
            return Ok($"File with ID {id} of type '{type}' deleted successfully.");
        }
        catch(Exception erreur)
        {
            return BadRequest($"Error deleting file with ID {id} of type '{type}': {erreur.Message}");
        }
    }
}
