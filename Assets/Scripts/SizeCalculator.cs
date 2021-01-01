using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeCalculator : MonoBehaviour
{
    [SerializeField] private int screenWidth;
    [SerializeField] private int screenHeight;

    [SerializeField] private GameObject calculatorObject;

    private RectTransform calculatorRectTransform;

    void Start()
    {
        if(calculatorObject != null)
        {
            calculatorRectTransform = calculatorObject.GetComponent<RectTransform>();
        }
        else
        {
            Debug.LogError("Посилання на об'єкт не встановлено");
        }

        screenWidth = Screen.width;
        screenHeight = Screen.height;

        ChangeSize(screenWidth, screenHeight);
    }

    private void ChangeSize(float screenWidth, float screenHeight)
    {
        if(screenWidth < calculatorRectTransform.sizeDelta.x && screenHeight > calculatorRectTransform.sizeDelta.y)
        {
            SetLocalScale(GetScale(screenWidth, calculatorRectTransform.sizeDelta.x));
        }

        if (screenWidth > calculatorRectTransform.sizeDelta.y && screenHeight < calculatorRectTransform.sizeDelta.x)
        {
            SetLocalScale(GetScale(screenHeight, calculatorRectTransform.sizeDelta.y));
        }

        if (screenWidth < calculatorRectTransform.sizeDelta.y && screenHeight < calculatorRectTransform.sizeDelta.x)
        {
            SetLocalScale(GetScale(FindingTheSmallerSide(screenWidth, screenHeight), FindingTheSmallerSide(screenWidth, screenHeight)));
        }
    }

    private void SetLocalScale(float valueX)
    {
        calculatorRectTransform.localScale = new Vector2(calculatorRectTransform.localScale.x * valueX, calculatorRectTransform.localScale.y * valueX);
    }

    private float GetScale(float screenSize, float calculatorSize)
    {
        return screenSize / calculatorSize;
    }

    private float FindingTheSmallerSide(float widthSide, float heightSide)
    {
        if(widthSide < heightSide)
        {
            return widthSide;
        }

        return heightSide;
    }
}
