using UnityEngine;

public class LoseCondition : MonoBehaviour
{
    [SerializeField] public int defconCount;
    [SerializeField] public int defconMax;
    [SerializeField] private GameObject _canvas;
    [SerializeField] private GameObject _tablet;

    private void Update()
    {
        if (defconMax <= defconCount)
        {
            GameOver();
        }
    }

    public void AddDefcon()
    {
        defconCount++;
    }

    public void RemoveDefcon()
    {
        defconCount--;
    }

    public void ButtonPressed()
    {
        _tablet.SetActive(false);
    }

    private void GameOver()
    {
        _canvas.SetActive(true);
        Debug.Log("Game Over");
    }
}
