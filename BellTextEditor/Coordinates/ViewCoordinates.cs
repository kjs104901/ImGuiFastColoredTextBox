using Bell.Data;

namespace Bell.Coordinates;

public struct ViewCoordinates
{
    public float X;
    public float Y;

    public ViewCoordinates(float x, float y)
    {
        X = x;
        Y = y;
    }

    public PageCoordinates ToPageCoordinates(Page page)
    {
        //TODO
        //page.X + X;
        //page.Y + Y;
        return new PageCoordinates(0, 0);
    }
}