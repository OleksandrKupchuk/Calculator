using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeCalculator : MonoBehaviour
{
    [SerializeField] private float height;
    [SerializeField] private float width;

    [SerializeField] private int screenWidth;
    [SerializeField] private int screenHeight;

    [SerializeField] private GameObject numbersObject;
    [SerializeField] private GameObject operationObject;
    [SerializeField] private GameObject inputFieldObject;

    private GridLayoutGroup numbersLayoutGroup;
    private GridLayoutGroup operationLayoutGroup;
    private RectTransform inputRectTransform;

    void Start()
    {
        numbersLayoutGroup = numbersObject.GetComponent<GridLayoutGroup>();
        operationLayoutGroup = operationObject.GetComponent<GridLayoutGroup>();
        inputRectTransform = inputFieldObject.GetComponent<RectTransform>();

        ChangeSize();
    }

    void Update()
    {
        
    }

    private void ChangeSize()
    {
        screenWidth = Screen.width;

        if(screenWidth < inputRectTransform.sizeDelta.x)
        {
            float valueX = screenWidth / inputRectTransform.sizeDelta.x;
            width = (inputRectTransform.sizeDelta.x * valueX) - 10f;

            inputRectTransform.sizeDelta = new Vector2(width, inputRectTransform.sizeDelta.y);
        }
    }
}
