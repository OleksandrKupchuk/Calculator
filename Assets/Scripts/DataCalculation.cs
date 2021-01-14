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

    /// <summary>
    /// Метод приймає вираз із поля введення і ділить його на 2 числа та повертає символ оперрації який у введений у виразі
    /// </summary>
    /// <param name="inputFieldText"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Виведення результату
    /// </summary>
    /// <param name="inputField"></param>
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

    /// <summary>
    /// Обраховує вираз, якщо у виразі присутні 2 числа і знак, інакше виводить повідомлення
    /// </summary>
    /// <param name="inputField"></param>
    private static void Operation(InputField inputField)
    {
        if (GetCharFromInputField(inputField.text) != '0')
        {
            result = Calculator.Calculation(symbolOperationOfTheLine, int.Parse(leftPartOfTheLine), int.Parse(rightPartOfTheLine));
            inputField.text = result.ToString();
        }

        else
        {
            Debug.Log("Введений '0'");
        }
    }
}
