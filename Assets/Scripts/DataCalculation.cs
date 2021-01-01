using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataCalculation
{
    private static string stringFromTheInputField;
    public static char[] symbolsOperation = { '-', '+', '*', '/' };
    private static string leftPartOfTheLine;
    private static string rightPartOfTheLine;
    private static char symbolOperationOfTheLine;
    private static int result;

    private static char GetCharFromInputField(string inputFieldText)
    {
        stringFromTheInputField = inputFieldText;

        for (int i = stringFromTheInputField.Length - 1; i > 0; i--)
        {
            for (int j = 0; j < symbolsOperation.Length; j++)
            {
                if (stringFromTheInputField[i] == symbolsOperation[j] && stringFromTheInputField[stringFromTheInputField.Length - 1] != symbolsOperation[j])
                {
                    symbolOperationOfTheLine = stringFromTheInputField[i];
                    leftPartOfTheLine = stringFromTheInputField.Substring(0, i);
                    rightPartOfTheLine = stringFromTheInputField.Substring(i + 1);

                    return symbolOperationOfTheLine;
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
            result = Calculator.Calculation(symbolOperationOfTheLine, int.Parse(leftPartOfTheLine), int.Parse(rightPartOfTheLine));
            inputField.text = result.ToString();
        }

        else
        {
            Debug.LogError("Не введене друге число");
        }
    }
}
