using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ModalWindowPanel : MonoBehaviour
{
    [SerializeField]
    public GameObject panelObject;
    [SerializeField]
    public Text questionTextBoxObject;
    [SerializeField]
    public Text hintTextObject;
    [SerializeField]
    public Button confirmButtonObject;
    [SerializeField]
    public Sprite[] imageSources;
    [SerializeField]
    public Image imageToDisplayOn;

    private Action onConfirmAction;

    public void Start()
    {
        hintTextObject.text = questionTextBoxObject.text; //setting the text of the question to show in the dialog box
        switch (SubtractFractions.RandomCommonDenominator)
        {
            case 1:
                imageToDisplayOn.sprite = imageSources[0];
                break;
            case 2:
                imageToDisplayOn.sprite = imageSources[1];
                break;
            case 3:
                imageToDisplayOn.sprite = imageSources[2];
                break;
            case 4:
                imageToDisplayOn.sprite = imageSources[3];
                break;
            case 5:
                imageToDisplayOn.sprite = imageSources[4];
                break;
            case 6:
                imageToDisplayOn.sprite = imageSources[5];
                break;
            case 7:
                imageToDisplayOn.sprite = imageSources[6];
                break;
            case 8:
                imageToDisplayOn.sprite = imageSources[7];
                break;
            case 9:
                imageToDisplayOn.sprite = imageSources[8];
                break;
            default:
                imageToDisplayOn.sprite = imageSources[0];
                break;
        }
    }

    public void Update()
    {
        hintTextObject.text = questionTextBoxObject.text; //setting the text of the question to show in the dialog box
        switch (SubtractFractions.RandomCommonDenominator) //Calling the denominator of the to check what fraction hint image to display
        {
            case 1:
                imageToDisplayOn.sprite = imageSources[0];
                break;
            case 2:
                imageToDisplayOn.sprite = imageSources[1];
                break;
            case 3:
                imageToDisplayOn.sprite = imageSources[2];
                break;
            case 4:
                imageToDisplayOn.sprite = imageSources[3];
                break;
            case 5:
                imageToDisplayOn.sprite = imageSources[4];
                break;
            case 6:
                imageToDisplayOn.sprite = imageSources[5];
                break;
            case 7:
                imageToDisplayOn.sprite = imageSources[6];
                break;
            case 8:
                imageToDisplayOn.sprite = imageSources[7];
                break;
            case 9:
                imageToDisplayOn.sprite = imageSources[8];
                break;
            default:
                imageToDisplayOn.sprite = imageSources[0];
                break;
        }
    }

    public void Confirm()
    {
        onConfirmAction?.Invoke();
        //EventSystem.current.currentSelectedGameObject
        Debug.Log("SubtractFractions.RandomCommonDenominator is " + SubtractFractions.RandomCommonDenominator);
        panelObject.SetActive(false);
    }
}
