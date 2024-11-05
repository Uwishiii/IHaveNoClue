using UnityEngine;

public class PipePuzzle : MonoBehaviour
{
    [SerializeField] private GameObject brokenPipe;
    [SerializeField] private GameObject fixedPipe;
    [SerializeField] private GameObject hammerHead;

    private void OnCollisionEnter(Collision other)
    {
        // Maybe should change this to tag comparison for multiple hammers but eh... whatever.
        if (other.gameObject == hammerHead)
        {
            Debug.Log("Hammer");
            fixedPipe.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
