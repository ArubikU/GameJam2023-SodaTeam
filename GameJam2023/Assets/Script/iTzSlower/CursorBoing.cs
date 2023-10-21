using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorBoing : MonoBehaviour
{
    [SerializeField] ChangeColor Changevar;
    [SerializeField] Texture2D cursorTexture;
    private Vector2 cursorHotspot;

    int inecesario;
    void Start()
    {
        cursorHotspot = new Vector2(cursorTexture.width/2, cursorTexture.height/2);
        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Vector2.Distance(Input.mousePosition, Changevar.postion) <= 50)
        {
            inecesario += 1;
            Debug.Log("le atinaste" + inecesario);
        }
    }
}
