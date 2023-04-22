using UnityEngine;

public class Input
{
    private const string AXIS_HORIZONTAL = "Horizontal";
    private const string AXIS_VERTICAL = "Vertical";

    private Vector2 _axisValues = Vector2.zero;

    private static Input _instance = null;
    public static Input Instance
    {
        get
        {
            _instance ??= new Input();
            return _instance;
        }
    }

    public Vector2 GetAxis()
    {
        _axisValues.x = UnityEngine.Input.GetAxis(AXIS_HORIZONTAL);
        _axisValues.y = UnityEngine.Input.GetAxis(AXIS_VERTICAL);
        return _axisValues;
    }
}
