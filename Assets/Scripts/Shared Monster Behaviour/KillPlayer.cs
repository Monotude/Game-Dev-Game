using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    [SerializeField] private GameOverScreen GameOverScreen;

    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private GameObject mainCamera;
    private GameObject player;
    private GameObject flashLight;
    private GameObject uVLight;
    [SerializeField] private float jumpScareTime;
    [SerializeField] private GameObject jumpscareCamera;
    [SerializeField] private GameObject jumpscareLight;

    private void StopMonster()
    {
        if (navMeshAgent != null)
        {
            navMeshAgent.isStopped = true;
            navMeshAgent.velocity = new Vector3();
        }
    }

    private void DisablePlayer()
    {
        mainCamera.SetActive(false);
        player.SetActive(false);
        flashLight.SetActive(false);
        uVLight.SetActive(false);
    }

    private void ReadyAnimation()
    {
        jumpscareCamera.SetActive(true);
        jumpscareLight.SetActive(true);
        animator.SetTrigger("jumpscare");
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        mainCamera = GameObject.FindWithTag("MainCamera");
        player = GameObject.FindWithTag("Player");
        flashLight = GameObject.FindWithTag("Flashlight");
        uVLight = GameObject.FindWithTag("UV Light");
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SaveManager.Instance.SaveProgress();
            SaveManager.Instance.SaveConfig();
            StopMonster();
            DisablePlayer();
            ReadyAnimation();
            StartCoroutine(GameOver());
        }
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(jumpScareTime);
        GameOverScreen.Setup();
    }
}
