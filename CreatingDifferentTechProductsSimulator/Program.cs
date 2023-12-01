// Abstract product: Screen
public abstract class Screen
{
    public abstract void Display();
}

// Concrete product: SmartphoneScreen
public class SmartphoneScreen : Screen
{
    public override void Display()
    {
        Console.WriteLine("Displaying content on a smartphone screen.");
    }
}

// Concrete product: LaptopScreen
public class LaptopScreen : Screen
{
    public override void Display()
    {
        Console.WriteLine("Displaying content on a laptop screen.");
    }
}

// Concrete product: TabletScreen
public class TabletScreen : Screen
{
    public override void Display()
    {
        Console.WriteLine("Displaying content on a tablet screen.");
    }
}

// Abstract product: Processor
public abstract class Processor
{
    public abstract void Process();
}

// Concrete product: SmartphoneProcessor
public class SmartphoneProcessor : Processor
{
    public override void Process()
    {
        Console.WriteLine("Processing tasks on a smartphone processor.");
    }
}

// Concrete product: LaptopProcessor
public class LaptopProcessor : Processor
{
    public override void Process()
    {
        Console.WriteLine("Processing tasks on a laptop processor.");
    }
}

// Concrete product: TabletProcessor
public class TabletProcessor : Processor
{
    public override void Process()
    {
        Console.WriteLine("Processing tasks on a tablet processor.");
    }
}

// Abstract product: Camera
public abstract class Camera
{
    public abstract void Capture();
}

// Concrete product: SmartphoneCamera
public class SmartphoneCamera : Camera
{
    public override void Capture()
    {
        Console.WriteLine("Capturing photos with a smartphone camera.");
    }
}

// Concrete product: LaptopCamera
public class LaptopCamera : Camera
{
    public override void Capture()
    {
        Console.WriteLine("Capturing photos with a laptop camera.");
    }
}

// Concrete product: TabletCamera
public class TabletCamera : Camera
{
    public override void Capture()
    {
        Console.WriteLine("Capturing photos with a tablet camera.");
    }
}

// Abstract Factory: TechProductFactory
public abstract class TechProductFactory
{
    public abstract Screen CreateScreen();
    public abstract Processor CreateProcessor();
    public abstract Camera CreateCamera();
}

// Concrete Factory: SmartphoneFactory
public class SmartphoneFactory : TechProductFactory
{
    public override Screen CreateScreen()
    {
        return new SmartphoneScreen();
    }

    public override Processor CreateProcessor()
    {
        return new SmartphoneProcessor();
    }

    public override Camera CreateCamera()
    {
        return new SmartphoneCamera();
    }
}

// Concrete Factory: LaptopFactory
public class LaptopFactory : TechProductFactory
{
    public override Screen CreateScreen()
    {
        return new LaptopScreen();
    }

    public override Processor CreateProcessor()
    {
        return new LaptopProcessor();
    }

    public override Camera CreateCamera()
    {
        return new LaptopCamera();
    }
}

// Concrete Factory: TabletFactory
public class TabletFactory : TechProductFactory
{
    public override Screen CreateScreen()
    {
        return new TabletScreen();
    }

    public override Processor CreateProcessor()
    {
        return new TabletProcessor();
    }

    public override Camera CreateCamera()
    {
        return new TabletCamera();
    }
}

// Client class to use TechProductFactory
public class TechProductAssembler
{
    private TechProductFactory productFactory;

    public TechProductAssembler(TechProductFactory productFactory)
    {
        this.productFactory = productFactory;
    }

    public void AssembleProduct()
    {
        Screen screen = productFactory.CreateScreen();
        Processor processor = productFactory.CreateProcessor();
        Camera camera = productFactory.CreateCamera();

        Console.WriteLine("Assembling a tech product...");
        screen.Display();
        processor.Process();
        camera.Capture();
    }
}

class Program
{
    static void Main()
    {
        // Example usage

        Console.WriteLine("Enter the type of tech product to assemble (smartphone/laptop/tablet):");
        string productType = Console.ReadLine().ToLower();

        TechProductFactory productFactory = null;

        switch (productType)
        {
            case "smartphone":
                productFactory = new SmartphoneFactory();
                break;
            case "laptop":
                productFactory = new LaptopFactory();
                break;
            case "tablet":
                productFactory = new TabletFactory();
                break;
            default:
                Console.WriteLine("Invalid tech product type");
                return;
        }

        TechProductAssembler productAssembler = new TechProductAssembler(productFactory);
        productAssembler.AssembleProduct();
    }
}
