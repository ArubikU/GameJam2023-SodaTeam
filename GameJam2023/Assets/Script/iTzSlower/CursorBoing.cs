using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBoing : MonoBehaviour
{
    [SerializeField] ChangeColor Changevar;
    [SerializeField] Texture2D cursorTexture;
    private Vector2 cursorHotspot;

    void Start()
    {
        cursorHotspot = new Vector2(cursorTexture.width/2, cursorTexture.height/2);
        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
    }
    void Update()
    {
        
    }
}
