using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float bounds;

    private float direction;
    private bool isPress;


   
    void Update()
    {
        if (isPress)
        {


            if (((transform.position.x > -bounds) && (direction == 1f)) || ((transform.position.x < bounds) && (direction == -1f)))
            {
                transform.Translate(Vector3.left * speed * direction * Time.deltaTime);
            }
        }

        //if (((transform.position.x > -bounds) && (direction == 1f)) || ((transform.position.x < bounds) && (direction == -1f)))
        //{
        //    transform.Translate(Vector3.left * speed * direction * Time.deltaTime);
        //}


        //if ((transform.position.x > -bounds) && (direction ==1f))
        //{
        //    transform.Translate(Vector3.left * speed * direction * Time.deltaTime);
        //}
        //else if ((transform.position.x < bounds) && (direction == -1f))

        //{
        //    transform.Translate(Vector3.left * speed * direction * Time.deltaTime);
        //}





    }

    public void PressLeft()
    {
        direction = 1f;
        isPress = true;
    }

    public void PressRight()
    {
        direction = -1;
        isPress = true;
    }

    public void StopPress()
    {
        //direction = 0f;
        isPress = false;
    }




}
