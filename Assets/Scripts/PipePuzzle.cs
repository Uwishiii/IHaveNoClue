using System;
using UnityEngine;

public class PipePuzzle : MonoBehaviour
{
    public LoseCondition loseCondition;

    private int _hitCount = 0;
    
    [SerializeField] private GameObject brokenPipe;
    [SerializeField] private GameObject fixedPipe;
    [SerializeField] private GameObject hammerHead;

    private void Start()
    {
        fixedPipe.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        // Maybe should change this to tag comparison for multiple hammers but eh... whatever.
        if (other.gameObject == hammerHead)
        {
            _hitCount++;

            if (_hitCount >= 3)
            {
                _hitCount = 0;
                
                Debug.Log("Hammer");
                
                loseCondition.RemoveDefcon();
                
                fixedPipe.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}
