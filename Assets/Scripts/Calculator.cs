using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{
    [SerializeField] private InputField inputField;

    void Start()
    {
        inputField.text = "0";
    }

    /// <summary>
    /// Приймає 2 числа і знак операції, повертає результат
    /// </summary>
    /// <param name="symbol"></param>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static int Calculation(char symbol, int a, int b)
    {
        switch (symbol)
        {
            case '*':
                return a * b;

            case '/':
                return a / b;

            case '+':
                return a + b;

            case '-':
                return a - b;
        }

        return 0;
    }

    //Скидає поле введення
    public void ButtonReset()
    {
        inputField.text = "0";
    }
}

