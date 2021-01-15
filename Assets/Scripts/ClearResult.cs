using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearResult : MonoBehaviour
{
    [SerializeField] private InputField inputField;

    void Start()
    {
        inputField.text = "0";
    }

    //Скидає поле виведення
    public void ResetResult()
    {
        inputField.text = "0";
    }
}

