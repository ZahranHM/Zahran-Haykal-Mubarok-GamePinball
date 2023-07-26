using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    public Collider theBall;
    public GameObject trapPrefab;
    public Transform trapParent;
    public int maxTraps = 3;
    public float trapSpawnInterval = 3f;
    public float trapDespawnInterval = 10f;

    private List<GameObject> activeTraps = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(TrapSpawnRoutine());
    }
   

    private IEnumerator Respawn()
    {
        for (int i = 0; i < maxTraps; i++)
        {
            GameObject newTrap = Instantiate(trapPrefab, RandomTrapPosition(), Quaternion.identity, trapParent);
            activeTraps.Add(newTrap);
            yield return new WaitForSeconds(trapSpawnInterval);
        }
    }

    private IEnumerator TrapDespawn(GameObject trap)
    {
        yield return new WaitForSeconds(trapDespawnInterval);
        activeTraps.Remove(trap);
        Destroy(trap);
    }

    private IEnumerator TrapSpawnRoutine()
    {
        yield return new WaitForSeconds(1f); // Add initial delay of 10 seconds.

        while (true)
        {
            if (activeTraps.Count < maxTraps)
            {
                GameObject newTrap = Instantiate(trapPrefab, RandomTrapPosition(), Quaternion.identity, trapParent);
                activeTraps.Add(newTrap);
                StartCoroutine(TrapDespawn(newTrap));
            }

            yield return new WaitForSeconds(trapSpawnInterval);
        }
    }

    private Vector3 RandomTrapPosition()
    {
        // Generate a random position for the trap.
        // Modify this based on your scene layout and where you want the traps to spawn.
        float x = Random.Range(-5.5f, 3.5f);
        float z = Random.Range(-4f, 7f);
        return new Vector3(x, 0.5f, z);
    }
}
