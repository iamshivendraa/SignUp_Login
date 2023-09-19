using System.ComponentModel.DataAnnotations;

namespace ImageUpload.Models
{
    public class ImageModel
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public byte[]? ImageData { get; set; }
    }
}
