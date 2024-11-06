using UnityEngine;

public class Puzzle : MonoBehaviour
{

    public NumberBox BoxPrefab;
    public NumberBox[,] boxes = new NumberBox[4,4];
    public Sprite[] sprites;
    //public GameObject canvas;
    private void Start()
    {
        Init(); 
        RotatePieces();
    }

    private void Update()
    {
        CheckIfPuzzleIsSolved();
    }
    void Init()
    {
        int n = 0;
        for (int y=3;y>=0;y--)
        for (int x = 0; x < 4; x++)
        {
            NumberBox box = Instantiate(BoxPrefab, new Vector3(x,y), Quaternion.identity);
            box.Init(x,y,n+1, sprites[n],ClickToSwap);
            boxes[x,y] = box;
            n++;
        }

    }
    void CheckIfPuzzleIsSolved()
    {
        bool allPiecesCorrect = true;

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (!boxes[i, j].IsEmpty())
                {
                    // Check if the current rotation is correct
                    float currentRotation = boxes[i, j].transform.rotation.eulerAngles.z;
                
                    // Assuming the correct rotation for each piece is 0 degrees
                    if (Mathf.Abs(currentRotation % 360) > 1e-2) // Small margin for floating-point inaccuracies
                    {
                        allPiecesCorrect = false;
                        break;
                    }
                }
            }

            if (!allPiecesCorrect)
            {
                break;
            }
        }

        if (allPiecesCorrect)
        {
            //canvas.SetActive(true);
        }
        else
        {
            //Debug.Log("Puzzle is not solved yet.");
        }
    }
    void RotatePieces()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (!boxes[i, j].IsEmpty())
                {
                    // Rotate the piece randomly by a multiple of 90 degrees
                    int randomRotation = Random.Range(0, 4) * 90;
                    boxes[i, j].transform.rotation = Quaternion.Euler(0, 0, randomRotation);
                }
            }
        }
    }
    void ClickToSwap(int x, int y)
    {
        int dx = getDx(x, y); 
        int dy = getDy(x,y);
        Swap(x,y,dx,dy);
    }
    
    void Swap(int x, int y,int dx,int dy)
    {
        
        
        var from = boxes[x,y];
        var target = boxes[x+dx,y+dy];
        
        boxes[x,y] = target;
        boxes[x+dx,y+dy] = from;
        
        from.UpdatePos(x+dx,y+dy);
        target.UpdatePos(x,y);
    }

    int getDx(int x, int y)
    {
        if (x < 3 && boxes[x + 1, y].IsEmpty())
        {
            return 1;
        }

        if (x > 0 && boxes[x - 1, y].IsEmpty())
        {
            return -1;
            
        }
        else
        {
            return 0;
        }

    }

    int getDy(int x, int y)
    {
        if (y < 3 && boxes[x, y+1].IsEmpty())
        {
            return 1;
        }

        if (y > 0 && boxes[x, y - 1].IsEmpty())
        {
            return -1;
            
        }
        else
        {
            return 0;
        }
    }

    void Shuffle()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (boxes[i, j].IsEmpty())
                {
                    Vector2 pos = getValidMove(i, j);
                    Swap(i,j,(int)pos.x,(int)pos.y);
                }
            }
        }
    }

    private Vector2 lastMove;
    Vector2 getValidMove(int x, int y)
    {
        Vector2 pos = new Vector2();

        do
        {
            int n = Random.Range(0,4);
            if (n == 0)
            
                pos = Vector2.left;
            else if (n == 1)
                pos = Vector2.right;
            else if (n == 2)
                pos = Vector2.up;
            else
                pos = Vector2.down;
            
        }while(!(isValidRange(x +(int)pos.x) && isValidRange((y+(int)pos.y))||  isRepeatMove(pos)));
        lastMove = pos;
        return pos;
    }

    bool isValidRange(int n)
    {
        return n >= 0 && n <= 3;
        
    }

    bool isRepeatMove(Vector2 pos)
    {
        return pos * -1 == lastMove;
    }
}
