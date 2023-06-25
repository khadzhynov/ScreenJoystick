using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static Vector2 ScreenPosition(this Canvas canvas, RectTransform rectTransform)
    {
        if (canvas.renderMode == RenderMode.ScreenSpaceOverlay)
        {
            return new Vector2(rectTransform.position.x, rectTransform.position.y);
        }

        return canvas.worldCamera.WorldToScreenPoint(rectTransform.position);
    }

    public static Vector3 WorldPosition(this Canvas canvas, Vector2 screenPosition)
    {
        if (canvas.renderMode == RenderMode.ScreenSpaceOverlay)
        {
            return new Vector3(screenPosition.x, screenPosition.y, canvas.transform.position.z);
        }

        var result = canvas.worldCamera.ScreenToWorldPoint(screenPosition);
        result.z = canvas.transform.position.z;
        return result;
    }
}
