namespace RPG.Dtos
{
    //Wrap any server responses in this to provide info 
    //  without user having to deduce success from data
    //  + add helpful messages
    public class ApiResponse<T>
    {
        public bool Success { get; set; } = true;
        public T? Data { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}