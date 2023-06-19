namespace BlazorUI.Utilities
{
    public static class SvgUtility
    {
        public static string GetTransform(float x, float y, float angle = 0f, float scale = 1f)
        {
            string transform = "";

            if (x != 0f || y != 0f)
                transform += $"translate({x},{y})";

            if (angle != 0f)
                transform += $" rotate({angle})";

            if (scale != 1f)
                transform += $" scale({scale})";

            return transform;

        }
    }
}
