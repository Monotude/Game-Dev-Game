using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private MonsterStateMachine monsterStateMachine;
    private GameObject mainCamera;
    private GameObject player;
    private GameObject flashLight;
    private GameObject uVLight;
    [SerializeField] private float jumpScareTime;
    [SerializeField] private GameObject jumpscareCamera;
    [SerializeField] private GameObject jumpscareLight;

    private void StopMonster()
    {
        navMeshAgent.isStopped = true;
        navMeshAgent.velocity = new Vector3();
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
        monsterStateMachine.enabled = false;
        jumpscareCamera.SetActive(true);
        jumpscareLight.SetActive(true);
        animator.SetTrigger("jumpscare");
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        monsterStateMachine = GetComponent<MonsterStateMachine>();
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
            StopMonster();
            DisablePlayer();
            ReadyAnimation();
            StartCoroutine(ReloadScene());
        }
    }

    private IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(jumpScareTime);
        SceneManager.LoadScene("Game");
    }
}
