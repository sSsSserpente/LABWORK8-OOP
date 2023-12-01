// Data Prototypes
public class CsvDataPrototype
{
    public string CsvField1 { get; set; }
    public string CsvField2 { get; set; }
}

public class XmlDataPrototype
{
    public string XmlElement1 { get; set; }
    public string XmlElement2 { get; set; }
}

public class JsonDataPrototype
{
    public string JsonProperty1 { get; set; }
    public string JsonProperty2 { get; set; }
}

// Adapters
public interface IDataAdapter<TFrom, TTo>
{
    TTo Convert(TFrom source);
}

public class CsvToXmlAdapter : IDataAdapter<CsvDataPrototype, XmlDataPrototype>
{
    // Converts CSV data to XML format
    public XmlDataPrototype Convert(CsvDataPrototype csvData)
    {
        return new XmlDataPrototype
        {
            XmlElement1 = csvData.CsvField1,
            XmlElement2 = csvData.CsvField2
        };
    }
}

public class JsonToXmlAdapter : IDataAdapter<JsonDataPrototype, XmlDataPrototype>
{
    // Converts JSON data to XML format
    public XmlDataPrototype Convert(JsonDataPrototype jsonData)
    {
        return new XmlDataPrototype
        {
            XmlElement1 = jsonData.JsonProperty1,
            XmlElement2 = jsonData.JsonProperty2
        };
    }
}

// Client Code
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the source data format (CSV/JSON):");
        string sourceFormat = Console.ReadLine().ToUpper();

        Console.WriteLine("Enter the target data format (XML/JSON):");
        string targetFormat = Console.ReadLine().ToUpper();

        // Create a prototype of the source data
        object sourceData = CreateSourceData(sourceFormat);

        // Choose an adapter based on the input formats
        IDataAdapter<object, object> adapter = ChooseAdapter(sourceFormat, targetFormat);

        // Use the adapter to convert the data
        object targetData = adapter.Convert(sourceData);

        // Display the converted data
        Console.WriteLine("Converted data:");
        Console.WriteLine(targetData);
    }

    // Create a prototype of the source data based on the input format
    private static object CreateSourceData(string sourceFormat)
    {
        switch (sourceFormat)
        {
            case "CSV":
                return new CsvDataPrototype { CsvField1 = "Value1", CsvField2 = "Value2" };
            case "JSON":
                return new JsonDataPrototype { JsonProperty1 = "Value1", JsonProperty2 = "Value2" };
            default:
                throw new ArgumentException("Invalid source format");
        }
    }

    // Choose an adapter based on the input and target formats
    private static IDataAdapter<object, object> ChooseAdapter(string sourceFormat, string targetFormat)
    {
        switch (sourceFormat)
        {
            case "CSV":
                return targetFormat switch
                {
                    "XML" => new CsvToXmlAdapter() as IDataAdapter<object, object>,
                    "JSON" => new CsvToJsonAdapter() as IDataAdapter<object, object>,
                    _ => throw new ArgumentException("Invalid target format"),
                };
            case "JSON":
                return targetFormat switch
                {
                    "XML" => new JsonToXmlAdapter() as IDataAdapter<object, object>,
                    "CSV" => new JsonToCsvAdapter() as IDataAdapter<object, object>,
                    _ => throw new ArgumentException("Invalid target format"),
                };
            default:
                throw new ArgumentException("Invalid source format");
        }
    }
}
