namespace Renamer;

public class ChangeName
{
    public static void AddPrefix(string directory, string prefix)
    {
        var files = Directory.GetFiles(directory);

        foreach (var file in files)
        {
            var newName = Path.Combine(Path.GetDirectoryName(file) ?? string.Empty,
                prefix + "_" + Path.GetFileName(file));
            File.Move(file, newName);
        }
    }

    public static void AddPostfix(string directory, string postfix)
    {
        var files = Directory.GetFiles(directory);

        foreach (var file in files)
        {
            var newName = Path.Combine(Path.GetDirectoryName(file) ?? string.Empty,
                Path.GetFileName(file) + "_" + postfix);
            File.Move(file, newName);
        }
    }
}