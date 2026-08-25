using System.IO;
using System.Text.Json;
using NUnit.Framework;

namespace DrozdHW_AQA.Utils;

public static class JsonFileReader
{
    public static T ReadAndDeserialize<T>(string fileName)
    {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Resources", fileName);
        string json = File.ReadAllText(path);

        return JsonSerializer.Deserialize<T>(json);
    }
}
