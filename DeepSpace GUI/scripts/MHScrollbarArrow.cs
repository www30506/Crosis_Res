using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class MHScrollbarArrow : MonoBehaviour
{
    public Scrollbar target;
    public float step = 0.1f;
    public enum Direction
    {
        Up,
        Down,
    }

    public Direction direction = Direction.Up;

    public void OnPointerDown()
    {        
        if (target != null)
        {
            target.value += direction == Direction.Up ? step : -step;
        }
    }

}
