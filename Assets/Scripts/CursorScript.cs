using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    [SerializeField] private Texture2D releasedCursorTexture;
    [SerializeField] private Texture2D pressedCursorTexture;

    private Vector2 cursorHotSpot;

    private void Start()
    {
        Cursor.visible = true;
        cursorHotSpot = new Vector2(releasedCursorTexture.width / 2 , releasedCursorTexture.height / 2);

        Cursor.SetCursor(releasedCursorTexture, cursorHotSpot, CursorMode.Auto);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(pressedCursorTexture, cursorHotSpot, CursorMode.Auto);
        }else if (Input.GetMouseButtonUp(0)) 
        {
            Cursor.SetCursor(releasedCursorTexture, cursorHotSpot, CursorMode.Auto);
        }
    }

}
