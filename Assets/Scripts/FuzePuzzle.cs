using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuzePuzzle : MonoBehaviour
{
    public LoseCondition loseCondition;
    
    private int count = 0;
    [SerializeField] private GameObject blownFuseBox;
    [SerializeField] private GameObject fixedFuseBox;
    //[SerializeField] private GameObject fuse1;
    //[SerializeField] private GameObject fuse2;
    //[SerializeField] private GameObject fuse3;

    // Update is called once per frame
    void Update()
    {
        if (count == 3)
        {
            Destroy(GameObject.FindGameObjectWithTag("fuse1"));
            Destroy(GameObject.FindGameObjectWithTag("fuse2"));
            Destroy(GameObject.FindGameObjectWithTag("fuse3"));

            count = 0;
            
            loseCondition.RemoveDefcon();
            
            fixedFuseBox.SetActive(true);
            blownFuseBox.SetActive(false);
        }
    }

    public void CountUp()
    {
        count++;
    }
}
