using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class ConvertNumberAlphabet : MonoBehaviour
{
    string Result = "";
    List<string> MyNumberListString = new List<string>();
    GameObject MyObject;
    private void Awake()
    {
        MyObject = this.gameObject;
    }
    
    public void StartConvert(string MyNumber)
    {
        MyNumberListString = new List<string>();
        Result = "";
        string MyNumberString = MyNumber;
        string MyNumberStringExtra = "a";
        bool hasExtra = false;

        if (MyNumberString.Length <= 1)
        {
            MyNumberListString.Add(MyNumberString);
            return;
        }
        
        if (MyNumberString.Length % 2 == 1)
        {
            hasExtra = true;
            MyNumberStringExtra = MyNumberString.Substring(MyNumberString.Length - 1, 1);
            MyNumberString = MyNumberString.Substring(0, MyNumberString.Length - 1);
        }

        int Count = MyNumberString.Length / 2;
        
        for (int i = 0; i < Count; i++)
        {
            string currentString = MyNumberString.Substring(i * 2, 2);
            MyNumberListString.Add(currentString);
        }

        if (hasExtra == true)
        {
            MyNumberListString.Add(MyNumberStringExtra);
        }


        CheckTotal();
    }
    void CheckTotal()
    {
        bool isRepeat = false;
        bool isAddMore = false;
        int MySub = 0;
        int currentIndex = 0;

        for (int i = 0; i < MyNumberListString.Count; i++)
        {
            currentIndex = i;
            var item = MyNumberListString[i];
            int aNumber = int.Parse(item);
            if (aNumber > 52)
            {
                MySub = aNumber - 52;

                if (i < MyNumberListString.Count - 1)
                {
                    isRepeat = true;
                    break;
                }
                else
                {
                    isAddMore = true;
                    break;
                }
            }
        }

        
        if (isAddMore == false)
        {
            if (isRepeat == true)
            {
                int NextIndex = currentIndex + 1;

                MyNumberListString[currentIndex] = "52";
                int nextNumber = int.Parse(MyNumberListString[NextIndex]) + MySub;
                MyNumberListString[NextIndex] = nextNumber.ToString();

                CheckTotal();
            }
            else
            {
                ConvertListString();
            }
        }
        else
        {
            MyNumberListString[currentIndex] = "52";
            MyNumberListString.Add(MySub.ToString());
            CheckTotal();
        }
    }
    void ConvertListString()
    {
        foreach (string item in MyNumberListString) 
        {
            var ResultEach = ConvertCharNumber(int.Parse(item));
            Result = Result + ResultEach;
        }

        //Debug.Log(Result);
        CustomEvent.Trigger(MyObject,"ConvertNumberResultDone", Result);
    }
    char ConvertCharNumber(int number)
    {
        char c = '0';
        
        if (number > 26 && number <= 52)
        {
            var newNumber = number - 26;
            c = (char)((int)'a' + newNumber - 1);
            c = Char.ToUpper(c);
        }
        if (number <= 26 && number > 0)
        {
            c = (char)((int)'a' + number - 1);
        }
        if (number <= 0)
        {
            c = (char)'6';
        }

        if (c == 'I')
        {
            c = '1';
        }
        if (c == 'o')
        {
            c = '2';
        }
        if (c == 'l')
        {
            c = '3';
        }
        if (c == 'O')
        {
            c = '4';
        }
        if (c == 'Z')
        {
            int randomN = Random.Range(5, 10);
            if (randomN == 5)
                c = '5';
            if (randomN == 6)
                c = '6';
            if (randomN == 7)
                c = '7';
            if (randomN == 8)
                c = '8';
            if (randomN == 9)
                c = '9';
        }

        return c;
    }
}
