using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour {



    //NOT USEDANYMORE
    //public int hazardCount;
   // public float spawnWait;
   //// public float startWait;
   // public float waveWait;
//public GameObject spawnobject;
    //public Vector3 spawnValues;


    public GameObject Crate;
    public GameObject Spawner;
    
    
    public int count;

    public Vector3 spawnSpot = new Vector3(0, 2, 0);

    public int LaunchSpeed = 100000;


   // public Crate crateprefab;
    // Use this for initialization
    void Start()
    {
        //StartCoroutine(SpawnWaves());
        cubeSpawn();
       // GameObject cubeSpawn = (GameObject)Instantiate(Crate);
        if (count != 1)
        {
           
           // Instantiate(Crate);
           
           // Crate.GetComponent<Rigidbody>().AddForce(Vector3.up);
           // count++;
        }
    }
    public void cubeSpawn()
    {
        
        GameObject cubeSpawn = (GameObject)Instantiate(Crate, new Vector3(17, 6, 26), transform.rotation);
        cubeSpawn.GetComponent<Rigidbody>().AddForce(-1500, 500, 0 * Time.deltaTime * 100000);
        count++;
    }



    //IEnumerator SpawnWaves()
    //{
    //    yield return new WaitForSeconds(startWait);
    //    while (true)
    //    {
    //        for (int i = 0; i < hazardCount; i++)
    //        {
    //            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.y), spawnValues.y, spawnValues.z);
    //            Quaternion spawnRotation = Quaternion.identity;
    //            Instantiate(Crate, spawnPosition, spawnRotation);
    //            yield return new WaitForSeconds(spawnWait);

    //        }
    //        yield return new WaitForSeconds(waveWait);

    //    }

    //}

    // Update is called once per frame
    void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            cubeSpawn();

        }





        }



}
