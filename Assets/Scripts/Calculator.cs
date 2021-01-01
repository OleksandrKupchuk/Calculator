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

    public void ButtonReset()
    {
        inputField.text = "0";
    }
}

