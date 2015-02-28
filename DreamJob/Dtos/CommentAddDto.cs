namespace DreamJob.Dtos
{
    using System.ComponentModel.DataAnnotations;

    public class CommentAddDto
    {
        public long JobOfferId { get; set; }
        [Required]
        public string Text { get; set; }
    }
}