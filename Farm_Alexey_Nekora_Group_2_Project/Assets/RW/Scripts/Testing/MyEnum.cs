using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//PERECHISLENIYA
public enum State { Man = 1, Woman = 1, Gender = 0 }

public enum Presidents : int
{ 
    Федорыч = 60,
    Петя = 55,
    Вова = 45
}


public class MyEnum : MonoBehaviour
{
    State state = State.Man; // zadaem znachenie startovoe
    Presidents fPresidents = Presidents.Федорыч; // zadaem znachenie startovoe


    private void Awake()
    {
        print(state);
        state = State.Gender;

        

    }

    private void Start()
    {

        //int i = (int)days; //convertacija v int chto bi uvidet index
        //print(i);

        if (fPresidents == Presidents.Федорыч)
        {
            print("Shapki");
        }
        if ((int)fPresidents >= 60)
        {
            print("Star");
        }
        else
        {
            print("Ne tak i Star");
        }


        //print(state);
        //if (state == State.Man)
        //{
        //    print("MUZH");
        //}
        //else if (state == State.Woman)
        //{
        //    print("ZHEN");
        //}
        //else if (state == State.Gender)
        //{
        //    print("GEN");
        //}
    }


}