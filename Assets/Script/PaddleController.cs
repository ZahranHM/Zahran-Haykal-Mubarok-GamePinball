using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public KeyCode input;
    private float targetPressed;
    private float targetRelease;
    private HingeJoint hinge;
    public int isRight; //Ada kendala membingungkan terkait pergerakan paddle kiri. Jadi perlu variabel ini.
    //Dijelaskan di bagian ReadInput().

    private void Start()
    {
        hinge = GetComponent<HingeJoint>();
        targetPressed = hinge.limits.max;
        targetRelease = hinge.limits.min;
    }

    private void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        JointSpring jointSpring = hinge.spring; 

        //Somehow, Paddle kiri memiliki posisi yang diharapkan jika apabila key tidak ditekan maka posisi
        // yang digunakan yaitu limit max dan apabila key ditekan maka posisi yang digunakan yaitu limit min. 

        //untuk mempersingkat pengerjaan, digunakanlah variabel untuk membedakan paddle kanan atau kiri. 

        if (Input.GetKey(input))
        {
            if (isRight == 1)
            {
                jointSpring.targetPosition = targetPressed;
            }
            else
            {
                jointSpring.targetPosition = targetRelease;
            }
            
        }
        else
        {
            if (isRight == 1)
            {
                jointSpring.targetPosition = targetRelease;
            }
            else
            {
                jointSpring.targetPosition = targetPressed;
            }
            
        }
        hinge.spring = jointSpring;
    }

    private void MovePaddle()
    {
        // Move Paddle Here
    }

}
