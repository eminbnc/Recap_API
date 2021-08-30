namespace Core.Utilities.Results
{
    public class SuccessLoginDataResult<T> : SuccessDataResult<T>
    {
        public int UserId { get; }
        public string Claim { get; set; }
        public SuccessLoginDataResult(T data, string message, int id,string claim) : base(data, message)
        {
            UserId = id;
            Claim = claim;
        }

    }
}
