namespace DreamJob.Dtos
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class CommentAddDto
    {
        public long JobOfferId { get; set; }

        [Required]
        [AllowHtml]
        public string Text { get; set; }
    }
}