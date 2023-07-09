using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private enum SwitchState
    {
        On,
        Off,
        Respawn
    }
    public Collider theBall;
    public Vector3 rotationDirection;
    public float rotationSpeed;

    private float smooth;
    private bool isOn;

    private SwitchState state;
    private Renderer spawn;

    private void Start()
    {
        spawn = GetComponent<Renderer>();
        Set(false);
        StartCoroutine(RespawnTimerStart(10));
    }

    private void Update()
    {
        smooth = Time.deltaTime * rotationSpeed;
        transform.Rotate(rotationDirection * smooth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == theBall)
        {
            Toggle();
        }
    }
    
    private void Set(bool active)
    {
        if (active == true)
        {
            state = SwitchState.Off;
            spawn.enabled = false;
            StartCoroutine(RespawnTimerStart(10));
        }
        else
        {
            state = SwitchState.On;
            spawn.enabled = true;
            StopAllCoroutines();
        }
    }
    
    private void Toggle()
    {
        if (state == SwitchState.On)
        {
            Set(true);
        }
    }
    
    private IEnumerator Respawn(int times)
    {
        state = SwitchState.Respawn;

        for (int i = 0; i < times; i++)
        {
            spawn.enabled = true;
            yield return new WaitForSeconds(0.5f);
        }
        state = SwitchState.On;

    }

    private IEnumerator RespawnTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Respawn(2));
    }
}
