using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeCalculator : MonoBehaviour
{
    [SerializeField] private float height;
    [SerializeField] private float width;

    [SerializeField] private float widthButton;

    [SerializeField] private int screenWidth;
    [SerializeField] private int screenHeight;

    [SerializeField] private GameObject calculatorObject;

    private GridLayoutGroup keyboadrLayoutGroup;

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
            float value = screenWidth / calculatorRectTransform.sizeDelta.x;

            calculatorRectTransform.localScale = new Vector2(calculatorRectTransform.localScale.x * value, calculatorRectTransform.localScale.y * value);
        }

        if (screenWidth > calculatorRectTransform.sizeDelta.y && screenHeight < calculatorRectTransform.sizeDelta.x)
        {
            float value = screenHeight / calculatorRectTransform.sizeDelta.y;

            calculatorRectTransform.localScale = new Vector2(calculatorRectTransform.localScale.x * value, calculatorRectTransform.localScale.y * value);
        }

        if (screenWidth < calculatorRectTransform.sizeDelta.y && screenHeight < calculatorRectTransform.sizeDelta.x)
        {
            float valueX = screenWidth / calculatorRectTransform.sizeDelta.x;
            float valueY = screenHeight / calculatorRectTransform.sizeDelta.y;

            calculatorRectTransform.localScale = new Vector2(calculatorRectTransform.localScale.x * valueX, calculatorRectTransform.localScale.y * valueY);
        }
    }
}
