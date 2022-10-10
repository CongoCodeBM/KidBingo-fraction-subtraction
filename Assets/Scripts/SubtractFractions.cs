using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;
using Fractions;
using UnityEngine.UIElements;

public class SubtractFractions : MonoBehaviour
{
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

       
    }    

    // Start is called before the first frame update
   void Start()
   {
        AddElementsToTheirStacks();
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
        textObject1.text = ResultStack.Pop().ToString();
        textObject2.text = ResultStack.Pop().ToString();
        textObject3.text = ResultStack.Pop().ToString();
        textObject4.text = ResultStack.Pop().ToString();
        textObject5.text = ResultStack.Pop().ToString();
        textObject6.text = ResultStack.Pop().ToString();
        textObject7.text = ResultStack.Pop().ToString();
        textObject8.text = ResultStack.Pop().ToString();
        textObject9.text = ResultStack.Pop().ToString();
        textObject10.text = ResultStack.Pop().ToString();
        textObject11.text = ResultStack.Pop().ToString();
        textObject12.text = ResultStack.Pop().ToString();
        textObject13.text = ResultStack.Pop().ToString();
        textObject14.text = ResultStack.Pop().ToString();
        textObject15.text = ResultStack.Pop().ToString();
        textObject16.text = ResultStack.Pop().ToString();
        textObject17.text = ResultStack.Pop().ToString();
        textObject18.text = ResultStack.Pop().ToString();
        textObject19.text = ResultStack.Pop().ToString();
        textObject20.text = ResultStack.Pop().ToString();
        textObject21.text = ResultStack.Pop().ToString();
        textObject22.text = ResultStack.Pop().ToString();
        textObject23.text = ResultStack.Pop().ToString();
        textObject24.text = ResultStack.Pop().ToString();
        textObject25.text = ResultStack.Pop().ToString();

        //Display the question. If the the fraction on the left is less than the fraction on the right, we swap their position on the display
        var c = System.Convert.ToDecimal(CheckGreaterFractionStack.Peek().ToString());

        //if (System.Convert.ToDecimal(CheckGreaterFractionStack.Peek().ToString()) < 0)
        if (c < 0) //questionTextObject.text = "Fraction A - Fraction B = \n" + c;
        {
            questionTextObject.text = FractionBStack.Pop().ToString() + " - "
                               + FractionAStack.Pop().ToString() + "\n=? "; 
        }
        else //questionTextObject.text = "Fraction B - Fraction A = \n" + c;
            questionTextObject.text = FractionAStack.Pop().ToString() + " - "
                              + FractionBStack.Pop().ToString() + "\n= ?";

    }



    // Update is called once per frame
    void Update()
    {

    }


}
