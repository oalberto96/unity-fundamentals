﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    // Know what objects are clickable
    public LayerMask clickableLayer;

    // Swap cursors per object
    public Texture2D pointer; // Normal Pointer
    public Texture2D target; // Cursor for clickable objects like the world
    public Texture2D doorway; // Cursor for doorways
    public Texture2D combat; // Cursor for combat actions

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50, clickableLayer.value))
        {
            bool door = false;
            if(hit.collider.gameObject.tag == "Doorway")
            {
                Cursor.SetCursor(doorway, new Vector2(16, 16), CursorMode.Auto);
                door = true;
            } else
            {
                Cursor.SetCursor(target, new Vector2(16, 16), CursorMode.Auto);
            }
        } else
        {
            Cursor.SetCursor(pointer, Vector2.zero, CursorMode.Auto);
        }
        
    }
}
