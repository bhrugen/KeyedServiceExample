namespace KeyedService.Services
{
    public class CloudStorageService : IStorageService
    {
        public void UploadData(string someDate)
        {
            //some logic
            Console.WriteLine("Data uploaded to Cloud");
        }
    }
}
