using GDLIlib1;

try
{
    Line l1 = new Line();
    l1.Draw();
    Point pt = new Point();
    pt.X = 56;
    pt.Y = 66;
    Console.WriteLine(pt.ToString());
}
catch (ArgumentException e)
{
    Console.Write(e.Message);
}
finally
{
    // Code to execute in the finally block, if any.
}