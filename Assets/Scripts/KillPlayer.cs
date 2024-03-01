using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ObjectiveSave.Instance.SaveObjective();
            SceneManager.LoadScene("Section 1");
        }
    }
}
