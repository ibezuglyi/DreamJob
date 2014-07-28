namespace DreamJob.Common.Enum
{
    using System.Collections.Generic;
    using System.Linq;

    public class DjOperationResult<T>
    {
        public DjOperationResult(T data)
        {
            this.Data = data;
            this.IsSuccess = true;
            this.Errors = new List<string>();
        }

        public DjOperationResult(bool success, string[] errors)
        {
            this.Data = default(T);
            this.IsSuccess = success;
            this.Errors = new List<string>(errors);
        }

        private DjOperationResult()
        {
            this.IsSuccess = true;
            
        }

        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; }

        public static DjOperationResult<T> Success()
        {
            return new DjOperationResult<T>(default(T));
        }

        public static DjOperationResult<T> Fail()
        {
            return new DjOperationResult<T>(false, Enumerable.Empty<string>().ToArray());
        }
    }
}