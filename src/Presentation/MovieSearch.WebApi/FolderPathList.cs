namespace MovieSearch.WebApi;

public static class FolderPathList
{
    public static string ProjectFolder =>
        Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\..\.."));
    public static string TempFolder => ProjectFolder + @"\temp\";
}