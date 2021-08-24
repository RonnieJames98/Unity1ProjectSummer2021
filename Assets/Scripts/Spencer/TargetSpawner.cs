/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetSpawner : MonoBehaviour
{
    public GameObject Spawner1;
    public GameObject Spawner2;
    public GameObject Spawner3;

    public GameObject Target;

    public float timer = 6;
    public TextMeshProUGUI timerText;
    private bool runningTimer;

    private int randomizer;

    void Start()
    {
        runningTimer = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (runningTimer == true)
        {
            timer -= Time.deltaTime;

        }
        else
        {
            randomizer = Random.Range(0,3);
            print("randomizer");

            if (randomizer == 0)
            {
                GameObject clone = Instantiate(Target, Spawner1.transform.position);


            }






            runningTimer == true;
        }
    }
}
*/