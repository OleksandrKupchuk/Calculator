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

    /// <summary>
    /// Зміна розмірів калькулятора при розширеннях менших за сам калькулятор.
    /// </summary>
    /// <param name="screenWidth"></param>
    /// <param name="screenHeight"></param>
    private void ChangeSize(float screenWidth, float screenHeight)
    {
        if(screenWidth < calculatorRectTransform.sizeDelta.x)
        {
            SetLocalScale(GetScale(screenWidth, calculatorRectTransform.sizeDelta.x));
        }

        if (screenWidth > calculatorRectTransform.sizeDelta.y)
        {
            SetLocalScale(GetScale(screenHeight, calculatorRectTransform.sizeDelta.y));
        }

        if(screenWidth > calculatorRectTransform.sizeDelta.y && screenHeight > calculatorRectTransform.sizeDelta.x)
        {
            SetLocalScale(GetScale(FindingTheSmallerSide(screenWidth, screenHeight), calculatorRectTransform.sizeDelta.x));
        }
    }

    //Встановлюємо нові розміри калькулятору 
    private void SetLocalScale(float valueX)
    {
        calculatorRectTransform.localScale = new Vector2(calculatorRectTransform.localScale.x * valueX, calculatorRectTransform.localScale.y * valueX);
    }

    //Визначаємо у скільки разів розмір екрану менший за розмір калькулятора
    private float GetScale(float sizeDevice, float sizeCalculator)
    {
        return sizeDevice / sizeCalculator;
    }

    //Визначаємо найменший розмір сторони екрану
    private float FindingTheSmallerSide(float widthSide, float heightSide)
    {
        if(widthSide < heightSide)
        {
            return widthSide;
        }

        return heightSide;
    }
}
