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

    private char[] symbolsThatAreNotReenteredAfter = { '/', '-', '+', '*'}; 
    private char[] numbers = { '1', '2', '3', '4', '5', '6', '7', '8', '9' }; 
 
    void Start()
    {
        inputField = GameObject.FindGameObjectWithTag("InputField").GetComponent<InputField>(); 
        Debug.Log("name = " + transform.GetChild(0).transform.name);
        textMeshPro.text = symbol.ToString();
    }

    public void InputSymbolInInputField()
    {
        if (inputField != null)
        {
            symbolsFromTheInputField = inputField.text;

            if (CanInputThisSymbos() && CanInputZero())
            {
                inputField.text += symbol;
            }

            else if (!CanInputThisSymbos())
            {
                Debug.Log("Такий символ не можна вводитии першим");
            }
        }
    }

    private bool CanInputThisSymbos()
    {
        for (int i = 0; i < symbolsThatAreNotReenteredAfter.Length; i++)
        {
            if(symbolsFromTheInputField[symbolsFromTheInputField.Length - 1] == symbolsThatAreNotReenteredAfter[i])
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

    private bool CanInputZero()
    {
        if (symbolsFromTheInputField[0] == '0' && symbol == '0')
        {
            return false;
        }

        return true;
    }

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
}
