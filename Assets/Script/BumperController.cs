using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    private enum SwitchColor
    {
        Color1,
        Color2,
        Color3
    }
    public Collider theBall;
    public float multiplier;

    // feature change color bumper
    public Material Material1;
    public Material Material2;
    public Material Material3;

    private SwitchColor state;
    private Renderer renderer;

    private Animator animator;

    private void Start()
    {
        renderer = GetComponent<Renderer>();

        Set(1);

        animator = GetComponent<Animator>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == theBall)
        {
            Rigidbody theBallRig = theBall.GetComponent<Rigidbody>();
            theBallRig.velocity *= multiplier;

            animator.SetTrigger("hit");

            Toggle();
        }
        else
        {
            
        }
    }

    private void Set(int active)
    {
        if (active == 1)
        {
            state = SwitchColor.Color1;
            renderer.material = Material1;
        }
        else if (active == 2)
        {
            state = SwitchColor.Color2;
            renderer.material = Material2;
        }
        else
        {
            state = SwitchColor.Color3;
            renderer.material = Material3;
        }
    }
    private void Toggle()
    {
        if (state == SwitchColor.Color1)
        {
            Set(2);
        }
        else if (state == SwitchColor.Color2)
        {
            Set(3);
        }
        else
        {
            Set(1);
        }
    }
}
