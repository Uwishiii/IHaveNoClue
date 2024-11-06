using UnityEngine;

public class LoseCondition : MonoBehaviour
{
    [SerializeField] public int defconCount;
    [SerializeField] public int defconMax;

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

    private void GameOver()
    {
        // Placeholder, this will do stuff once we have a main menu / mission select
        Debug.Log("Game Over");
    }
}
