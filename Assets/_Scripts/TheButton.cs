using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform), typeof(Collider2D))]
public class TheButton : MonoBehaviour, ICanvasRaycastFilter
{
    Collider2D myCollider;
    RectTransform rectTransform;

    void Awake()
    {
        myCollider = GetComponent<Collider2D>();
        rectTransform = GetComponent<RectTransform>();
    }

    #region ICanvasRaycastFilter Implementation
    public bool IsRaycastLocationValid(Vector2 screenPos, Camera eventCamera)
    {
        var worldPoint = Vector3.zero;
        var isInside = RectTransformUtility.ScreenPointToWorldPointInRectangle(
            rectTransform,
            screenPos,
            eventCamera,
            out worldPoint
        );
        if (isInside)
            isInside = myCollider.OverlapPoint(worldPoint);
        return isInside;
    }
    #endregion
}