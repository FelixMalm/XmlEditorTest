using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

public class XmlConverterService
{
    public async Task<T> DeserializeXmlFileToObjectAsync<T>(Stream xmlFileStream)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));

        using (xmlFileStream)
        {
            try
            {
                // Read the stream into a string asynchronously
                using (var reader = new StreamReader(xmlFileStream))
                {
                    string xmlContent = await reader.ReadToEndAsync();

                    // Deserialize from string
                    using (var stringReader = new StringReader(xmlContent))
                    {
                        return (T)serializer.Deserialize(stringReader);
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                // Log or handle the exception (ex.Message) for debugging
                throw new ApplicationException("Deserialization failed.", ex);
            }
        }
    }
}
