using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{
    [SerializeField] private InputField inputField;
    private char[] symbolsOperation = { '-', '+', '*', '/' };
    private int numberChar;
    private string leftSide;
    private string rightSide;
    private int result;
    private string symbolsFromTheInputField;

    void Start()
    {
        inputField.text = "0";
    }

    public void GetResult()
    {
        SplitOfTheEnteredLineInTheInputField();
    }

    private void SplitOfTheEnteredLineInTheInputField()
    {
        if(inputField.text != null)
        {
            symbolsFromTheInputField = inputField.text;
            for (int i = 0; i < symbolsFromTheInputField.Length; i++)
            {
                for (int j = 0; j < symbolsOperation.Length; j++)
                {
                    if (symbolsFromTheInputField[i] == symbolsOperation[j])
                    {
                        numberChar = i;
                        leftSide = symbolsFromTheInputField.Substring(0, numberChar);
                        rightSide = symbolsFromTheInputField.Substring(numberChar + 1);
                        result = Calculation(symbolsFromTheInputField[i], int.Parse(leftSide), int.Parse(rightSide));
                        inputField.text = result.ToString();
                        break;
                    }

                    else
                    {
                        Debug.Log("Не введений символ операції");
                    }
                }
            }
        }

        else
        {
            Debug.LogError("Поле пусте");
        }
    }

    private int Calculation(char symbol, int a, int b)
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

