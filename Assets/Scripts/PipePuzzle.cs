using UnityEngine;

public class PipePuzzle : MonoBehaviour
{
    [SerializeField] private GameObject brokenPipe;
    [SerializeField] private GameObject fixedPipe;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("HammerHead"))
        {
            Instantiate(fixedPipe, brokenPipe.transform);
            Destroy(brokenPipe);
        }
    }
}
