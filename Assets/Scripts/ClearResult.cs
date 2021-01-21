using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearResult : MonoBehaviour
{
    [SerializeField] 
    private InputField _outputField;

    void Start()
    {
        _outputField.text = "0";
    }

    //Скидає поле виведення
    public void ResetResult()
    {
        _outputField.text = "0";
    }
}

