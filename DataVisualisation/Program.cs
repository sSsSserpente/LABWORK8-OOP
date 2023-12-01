// Abstract class or interface for Graph
public abstract class Graph
{
    public abstract void Draw();
}

// Concrete class for LineGraph
public class LineGraph : Graph
{
    public override void Draw()
    {
        Console.WriteLine("Drawing Line Graph");
        // Add logic for drawing a line graph
    }
}

// Concrete class for BarGraph
public class BarGraph : Graph
{
    public override void Draw()
    {
        Console.WriteLine("Drawing Bar Graph");
        // Add logic for drawing a bar graph
    }
}

// Concrete class for PieChart
public class PieChart : Graph
{
    public override void Draw()
    {
        Console.WriteLine("Drawing Pie Chart");
        // Add logic for drawing a pie chart
    }
}

// Abstract class or interface for GraphFactory
public abstract class GraphFactory
{
    public abstract Graph CreateGraph();
}

// Concrete factory for LineGraph
public class LineGraphFactory : GraphFactory
{
    public override Graph CreateGraph()
    {
        return new LineGraph();
    }
}

// Concrete factory for BarGraph
public class BarGraphFactory : GraphFactory
{
    public override Graph CreateGraph()
    {
        return new BarGraph();
    }
}

// Concrete factory for PieChart
public class PieChartFactory : GraphFactory
{
    public override Graph CreateGraph()
    {
        return new PieChart();
    }
}

// Client class to use GraphFactory
public class DataVisualizer
{
    private GraphFactory graphFactory;

    public DataVisualizer(GraphFactory graphFactory)
    {
        this.graphFactory = graphFactory;
    }

    public void VisualizeData()
    {
        Graph graph = graphFactory.CreateGraph();
        graph.Draw();
    }
}

class Program
{
    static void Main()
    {
        // Example usage

        Console.WriteLine("Enter the type of graph to visualize (line/bar/pie):");
        string graphType = Console.ReadLine().ToLower();

        GraphFactory graphFactory = null;

        switch (graphType)
        {
            case "line":
                graphFactory = new LineGraphFactory();
                break;
            case "bar":
                graphFactory = new BarGraphFactory();
                break;
            case "pie":
                graphFactory = new PieChartFactory();
                break;
            default:
                Console.WriteLine("Invalid graph type");
                return;
        }

        DataVisualizer dataVisualizer = new DataVisualizer(graphFactory);
        dataVisualizer.VisualizeData();
    }
}
