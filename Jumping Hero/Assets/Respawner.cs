using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EventMultiplier {
    public float timeStamp;
    public float value;
}

[System.Serializable]
public class EventInterval {
    public float timeStamp;
    public float value;
}

public class Respawner : MonoBehaviour
{
    public GameObject platform;
    public float interval;
    private float lastRespawn;
    public bool active;
    public float multiplier;
    public EventMultiplier[] eventsMultiplier;
    private int currentEventM;
    public EventMultiplier[] eventsInterval;
    private int currentEventI;
    private float clock;
    // Start is called before the first frame update
    void Start()
    {
        lastRespawn = Time.time;
       
    }

    // Update is called once per frame
    void Update()
    {
        clock += Time.deltaTime;
        if(active && Time.time - lastRespawn > interval) {
            GameObject p = Instantiate(platform);
            p.transform.position = transform.position;
            p.GetComponent<Plataforma>().multiplier = multiplier;
            lastRespawn = Time.time;
        }
        if (currentEventM < eventsMultiplier.Length && clock > eventsMultiplier[currentEventM].timeStamp) {
            multiplier = eventsMultiplier[currentEventM].value;
            currentEventM++;
        }
        if (currentEventI < eventsInterval.Length && clock > eventsInterval[currentEventI].timeStamp) {
            interval = eventsInterval[currentEventI].value;
            currentEventM++;
        }
    }
}
