using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputSymbol : MonoBehaviour
{
    [SerializeField] private InputField input;
    //[SerializeField] private TextMeshProUGUI input;
    [SerializeField] private string startSymbol;
    [SerializeField] private string nameButton;
    [SerializeField] private TextMeshProUGUI symbol;

    void Start()
    {
        gameObject.transform.name = nameButton;
        Debug.Log("name = " + transform.GetChild(0).transform.name);
        symbol.text = startSymbol;
    }

    void Update()
    {
        
    }

    public void GetSymbol()
    {
        input.text += symbol.text;
        Debug.Log("symbol = " + symbol.text);
    }
}
