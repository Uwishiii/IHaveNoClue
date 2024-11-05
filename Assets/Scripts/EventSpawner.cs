using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EventSpawner : MonoBehaviour
{
    public LoseCondition loseCondition;
    
    [SerializeField] private List<GameObject> events;
    
    private int _randomEvent;
    private int _lastEvent;
    
    private bool _missionStarted = false;
    
    [SerializeField] private GameObject fuse1;
    [SerializeField] private GameObject fuse1Pos;
    [SerializeField] private GameObject fuse2;
    [SerializeField] private GameObject fuse2Pos;
    [SerializeField] private GameObject fuse3;
    [SerializeField] private GameObject fuse3Pos;
    private IEnumerator _enumerator;

    private void Start()
    {
        _enumerator = Spawn();
    }

    private void Awake()
    {
        //Init to a non-null non-used number so the first event can be random
        _lastEvent = events.Count;
    }

    private void Update()
    {
        // For testing purposes
        if (Input.GetKeyDown(KeyCode.Space) && _missionStarted)
        { 
            StartCoroutine(_enumerator);
        }
    }
    
    IEnumerator Spawn ()
    {
        while(true)
        {
            yield return new WaitForSeconds (Random.Range (10, 15));
            DetermineAndSpawnEvent();
        }
    }

    private void DetermineAndSpawnEvent()
    {
        RandomEventSelect();

        if (events[_randomEvent].activeSelf) return;
        
        loseCondition.AddDefcon();
        
        //To handle the fixed Fusebox not deactivating for some reason.
        if (_randomEvent == 6)
        {
            GameObject.FindGameObjectWithTag("fixedFuseBox").SetActive(false);
            
            Instantiate(fuse1, fuse1Pos.transform.position, fuse1Pos.transform.rotation);
            Instantiate(fuse2, fuse2Pos.transform.position, fuse2Pos.transform.rotation);
            Instantiate(fuse3, fuse3Pos.transform.position, fuse3Pos.transform.rotation);
        }
        events[_randomEvent].SetActive(true);
    }

    private void RandomEventSelect()
    {
        _randomEvent = Random.Range(0, events.Count);
        
        //Hopefully this doesn't lead to any crashes :copium:
        while (_randomEvent == _lastEvent)
        {
            _randomEvent = Random.Range(0, events.Count);
        }
        
        _lastEvent = _randomEvent;
    }
}
