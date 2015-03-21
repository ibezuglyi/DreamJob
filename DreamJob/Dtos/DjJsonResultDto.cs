namespace DreamJob.Dtos
{
    using System.Collections.Generic;

    public class DjJsonResultDto<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; }
    }
}