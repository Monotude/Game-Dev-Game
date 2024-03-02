using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    private ProgressManager progressManager;

    private void Start()
    {
        progressManager = GameObject.FindWithTag("Progress Manager").GetComponent<ProgressManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SaveManager.Instance.SaveProgress(progressManager);
            SceneManager.LoadScene("Section 1");
        }
    }
}
