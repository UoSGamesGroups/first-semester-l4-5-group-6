﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//Created By Daniel Beales
//13/12/2016 - Last Modified
//Add This Script to the Spawner you would like the objects to spawn from
//All old code and notes are at the bottom in a region
//3-4 hours spent


public class ObjectSpawner : MonoBehaviour
{
    #region [GameObjects]
    public GameObject Crate;
    public GameObject Spawner;
    #endregion

    #region [WAVES]
    public float MaxWaves;//how many waves the designers want to spawn
    private float currentWave;//The Current wave the game is on.
    public bool EndWave; //LAst Wave - Set in editor
    private bool roundActive; //If there is a wave Currently Active
    #endregion

    #region [Spawn Settings]
    public float SpawnSpeed; //How quick the crates shoudl spawn between each other.
    public int LaunchSpeed = 100000;
    private int crateCount; //Something to monitor how many crates have been spawned - Staticistcs maybe?
    public bool roundStarted;
    #endregion

    #region [TIMERS]
    public float FirstRoundTimer; // Timer for the first round of the game; can be edited. 
    public float MaxTimer; //Highest point in timer - eg. 60 second timer - 60 is max.
    #endregion

    #region [Text Objects]
    public Text DialogBox;
    public Text WaveCountertext;
    public Text WaveText;
    #endregion

    #region [MISC]
    public KeyCode SpawnKey;
    #endregion


    void Start()
    {
      
    }
    void Whatwave()
    {
        if(currentWave == 0) //GameStart
        {
            currentWave++;
            roundActive = true; //Make First Round Start
            WaveText.text = "Wave " + currentWave + " Starting";
            MaxTimer = FirstRoundTimer;
            SpawnSpeed = (SpawnSpeed * currentWave);            
            StartCoroutine(SpawnWaves(SpawnSpeed, MaxTimer));
        }
        else if(currentWave > 1 || currentWave != MaxWaves) //check the current wave is above one, But not above the max amount of waves set.
        {
            roundActive = true;
            MaxTimer = (FirstRoundTimer + currentWave);
            SpawnSpeed = (SpawnSpeed * (currentWave));
            WaveText.text = "Wave " + currentWave + " starting";
            StartCoroutine(SpawnWaves(SpawnSpeed, MaxTimer));
            WaveText.text = "Wave " + currentWave + " has finished";
        }
        else if(currentWave == MaxWaves) //so there is an end to the game. 
        {
            roundActive = true;
            MaxTimer = (FirstRoundTimer + currentWave);
            SpawnSpeed = (SpawnSpeed * (currentWave / 5));
            WaveText.text = "Wave " + currentWave + " starting";
            StartCoroutine(SpawnWaves(SpawnSpeed, MaxTimer));
            WaveText.text = "Wave " + currentWave + " has finished";
            EndWave = true;
        }
    }

    IEnumerator SpawnWaves(float SpawnSpeed, float MaxTimer)
    {        
        WaveText.text = "Wave " + currentWave;
        for (int i = 0; i < MaxTimer; i++)
        {
            GameObject cubeSpawn = (GameObject)Instantiate(Crate, new Vector3(Spawner.transform.position.x, Spawner.transform.position.y, Spawner.transform.position.z), transform.rotation);
            cubeSpawn.GetComponent<Rigidbody>().AddForce(0, 250, 1 * Time.deltaTime * 100000);
            crateCount++;
            yield return new WaitForSeconds(SpawnSpeed);           
        }
    }
    
    // Update is called once per frame
    void Update()
    {        
        WaveCountertext.text = "Wave: " + currentWave;
        DialogBox.text = "Please Press " + SpawnKey + " To Start the Game";
        if (Input.GetKeyDown(SpawnKey))
        {
            if(roundActive == false)
            {
                if(currentWave == 0)
                {               
                    Whatwave();                
                    StopCoroutine(SpawnWaves(SpawnSpeed, MaxTimer));
                    roundActive = false;
                }
                else if(currentWave >= 1)
                {
                    float nextwave = currentWave + 1;
                    DialogBox.text = "";
                    DialogBox.text = "Please press " + SpawnKey + "To start wave" + nextwave;                                  
                    Whatwave();
                    currentWave++;
                    roundActive = false;
                }
            }
        }
       
       if (EndWave == true)
        {
            //Celebrate;
        }
    }
}

#region [oldCode]
//IEnumerator SpawnWaves(float time)
//{
//    yield return new WaitForSeconds(SpawnSpeed);
//    while (true)
//    {
//        for (int i = 0; i < count; i++)
//        {
//            GameObject cubeSpawn = (GameObject)Instantiate(Crate, new Vector3(Spawner.transform.position.x, Spawner.transform.position.y, Spawner.transform.position.z), transform.rotation);
//            cubeSpawn.GetComponent<Rigidbody>().AddForce(0, 250, 1 * Time.deltaTime * 100000);
//            yield return new WaitForSeconds(SpawnSpeed);
//            count++;
//        }
//        yield return new WaitForSeconds(waveWait);
//    }
//}
//static SpwanCrate(float spawntimings)
//{
//    GameObject cubeSpawn = (GameObject)Instantiate(Crate, new Vector3(Spawner.transform.position.x, Spawner.transform.position.y, Spawner.transform.position.z), transform.rotation);
//    cubeSpawn.GetComponent<Rigidbody>().AddForce(0, 250, 1 * Time.deltaTime * 100000);
//    count++;

//    yield return new WaitForSeconds(spawntimings);
//}

// public Crate crateprefab;
// Use this for initialization
//void Start()
//{
//    //StartCoroutine(SpawnWaves());
//    cubeSpawn();
//    // GameObject cubeSpawn = (GameObject)Instantiate(Crate);
//    if (count != 1)
//    {

//        // Instantiate(Crate);

//        // Crate.GetComponent<Rigidbody>().AddForce(Vector3.up);
//        // count++;
//    }
//}
//NOT USEDANYMORE
//public int hazardCount;
// public float spawnWait;
//// public float startWait;
// public float waveWait;
//public GameObject spawnobject;
//public Vector3 spawnValues;

//IEnumerator Start()
//{
//yield return new WaitForSeconds(time);

// }
//public void cubeSpawn()
//{

//    GameObject cubeSpawn = (GameObject)Instantiate(Crate, new Vector3(Spawner.transform.position.x, Spawner.transform.position.y, Spawner.transform.position.z), transform.rotation);
//    cubeSpawn.GetComponent<Rigidbody>().AddForce(0, 250, 1 * Time.deltaTime * 100000);
//   count++;

//}
#endregion
