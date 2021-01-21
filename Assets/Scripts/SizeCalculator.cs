using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeCalculator : MonoBehaviour
{
    [SerializeField] 
    private int _screenWidth;
    [SerializeField] 
    private int _screenHeight;

    [SerializeField] 
    private GameObject _calculatorObject;

    private RectTransform _calculatorRectTransform;

    void Start()
    {
        if(_calculatorObject != null)
        {
            _calculatorRectTransform = _calculatorObject.GetComponent<RectTransform>();
        }
        else
        {
            Debug.LogError("Посилання на об'єкт не встановлено");
        }

        _screenWidth = Screen.width;
        _screenHeight = Screen.height;

        ChangeSize(_screenWidth, _screenHeight);
    }

    /// <summary>
    /// Зміна розмірів калькулятора при розширеннях менших або більших за сам калькулятор.
    /// </summary>
    /// <param name="screenWidth"></param>
    /// <param name="screenHeight"></param>
    private void ChangeSize(float screenWidth, float screenHeight)
    {
        if (screenWidth < _calculatorRectTransform.sizeDelta.x)
        {
            SetLocalScale(GetScale(screenWidth, _calculatorRectTransform.sizeDelta.x));
        }

        if (screenHeight < _calculatorRectTransform.sizeDelta.y)
        {
            SetLocalScale(GetScale(screenHeight, _calculatorRectTransform.sizeDelta.y));
        }

        if (screenWidth > _calculatorRectTransform.sizeDelta.y && screenHeight > _calculatorRectTransform.sizeDelta.x)
        {
            SetLocalScale(GetScale(FindingTheSmallerSide(screenWidth, screenHeight), _calculatorRectTransform.sizeDelta.x));
        }
    }

    //Встановлюємо нові розміри калькулятору 
    private void SetLocalScale(float valueX)
    {
        _calculatorRectTransform.localScale = new Vector2(_calculatorRectTransform.localScale.x * valueX, _calculatorRectTransform.localScale.y * valueX);
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
