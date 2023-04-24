using UnityEngine;

namespace Prototype.Input
{
    public static class Axis
    {
        public const string HORIZONTAL = "Horizontal";
        public const string VERTICAL = "Vertical";
        public static Vector2 GetValues(Vector2 axisValues)
        {
            axisValues.x = UnityEngine.Input.GetAxisRaw(HORIZONTAL);
            axisValues.y = UnityEngine.Input.GetAxisRaw(VERTICAL);
            return axisValues.normalized;
        }
    }
}
