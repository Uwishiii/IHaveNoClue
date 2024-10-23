using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EventSpawner : MonoBehaviour
{
    public LoseCondition loseCondition;
    
    [SerializeField] private List<GameObject> events;
    
    private int _randomEvent;
    private int _lastEvent;

    private void Awake()
    {
        //Init to a non-null non-used number so the first event can be random
        _lastEvent = events.Count;
    }

    private void Update()
    {
        // For testing purposes
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DetermineAndSpawnEvent();
        }
    }

    private void DetermineAndSpawnEvent()
    {
        RandomEventSelect();

        if (events[_randomEvent].activeSelf) return;
        
        loseCondition.AddDefcon();
        events[_randomEvent].SetActive(true);
    }

    private void RandomEventSelect()
    {
        _randomEvent = Random.Range(0, events.Count - 1);
        
        //Hopefully this doesn't lead to any crashes :copium:
        while (_randomEvent == _lastEvent)
        {
            _randomEvent = Random.Range(0, events.Count - 1);
        }
        
        _lastEvent = _randomEvent;
    }
}
