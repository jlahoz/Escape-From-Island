using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{

    public TextMeshProUGUI text;
    public string[] line;
    public int index;
    public float typingSpeed;

    public GameObject continueButton;
    public GameObject inventoryUI;

    public void boyDialog()
    {
        inventoryUI.SetActive(false);
        StartCoroutine(write());
    }

    private void Update()
    {
        if(text.text == line[index])
        {
            continueButton.SetActive(true);
        }
    }

    IEnumerator write()
    {
        foreach(char letra in line[index].ToCharArray())
        {
            text.text += letra;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void siguienteFrase()
    {
        continueButton.SetActive(false);

        if (index < line.Length - 1)
        {
            index++;
            text.text = "";
            StartCoroutine(write());
        }
        else
        {
            text.text = "";
            continueButton.SetActive(false);
            inventoryUI.SetActive(true);
        }
    }   

}
