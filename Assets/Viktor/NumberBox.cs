using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NumberBox : MonoBehaviour
{


    public int index = 0;

    int x = 0;
    int y = 0;
    
    private Action<int,int> swapFunc = null;
    public void Init(int i, int j, int index, Sprite sprite, Action<int,int> swapFunc)
    {
        this.index = index;
        this.GetComponent<SpriteRenderer>().sprite = sprite;
        UpdatePos(i,j);
        this.swapFunc = swapFunc;
    }

    
    
    public void UpdatePos(int i, int j)
    {
        x = i;
        y = j;
        StartCoroutine(Move());
        
    }

    IEnumerator Move()
    {
        float elapseTime = 0;
        float duration = 0.2f;
        Vector2 start = this.gameObject.transform.localPosition;
        Vector2 end = new Vector2(x,y);
        while (elapseTime < duration)
        {
            this.gameObject.transform.localPosition = Vector2.Lerp(start,end,(elapseTime / duration));
            elapseTime += Time.deltaTime;
            yield return null;
        }
        this.gameObject.transform.localPosition = end;
    }
    
    public bool IsEmpty()
    {
        return index == 16;
    }

    public void RotateSquare()
    {
        this.GameObject().transform.Rotate(0.0f, 0.0f, 90.0f);
    }
    
    /*
    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && swapFunc != null)
        {
            swapFunc(x,y);
        }
    }

    private void OnMouseOver()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Pressed r when the mouse is over it");
            this.GameObject().transform.Rotate(0.0f, 0.0f, 90.0f);
        }
    }
    */
}
