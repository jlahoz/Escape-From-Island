using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{

    public TextMeshProUGUI text;
    public string[] lineBoy;
    public string[] lineGirl;
    public int indexBoy;
    public int indexGirl;
    public float typingSpeed;

    public GameObject continueButtonBoy;
    public GameObject continueButtonGirl;
    public GameObject inventoryUI;
    public GameObject dialogsBG;


    private void Update()
    {
        // Control sobre los botones de continuar
        if (text.text == lineBoy[indexBoy])
        {
            continueButtonBoy.SetActive(true);
        }
        if (text.text == lineGirl[indexGirl])
        {
            continueButtonGirl.SetActive(true);
        }
    }

    // Dialogo Girl

    public void girlDialog()
    {
        inventoryUI.SetActive(false); // Control sobre el inventario al iniciar dialogo
        dialogsBG.SetActive(true);
        StartCoroutine(writeGirl());
    }


    IEnumerator writeGirl()
    {
        foreach (char letra in lineGirl[indexGirl].ToCharArray())
        {
            text.text += letra;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void nextLineGirl()
    {
        continueButtonGirl.SetActive(false);

        if (indexGirl < lineGirl.Length - 1)
        {
            indexGirl++;
            text.text = "";
            StartCoroutine(writeGirl());
        }
        else
        {
            text.text = "";
            continueButtonGirl.SetActive(false);
            inventoryUI.SetActive(true);
            dialogsBG.SetActive(false);
        }
    }

    // Dialogo Boy
    public void boyDialog()
    {
        inventoryUI.SetActive(false);
        dialogsBG.SetActive(true);
        StartCoroutine(writeBoy());
    }

    IEnumerator writeBoy()
    {
        foreach(char letra in lineBoy[indexBoy].ToCharArray())
        {
            text.text += letra;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void nextLineBoy()
    {
        continueButtonBoy.SetActive(false);

        if (indexBoy < lineBoy.Length - 1)
        {
            indexBoy++;
            text.text = "";
            StartCoroutine(writeBoy());
        }
        else
        {
            text.text = "";
            continueButtonBoy.SetActive(false);
            inventoryUI.SetActive(true);
            dialogsBG.SetActive(false);
        }
    }   

}
