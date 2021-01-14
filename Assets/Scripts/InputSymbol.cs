using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputSymbol : MonoBehaviour
{
    private InputField inputField;
    [SerializeField] private char symbol;
    [SerializeField] private TextMeshProUGUI textMeshPro;

    private string symbolsFromTheInputField;

    private char[] numbers = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

    void Start()
    {
        inputField = GameObject.FindGameObjectWithTag("InputField").GetComponent<InputField>(); 
        textMeshPro.text = symbol.ToString();
    }

    public void CheckTheOperation()
    {
        DataCalculation.OutputResult(inputField);
    }

    //Перевірка на введення символу в поле, метод обраховує коли можна вводити нулі
    public void InputSymbolInInputField()
    {
        if (inputField != null)
        {
            symbolsFromTheInputField = inputField.text;

            if (CanInputThisSymbos() && CanInputZero())
            {
                if (IsSymbol())
                {
                    CheckTheOperation();
                }

                CheckField();
            }

            else if (!CanInputThisSymbos())
            {
                Debug.Log("Даний символ не можна вводитии першим");
            }
        }
    }

    //Перевірка на символ
    private bool IsSymbol()
    {
        for (int i = 0; i < DataCalculation.symbolsOperation.Length; i++)
        {
            if(symbol == DataCalculation.symbolsOperation[i])
            {
                return true;
            }
        }

        return false;
    }

    //Перевірка на введення символу, метод потрібний для того щоб не можна було ввести 2 і більше символи операції підряд
    private bool CanInputThisSymbos()
    {
        for (int i = 0; i < DataCalculation.symbolsOperation.Length; i++)
        {
            if(symbolsFromTheInputField[symbolsFromTheInputField.Length - 1] == DataCalculation.symbolsOperation[i])
            {
                if(IsNumber())
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }
        }

        return true;

    }

    //Перевірка на введення нуля
    private bool CanInputZero()
    {
        if (symbolsFromTheInputField[0] == '0' && symbol == '0' && symbolsFromTheInputField.Length == 1)
        {
            return false;
        }

        return true;
    }

    //Перевірка на число
    private bool IsNumber()
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            if(symbol == numbers[i])
            {
                return true;
            }
        }

        return false;
    }
    
    //Перерівяє чи потрібно стирати початковий "0" в полі введення
    private void CheckField()
    {
        if(symbolsFromTheInputField[0] == '0' && symbolsFromTheInputField.Length == 1 && !IsSymbol())
        {
            inputField.text = string.Empty;
            inputField.text += symbol;
        }

        else
        {
            inputField.text += symbol;
        }
    }
}
