using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOption : MonoBehaviour
{
    public string optionName;

    ///All part of the option system
    private CanvasGroup menu;

    private bool isInTransition = false;
    private float tranistionSpeed = 1;

    public void Start()
    {
        menu = this.gameObject.GetComponent<CanvasGroup>();
    }
    private static float lerpAlpha(float a, float b, float speed = 1)
    {
        return a + (Time.deltaTime * speed) * (b - a);
    }

    public void Update()
    {
        if (isInTransition)
        {
            float target = (menu.interactable) ? 1 : 0;
            menu.alpha = lerpAlpha(menu.alpha, target, tranistionSpeed);

            if(menu.alpha == target)
            {
                isInTransition = false;
            }
        }
    }

    public void toggleVisability(bool isVisable = false)
    {
        menu.interactable = isVisable;
        isInTransition = true;
    }

    public void hide()
    {
        menu.alpha = 0;
        menu.interactable = false;
    }

    public void show()
    {
        menu.alpha = 1;
        menu.interactable = true;
    }

    public void setTransitionSpeed(float pSpeed = 1)
    {
        tranistionSpeed = pSpeed;
    }

}