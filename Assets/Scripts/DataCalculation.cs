using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataCalculation
{
    private static string _stringFromTheInputField;
    public static char[] _symbolsOperation = { '-', '+', '*', '/' };
    private static string _leftPartOfTheLine;
    private static string _rightPartOfTheLine;
    private static char _symbolOperationOfTheLine;
    private static float _result;

    /// <summary>
    /// Метод приймає вираз із поля введення і ділить його на 2 числа та повертає символ оперрації який у введений у виразі
    /// </summary>
    /// <param name="inputFieldText"></param>
    /// <returns></returns>
    private static char GetCharFromInputField(string inputFieldText)
    {
        _stringFromTheInputField = inputFieldText;

        for (int i = _stringFromTheInputField.Length - 1; i > 0; i--)
        {
            for (int j = 0; j < _symbolsOperation.Length; j++)
            {
                if (_stringFromTheInputField[i] == _symbolsOperation[j] && _stringFromTheInputField[_stringFromTheInputField.Length - 1] != _symbolsOperation[j])
                {
                    _symbolOperationOfTheLine = _stringFromTheInputField[i];
                    _leftPartOfTheLine = _stringFromTheInputField.Substring(0, i);
                    _rightPartOfTheLine = _stringFromTheInputField.Substring(i + 1);

                    return _symbolOperationOfTheLine;
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
            _result = Calculation(_symbolOperationOfTheLine, float.Parse(_leftPartOfTheLine), float.Parse(_rightPartOfTheLine));
            inputField.text = _result.ToString();
        }

        else
        {
            Debug.Log("Отриманий '0'");
        }
    }

    /// <summary>
    /// Приймає 2 числа і знак операції, повертає результат
    /// </summary>
    /// <param name="symbol"></param>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static float Calculation(char symbol, float a, float b)
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
}
