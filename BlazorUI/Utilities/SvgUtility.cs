namespace BlazorUI.Utilities;

public static class SvgUtility
{
    public static string GetTransform(float x, float y, float angle = 0f, float scale = 1f)
    {
        string transform = "";

        if (x != 0f || y != 0f)
            transform += $"translate({FloatToStringWithDot(x)},{FloatToStringWithDot(y)})";

        if (angle != 0f)
            transform += $" rotate({FloatToStringWithDot(angle)})";

        if (scale != 1f)
            transform += $" scale({FloatToStringWithDot(scale)})";

        return transform;

    }

    public static string FloatToStringWithDot(float number)
    {
        return number.ToString().Replace(',', '.');
    }
}



