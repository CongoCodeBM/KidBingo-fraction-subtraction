using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;
using System.Linq;
using Fractions; //This is a package from Nuget.org that we are using it in our code: https://www.nuget.org/packages/Fractions

using UnityEngine.EventSystems;

//This is an extension class that helps us create an extension method that allows us to shuffle a list 
public static class Extensions
{
    private static System.Random randomizer = new System.Random();

    public static void Shuffle<T>(this IList<T> values)
    {
        for (int i = values.Count - 1; i > 0; i--)
        {
            int k = randomizer.Next(i + 1);
            T value = values[k];
            values[k] = values[i];
            values[i] = value;
        }
    }
}


public class SubtractFractions : MonoBehaviour
{
    [SerializeField] List<AudioSource> gameSounds = new List<AudioSource>();

    public GameObject questionObject, buttonObject1, buttonObject2, buttonObject3, buttonObject4
        , buttonObject5, buttonObject6, buttonObject7, buttonObject8, buttonObject9
        , buttonObject10, buttonObject11, buttonObject12, buttonObject13, buttonObject14
        , buttonObject15, buttonObject16, buttonObject17, buttonObject18, buttonObject19
        , buttonObject20, buttonObject21, buttonObject22, buttonObject23, buttonObject24
        , buttonObject25;

    public UnityEngine.UI.Button button1, button2, button3, button4, button5, button6, button7, button8
        , button9, button10, button11, button12, button13, button14, button15, button16
        , button17, button18, button19, button20, button21, button22, button23, button24
        , button25;

    public Text questionTextObject, textObject1, textObject2, textObject3, textObject4, textObject5, textObject6
        , textObject7, textObject8, textObject9, textObject10, textObject11, textObject12
        , textObject13, textObject14, textObject15, textObject16, textObject17, textObject18
        , textObject19, textObject20, textObject21, textObject22, textObject23, textObject24
        , textObject25;

    public Stack FractionAStack = new Stack(); //this stack will contain the fraction on the left side 
    public Stack FractionBStack = new Stack(); //this stack will contain the fraction on the right side
    public Stack ResultStack = new Stack(); //this stack will contain the result of fraction subtraction operations from elements of the previous two stacks
    Stack CheckGreaterFractionStack = new Stack(); //this stack will help us store the value of CheckGreaterFraction

    public List<Fraction> FractionAList = new List<Fraction>(); //this list will contain a record of the left fraction even after they have been popped out of their stack
    public List<Fraction> FractionBList = new List<Fraction>(); //this list will contain a record of the right fraction after they have been popped out of their stack
    public List<Fraction> ResultList = new List<Fraction>(); //this list will contain a record of the subtraction result fraction after they have been popped out of their stack

    static int RandomNumerator_A = 0; //Random.Range(1, 9); //this will generate a random number between 1 and 9, and it will be the numerator of the fraction on the left side
    static int RandomNumerator_B = 0; //Random.Range(1, 9); //this will generate a random number between 1 and 9, and it will be the numerator of the fraction on the right side
    static int RandomCommonDenominator = 1; //Random.Range(1, 9); //this will generate a random number between 1 and 9, and it will be the denominator for both fractions

    public static Fraction FractionA = new Fraction(RandomNumerator_A, RandomCommonDenominator);//this is a fraction on the left side, created with the values of RandomNumerator_left and CommonDenominator
    public static Fraction FractionB = new Fraction(RandomNumerator_B, RandomCommonDenominator); //this is a fraction on the left side, created with the values of  RandomNumerator_right and RandomCommonDenominator
    public static Fraction ResultFraction = FractionA.Subtract(FractionB); //this is a fraction created from subtracting RandomNumerator_right from RandomNumerator_left

    decimal CheckGreaterFraction = 0; //this will help calculate the difference between fraction A and B, which we will use to determine where fraction A or B should go in order to avoid negative results 

    public int[,] matchedBingoPattern = new int[,] { {1,2,3,4,5}, {6,7,8,9,10},{11,12,13,14,15},{16,17,18,19,20},
                                                     {21,22,23,24,25}, {1,7,13,19,25}, {1,6,11,16,21},{2,7,12,17,22},
                                                     {3,8,13,18,23}, {4,9,14,19,24}, {5,10,15,20,25}, {5,9,13,17,21}
                                                   };

    void AddElementsToTheirStacks()
    {
        for (int i = 0; i < 25; i++)
        {
            RandomNumerator_A = Random.Range(1, 9);
            RandomNumerator_B = Random.Range(1, 9);
            RandomCommonDenominator = Random.Range(1, 9);

            FractionA = new Fraction(RandomNumerator_A, RandomCommonDenominator);
            FractionB = new Fraction(RandomNumerator_B, RandomCommonDenominator);
            CheckGreaterFraction = FractionA.ToDecimal() - FractionB.ToDecimal();

            CheckGreaterFractionStack.Push(CheckGreaterFraction);

            if (CheckGreaterFraction < 0) ResultFraction = FractionB.Subtract(FractionA);
            else ResultFraction = FractionA.Subtract(FractionB);
            
            FractionAStack.Push(FractionA);
            FractionAList.Add(FractionA);
            FractionBStack.Push(FractionB);
            FractionBList.Add(FractionB);
            ResultStack.Push(ResultFraction);
            ResultList.Add(ResultFraction);
        }

        ResultList.Shuffle(); //shuffling the list that will be used to display the answers
    }    



    // Start is called before the first frame update
   void Start()
   {
        AddElementsToTheirStacks();
        ShowQuestionAndAnswerOptionsToScreen();
        Button btn1 = button1.GetComponent<Button>();
        btn1.onClick.AddListener(ToDoWhenButtonClicked);
        Button btn2 = button2.GetComponent<Button>();
        btn2.onClick.AddListener(ToDoWhenButtonClicked);
        Button btn3 = button3.GetComponent<Button>();
        btn3.onClick.AddListener(ToDoWhenButtonClicked);
        Button btn4 = button4.GetComponent<Button>();
        btn4.onClick.AddListener(ToDoWhenButtonClicked);
        Button btn5 = button5.GetComponent<Button>();
        btn5.onClick.AddListener(ToDoWhenButtonClicked);
        Button btn6 = button6.GetComponent<Button>();
        btn6.onClick.AddListener(ToDoWhenButtonClicked);
        Button btn7 = button7.GetComponent<Button>();
        btn7.onClick.AddListener(ToDoWhenButtonClicked);
        Button btn8 = button8.GetComponent<Button>();
        btn8.onClick.AddListener(ToDoWhenButtonClicked);
        Button btn9 = button9.GetComponent<Button>();
        btn9.onClick.AddListener(ToDoWhenButtonClicked);
        Button btn10 = button10.GetComponent<Button>();
        btn10.onClick.AddListener(ToDoWhenButtonClicked);
        Button btn11 = button11.GetComponent<Button>();
        btn11.onClick.AddListener(ToDoWhenButtonClicked);
        Button btn12 = button12.GetComponent<Button>();
        btn12.onClick.AddListener(ToDoWhenButtonClicked);
        Button btn13 = button13.GetComponent<Button>();
        btn13.onClick.AddListener(ToDoWhenButtonClicked);
        Button btn14 = button14.GetComponent<Button>();
        btn14.onClick.AddListener(ToDoWhenButtonClicked);
        Button btn15 = button15.GetComponent<Button>();
        btn15.onClick.AddListener(ToDoWhenButtonClicked);
        Button btn16 = button16.GetComponent<Button>();
        btn16.onClick.AddListener(ToDoWhenButtonClicked);
        Button btn17 = button17.GetComponent<Button>();
        btn17.onClick.AddListener(ToDoWhenButtonClicked);
        Button btn18 = button18.GetComponent<Button>();
        btn18.onClick.AddListener(ToDoWhenButtonClicked);
        Button btn19 = button19.GetComponent<Button>();
        btn19.onClick.AddListener(ToDoWhenButtonClicked);
        Button btn20 = button20.GetComponent<Button>();
        btn20.onClick.AddListener(ToDoWhenButtonClicked);
        Button btn21 = button21.GetComponent<Button>();
        btn21.onClick.AddListener(ToDoWhenButtonClicked);
        Button btn22 = button22.GetComponent<Button>();
        btn22.onClick.AddListener(ToDoWhenButtonClicked);
        Button btn23 = button23.GetComponent<Button>();
        btn23.onClick.AddListener(ToDoWhenButtonClicked);
        Button btn24 = button24.GetComponent<Button>();
        btn24.onClick.AddListener(ToDoWhenButtonClicked);
        Button btn25 = button25.GetComponent<Button>();
        btn25.onClick.AddListener(ToDoWhenButtonClicked);

    }

    //This method is used to populate the UI with responses on buttons, and questions on the specified text area
    void ShowQuestionAndAnswerOptionsToScreen()
    {
        questionTextObject = questionObject.GetComponent<Text>();
        textObject1 = buttonObject1.GetComponent<Text>();
        textObject2 = buttonObject2.GetComponent<Text>();
        textObject3 = buttonObject3.GetComponent<Text>();
        textObject4 = buttonObject4.GetComponent<Text>();
        textObject5 = buttonObject5.GetComponent<Text>();
        textObject6 = buttonObject6.GetComponent<Text>();
        textObject7 = buttonObject7.GetComponent<Text>();
        textObject8 = buttonObject8.GetComponent<Text>();
        textObject9 = buttonObject9.GetComponent<Text>();
        textObject10 = buttonObject10.GetComponent<Text>();
        textObject11 = buttonObject11.GetComponent<Text>();
        textObject12 = buttonObject12.GetComponent<Text>();
        textObject13 = buttonObject13.GetComponent<Text>();
        textObject14 = buttonObject14.GetComponent<Text>();
        textObject15 = buttonObject15.GetComponent<Text>();
        textObject16 = buttonObject16.GetComponent<Text>();
        textObject17 = buttonObject17.GetComponent<Text>();
        textObject18 = buttonObject18.GetComponent<Text>();
        textObject19 = buttonObject19.GetComponent<Text>();
        textObject20 = buttonObject20.GetComponent<Text>();
        textObject21 = buttonObject21.GetComponent<Text>();
        textObject22 = buttonObject22.GetComponent<Text>();
        textObject23 = buttonObject23.GetComponent<Text>();
        textObject24 = buttonObject24.GetComponent<Text>();
        textObject25 = buttonObject25.GetComponent<Text>();

        //Display the answer options
        textObject1.text = ResultList.ElementAt(0).ToString(); //ResultStack.Pop().ToString();
        textObject2.text = ResultList.ElementAt(1).ToString(); //ResultStack.Pop().ToString();
        textObject3.text = ResultList.ElementAt(2).ToString(); //ResultStack.Pop().ToString();
        textObject4.text = ResultList.ElementAt(3).ToString(); //ResultStack.Pop().ToString();
        textObject5.text = ResultList.ElementAt(4).ToString(); //ResultStack.Pop().ToString();
        textObject6.text = ResultList.ElementAt(5).ToString(); //ResultStack.Pop().ToString();
        textObject7.text = ResultList.ElementAt(6).ToString(); //ResultStack.Pop().ToString();
        textObject8.text = ResultList.ElementAt(7).ToString(); //ResultStack.Pop().ToString();
        textObject9.text = ResultList.ElementAt(8).ToString(); //ResultStack.Pop().ToString();
        textObject10.text = ResultList.ElementAt(9).ToString(); //ResultStack.Pop().ToString();
        textObject11.text = ResultList.ElementAt(10).ToString(); //ResultStack.Pop().ToString();
        textObject12.text = ResultList.ElementAt(11).ToString(); //ResultStack.Pop().ToString();
        textObject13.text = ResultList.ElementAt(12).ToString(); //ResultStack.Pop().ToString();
        textObject14.text = ResultList.ElementAt(13).ToString(); //ResultStack.Pop().ToString();
        textObject15.text = ResultList.ElementAt(14).ToString(); //ResultStack.Pop().ToString();
        textObject16.text = ResultList.ElementAt(15).ToString(); //ResultStack.Pop().ToString();
        textObject17.text = ResultList.ElementAt(16).ToString(); //ResultStack.Pop().ToString();
        textObject18.text = ResultList.ElementAt(17).ToString(); //ResultStack.Pop().ToString();
        textObject19.text = ResultList.ElementAt(18).ToString(); //ResultStack.Pop().ToString();
        textObject20.text = ResultList.ElementAt(19).ToString(); //ResultStack.Pop().ToString();
        textObject21.text = ResultList.ElementAt(20).ToString(); //ResultStack.Pop().ToString();
        textObject22.text = ResultList.ElementAt(21).ToString(); //ResultStack.Pop().ToString();
        textObject23.text = ResultList.ElementAt(22).ToString(); //ResultStack.Pop().ToString();
        textObject24.text = ResultList.ElementAt(23).ToString(); //ResultStack.Pop().ToString();
        textObject25.text = ResultList.ElementAt(24).ToString(); //ResultStack.Pop().ToString();

        //Display the question. If the the fraction on the left is less than the fraction on the right, we swap their position on the display
        var c = System.Convert.ToDecimal(CheckGreaterFractionStack.Peek().ToString());

        //if (System.Convert.ToDecimal(CheckGreaterFractionStack.Peek().ToString()) < 0)
        if (c < 0) //questionTextObject.text = "Fraction A - Fraction B = \n" + c;
        {
            questionTextObject.text = FractionBStack.Peek().ToString() + " - "
                               + FractionAStack.Peek().ToString() + "\n=? ";
        }
        else //questionTextObject.text = "Fraction B - Fraction A = \n" + c;
            questionTextObject.text = FractionAStack.Peek().ToString() + " - "
                              + FractionBStack.Peek().ToString() + "\n= ?";
    }


    void ToDoWhenButtonClicked()
    {
        var c = System.Convert.ToDecimal(CheckGreaterFractionStack.Peek().ToString());
        var textOnCurrentButton = GameObject.Find(EventSystem.current.currentSelectedGameObject.name).GetComponent<Button>().GetComponentInChildren<Text>().text;

        string currentButtonName = EventSystem.current.currentSelectedGameObject.name;
        int currentButtonNumber = int.Parse(string.Concat(currentButtonName.Where(char.IsDigit)));

        Debug.Log("ResultStack.Pop().ToString() : " + ResultStack.Peek().ToString());
        Debug.Log("textOnCurrentButton.ToString() : " + textOnCurrentButton.ToString());
        Debug.Log("FractionAStack count : " + FractionAStack.Count);
        Debug.Log("FractionBStack count : " + FractionBStack.Count);
        Debug.Log("Clicked button name: " + currentButtonName);
        Debug.Log("Clicked button number: " + currentButtonNumber);

        if (c < 0)
        {
            if (ResultStack.Pop().ToString().Equals(textOnCurrentButton.ToString()))
            {
                FractionAStack.Pop();
                FractionBStack.Pop();
                CheckGreaterFractionStack.Pop();
                c = System.Convert.ToDecimal(CheckGreaterFractionStack.Peek().ToString());

                //Play sound for correct answer
                gameSounds[0].Play();

                //Change display image of button to lamb image on top of button and make button not clickable
                GameObject.Find(EventSystem.current.currentSelectedGameObject.name).GetComponent<Button>().interactable = false;


                //Add 1 to success count


                //Show next question
                if (c < 0) questionTextObject.text = FractionBStack.Peek().ToString() + " - "
                            + FractionAStack.Peek().ToString() + "\n= ? ";
                else questionTextObject.text = FractionAStack.Peek().ToString() + " - "
                            + FractionBStack.Peek().ToString() + "\n= ? ";
            }

            else
            {
                FractionAStack.Pop();
                FractionBStack.Pop();
                CheckGreaterFractionStack.Pop();
                c = System.Convert.ToDecimal(CheckGreaterFractionStack.Peek().ToString());

                //destroy button, make a sound and prevent corresponding fractions from displaying
                EventSystem.current.currentSelectedGameObject.SetActive(false); //UI button destroyed
                gameSounds[1].Play(); //Sound playing for wrong answer

                //show next question
                if (c < 0) questionTextObject.text = FractionBStack.Peek().ToString() + " - "
                                   + FractionAStack.Peek().ToString() + "\n=? ";
                else questionTextObject.text = FractionAStack.Peek().ToString() + " - "
                            + FractionBStack.Peek().ToString() + "\n= ? ";

            }
                
        }

        else
        {

            if (ResultStack.Pop().ToString().Equals(textOnCurrentButton.ToString()))
            {
                FractionAStack.Pop();
                FractionBStack.Pop();
                CheckGreaterFractionStack.Pop();
                c = System.Convert.ToDecimal(CheckGreaterFractionStack.Peek().ToString());

                //Play sound for correct answer
                gameSounds[0].Play();

                //Change display image of button to lamb image on top of button and make button not clickable
                GameObject.Find(EventSystem.current.currentSelectedGameObject.name).GetComponent<Button>().interactable = false; //making button not clickable

                //Add 1 to success count

                //display next question
                if (c >= 0) questionTextObject.text = FractionAStack.Peek().ToString() + " - "
                                  + FractionBStack.Peek().ToString() + "\n= ?";
                else questionTextObject.text = FractionBStack.Peek().ToString() + " - "
                                  + FractionAStack.Peek().ToString() + "\n= ?";
            }

            else
            {
                FractionAStack.Pop();
                FractionBStack.Pop();
                CheckGreaterFractionStack.Pop();
                c = System.Convert.ToDecimal(CheckGreaterFractionStack.Peek().ToString());

                //destroy button, make a sound and remove corresponding fractions from Stack
                EventSystem.current.currentSelectedGameObject.SetActive(false); //UI button destroyed
                gameSounds[1].Play(); //Sound playing for wrong answer

                //display next question
                if (c >= 0) questionTextObject.text = FractionAStack.Peek().ToString() + " - "
                                  + FractionBStack.Peek().ToString() + "\n= ?";
                else questionTextObject.text = FractionBStack.Peek().ToString() + " - "
                                  + FractionAStack.Peek().ToString() + "\n= ?";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


}
