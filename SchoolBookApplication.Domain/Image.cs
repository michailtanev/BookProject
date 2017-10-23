namespace SchoolBookApplication.Domain
{
    using System.ComponentModel.DataAnnotations;

    public class Image
    {
        [Key]

        public int ImageId { get; set; }

        public byte[] Content { get; set; }

        public string FileExtension { get; set; }
    }
}
