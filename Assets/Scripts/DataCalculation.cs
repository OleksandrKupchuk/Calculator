using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataCalculation
{
    private static string symbolsFromTheInputField;
    private static char[] symbolsOperation = { '-', '+', '*', '/' };
    private static string leftSide;
    private static string rightSide;
    private static char symbolOperation;
    private static int result;

    private static char GetCharFromInputField(string inputFieldText)
    {
        symbolsFromTheInputField = inputFieldText;

        for (int i = symbolsFromTheInputField.Length - 1; i > 0; i--)
        {
            for (int j = 0; j < symbolsOperation.Length; j++)
            {
                if (symbolsFromTheInputField[i] == symbolsOperation[j] && symbolsFromTheInputField[symbolsFromTheInputField.Length - 1] != symbolsOperation[j])
                {
                    symbolOperation = symbolsFromTheInputField[i];
                    leftSide = symbolsFromTheInputField.Substring(0, i);
                    rightSide = symbolsFromTheInputField.Substring(i + 1);

                    return symbolOperation;
                }

                else
                {
                    Debug.Log("У виразі вітсутній символ");
                }
            }
        }

        return '0';
    }

    public static void OutputResult(InputField inputField)
    {
        if (inputField.text != null)
        {
            Operation(inputField);
        }

        else
        {
            Debug.LogError("Поле пусте");
        }
    }

    private static void Operation(InputField inputField)
    {
        GetCharFromInputField(inputField.text);

        if (GetCharFromInputField(inputField.text) != '0')
        {
            result = Calculator.Calculation(symbolOperation, int.Parse(leftSide), int.Parse(rightSide));
            inputField.text = result.ToString();
        }

        else
        {
            Debug.LogError("Не введене друге число");
        }
    }
}
