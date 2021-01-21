using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputSymbol : MonoBehaviour
{
    private InputField _inputField;
    [SerializeField] 
    private char symbol;
    [SerializeField] 
    private TextMeshProUGUI textMeshPro;

    private string _symbolsFromTheInputField;

    private char[] _numbers = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

    void Start()
    {
        _inputField = GameObject.FindGameObjectWithTag("InputField").GetComponent<InputField>(); 
        textMeshPro.text = symbol.ToString();
    }

    public void CheckTheOperation()
    {
        DataCalculation.OutputResult(_inputField);
    }

    //Перевірка на введення символу в поле, метод обраховує коли можна вводити нулі
    public void InputSymbolInInputField()
    {
        if (_inputField != null)
        {
            _symbolsFromTheInputField = _inputField.text;

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
                Debug.Log("Недоступний ввід символа");
            }
        }
    }

    //Перевірка на символ
    private bool IsSymbol()
    {
        for (int i = 0; i < DataCalculation._symbolsOperation.Length; i++)
        {
            if(symbol == DataCalculation._symbolsOperation[i])
            {
                return true;
            }
        }

        return false;
    }

    //Перевірка на введення символу, метод потрібний для того щоб не можна було ввести 2 і більше символи операції підряд
    private bool CanInputThisSymbos()
    {
        for (int i = 0; i < DataCalculation._symbolsOperation.Length; i++)
        {
            if(_symbolsFromTheInputField[_symbolsFromTheInputField.Length - 1] == DataCalculation._symbolsOperation[i])
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
        if (_symbolsFromTheInputField[0] == '0' && symbol == '0' && _symbolsFromTheInputField.Length == 1)
        {
            return false;
        }

        return true;
    }

    //Перевірка на число
    private bool IsNumber()
    {
        for (int i = 0; i < _numbers.Length; i++)
        {
            if(symbol == _numbers[i])
            {
                return true;
            }
        }

        return false;
    }
    
    //Перерівяє чи потрібно стирати початковий "0" в полі введення
    private void CheckField()
    {
        if(_symbolsFromTheInputField[0] == '0' && _symbolsFromTheInputField.Length == 1 && !IsSymbol())
        {
            _inputField.text = string.Empty;
            _inputField.text += symbol;
        }

        else
        {
            _inputField.text += symbol;
        }
    }
}
