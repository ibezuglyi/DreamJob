namespace DreamJob.Dtos
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class CommentAddDto
    {
        public long JobOfferId { get; set; }

        [Required(
            ErrorMessageResourceType = typeof(Resources.Translations),
            ErrorMessageResourceName = "CommentAdd_Dto_TextIsRequired")]
        [AllowHtml]
        public string Text { get; set; }
    }
}