using System.Text.Json;

namespace WebApp.Shared
{
    public class ObjBuilder
    {
        /// <summary>
        /// Deserializes a file into a type, and returns the result.
        /// </summary>
        /// <typeparam name="T">The desired type, to be created.</typeparam>
        /// <param name="filePath">The path to the json file.</param>
        /// <returns>An object of the type specified, whose properties reflect the contents of the file provided.</returns>
        public T? BuildObjFromJsonFile<T>(string filePath)
        {
            string fileContent = File.ReadAllText(filePath);
            T? targetObj = JsonSerializer.Deserialize<T>(fileContent);
            return targetObj;
        }
    }
}
