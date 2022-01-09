using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleDisplay : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer screen;
    public Transform cameraLocation;

    public Sprite DisplaySprite { get { return screen.sprite; } set { screen.sprite = value; } }

    public void Start()
    {
        if (cameraLocation == null)
        {
            cameraLocation = Camera.main.transform;
        }  
        if (screen == null)
        {
            if (!gameObject.TryGetComponent(out screen))
            {
                throw new MissingComponentException();
            }
        }
    }

    public void Update()
    {
        screen.transform.LookAt(cameraLocation);
    }
}
