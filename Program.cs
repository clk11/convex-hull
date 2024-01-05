List<Point> list = [new Point(1, -3), new Point(-5, 1), new Point(6, -4), new Point(8, 7),
                    new Point(-5, 9),new Point(-2, -6),new Point(0, 2),
                    new Point(3, -8),new Point(10, 5),new Point(-7, -1)];
var smallestPoint = list.OrderBy(point => point.y).First();
list.Sort((current, next) => polarAngle(smallestPoint, current).CompareTo(polarAngle(smallestPoint, next)));
List<Point> hull = [list[0], list[1]];
for (int i = 2; i < list.Count; i++)
{
    while (hull.Count >= 2 && !counterClockWise(hull[hull.Count - 2], hull[hull.Count - 1], list[i]))
    {
        hull.RemoveAt(hull.Count - 1);
    }
    hull.Add(list[i]);
}

hull.Add(smallestPoint);
System.Console.Write("Convex hull : ");
for (int i = 0; i < hull.Count; i++)
{
    System.Console.Write(hull[i].render());
    if (i != hull.Count - 1) System.Console.Write(", ");
}
System.Console.WriteLine();
static bool OK(Point a, Point b, Point c) // OK checks if the 3 points are either collinear or counterClockWise
{
    return counterClockWise(a, b, c) || collienar(a, b, c);
}

static bool counterClockWise(Point a, Point b, Point c)
{
    return ((b.x - a.x) * (c.y - b.y) - (b.y - a.y) * (c.x - b.x)) > 0;
}

static bool collienar(Point a, Point b, Point c)
{
    return (b.x - a.x) * (c.y - b.y) == (b.y - a.y) * (c.x - b.x);
}

static double polarAngle(Point a, Point b)
{
    return Math.Atan2(b.y - a.y, b.x - a.x);
}

class Point(int x, int y)
{
    public int x { get; set; } = x;
    public int y { get; set; } = y;
    public string render()
    {
        return $"({x},{y})";
    }
}