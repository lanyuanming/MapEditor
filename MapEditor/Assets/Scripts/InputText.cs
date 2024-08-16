using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputText : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject text;
    public GameObject inputtext;

    // Use this for initialization
    void Start()
    {
        text.GetComponent<Text>().text = "Text";
        inputtext.GetComponent<InputField>().text = "InputText";
    }
}
