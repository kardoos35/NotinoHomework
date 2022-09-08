namespace NotinoHomework.Application.Providers
{
    public  interface IFileProvider
    {
        string PathCombine(params string[] paths);

        bool FileExists(string path);
    }
}
