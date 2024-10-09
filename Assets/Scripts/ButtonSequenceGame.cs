using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ButtonSequenceGame : MonoBehaviour
{
    public GameObject starIcon;
    public GameObject squareIcon;
    public GameObject circleIcon;
    private List<GameObject> shapeList = new List<GameObject>();
    public List<GameObject> shapePosList;

    private int _count;

    // Start is called before the first frame update
    void Start()
    {
        _count = 0;

        shapeList.Add(starIcon);
        shapeList.Add(squareIcon);
        shapeList.Add(circleIcon);
        
        ShuffleSequence();
        InstantiateSequence();
    }

    // Update is called once per frame
    void Update()
    {
        if (_count >= shapeList.Count)
        {
            _count = 0;
            
            DestroyIconSequence();
            ShuffleSequence();
            InstantiateSequence();
        }
    }

    private List<GameObject> ShuffleSequence()
    {
        for (int i = 0; i < shapeList.Count; i++)
        {
            GameObject temp = shapeList[i];
            int randomIndex = Random.Range(i, shapeList.Count);
            shapeList[i] = shapeList[randomIndex];
            shapeList[randomIndex] = temp;
        }
        return shapeList;
    }

    private void InstantiateSequence()
    {
        for (int i = 0; i < shapeList.Count; i++)
        {
            Instantiate(shapeList[i], shapePosList[i].transform);
        }
    }

    private void DestroyIconSequence()
    {
        Destroy(starIcon);
        Destroy(squareIcon);
        Destroy(circleIcon);
    }
    
    public void pressedStar()
    {
        if (shapeList[_count] == starIcon)
        {
            _count++;
        }
        else
        {
            _count = 0;
            
            DestroyIconSequence();
            ShuffleSequence();
            InstantiateSequence();
        }
    }
    
    public void pressedSquare()
    {
        if (shapeList[_count] == squareIcon)
        {
            _count++;
        }
        else
        {
            _count = 0;

            DestroyIconSequence();
            ShuffleSequence();
            InstantiateSequence();
        }
    }
    
    public void pressedCircle()
    {
        if (shapeList[_count] == circleIcon)
        {
            _count++;
        }
        else
        {
            _count = 0;

            DestroyIconSequence();
            ShuffleSequence();
            InstantiateSequence();
        }
    }
}
