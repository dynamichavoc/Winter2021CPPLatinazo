using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupSpawn : MonoBehaviour
{

    public Transform spawnOne;
    public Transform spawnTwo;
    public Transform spawnThree;
    public Transform spawnFour;
    public Transform spawnFive;

    public Pickups collectiblePrefab;
    public Pickups powerupPrefab;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Spawn 1");
        var firstSpawn = Random.Range(1, 6);
        if (firstSpawn % 2 == 0)
        {
            Pickups pickupInstanceOne = Instantiate(powerupPrefab, spawnOne.position, spawnOne.rotation);
        }
        else
        {
            Pickups pickupInstanceOne = Instantiate(collectiblePrefab, spawnOne.position, spawnOne.rotation);
        }
        Debug.Log("Spawn 2");
        var secondSpawn = Random.Range(1, 6);
        if (secondSpawn % 2 == 0)
        {
            Pickups pickupInstanceTwo = Instantiate(powerupPrefab, spawnTwo.position, spawnOne.rotation);
        }
        else
        {
            Pickups pickupInstanceTwo = Instantiate(collectiblePrefab, spawnTwo.position, spawnOne.rotation);
        }
        Debug.Log("Spawn 3");
        var thirdSpawn = Random.Range(1, 6);
        if (thirdSpawn % 2 == 0)
        {
            Pickups pickupInstanceThree = Instantiate(powerupPrefab, spawnThree.position, spawnOne.rotation);
        }
        else
        {
            Pickups pickupInstanceThree = Instantiate(collectiblePrefab, spawnThree.position, spawnOne.rotation);
        }
        Debug.Log("Spawn 4");
        var fourthSpawn = Random.Range(1, 6);
        if (fourthSpawn % 2 == 0)
        {
            Pickups pickupInstanceFour = Instantiate(powerupPrefab, spawnFour.position, spawnOne.rotation);
        }
        else
        {
            Pickups pickupInstanceFour = Instantiate(collectiblePrefab, spawnFour.position, spawnOne.rotation);
        }
        Debug.Log("Spawn 5");
        var fifthSpawn = Random.Range(1, 6);
        if (fifthSpawn % 2 == 0)
        {
            Pickups pickupInstanceFive = Instantiate(powerupPrefab, spawnFive.position, spawnOne.rotation);
        }
        else
        {
            Pickups pickupInstanceFive = Instantiate(collectiblePrefab, spawnFive.position, spawnOne.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
