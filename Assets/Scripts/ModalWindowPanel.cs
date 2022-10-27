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
        switch (SubtractFractions.denominatorFractionA)
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

        switch (SubtractFractions.denominatorFractionA) //Calling the denominator of the first fraction to check what fraction hint image to display
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

        Debug.Log("SubtractFractions.denominatorFractionA is " + SubtractFractions.denominatorFractionA);
        switch (SubtractFractions.denominatorFractionA)
        {
            case 1:
                imageToDisplayOn.sprite = imageSources[0];
                panelObject.SetActive(false);
                break;
            case 2:
                imageToDisplayOn.sprite = imageSources[1];
                panelObject.SetActive(false);
                break;
            case 3:
                imageToDisplayOn.sprite = imageSources[2];
                panelObject.SetActive(false);
                break;
            case 4:
                imageToDisplayOn.sprite = imageSources[3];
                panelObject.SetActive(false);
                break;
            case 5:
                imageToDisplayOn.sprite = imageSources[4];
                panelObject.SetActive(false);
                break;
            case 6:
                imageToDisplayOn.sprite = imageSources[5];
                panelObject.SetActive(false);
                break;
            case 7:
                imageToDisplayOn.sprite = imageSources[6];
                panelObject.SetActive(false);
                break;
            case 8:
                imageToDisplayOn.sprite = imageSources[7];
                panelObject.SetActive(false);
                break;
            case 9:
                imageToDisplayOn.sprite = imageSources[8];
                panelObject.SetActive(false);
                break;
            default:
                imageToDisplayOn.sprite = imageSources[0];
                panelObject.SetActive(false);
                break;
        }
    }
}