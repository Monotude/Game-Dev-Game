using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class KillPlayer : MonoBehaviour
{
    private ProgressManager progressManager;
    private Animator animator;
    [SerializeField] private float jumpScareTime;
    private GameObject mainCam;
    [SerializeField] private GameObject jumpCam;
    private GameObject player;
    private GameObject flashLight;
    [SerializeField] private GameObject pointLight;
    private MonsterStateMachine monsterStateMachine;
    private NavMeshAgent monsterNav;


    private void Start()
    {
        progressManager = GameObject.FindWithTag("Progress Manager").GetComponent<ProgressManager>();
        animator = GetComponent<Animator>();
        monsterStateMachine = GetComponent<MonsterStateMachine>();
        monsterNav = GetComponent<NavMeshAgent>();
        mainCam = GameObject.Find("Main Camera");;
        player = GameObject.FindWithTag("Player");
        flashLight = GameObject.Find("Flashlight");


    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            monsterNav.isStopped = true;
            monsterNav.velocity = new Vector3();

            SaveManager.Instance.SaveProgress(progressManager);
            StartCoroutine(deathRoutine());
        }
    }


    IEnumerator deathRoutine()
    {


        flashLight.SetActive(false);
        pointLight.SetActive(true);

        monsterStateMachine.enabled = false;
        player.SetActive(false);

        jumpCam.SetActive(true);
        mainCam.SetActive(false);
        animator.SetTrigger("jumpscare");
        yield return new WaitForSeconds(jumpScareTime);
        SceneManager.LoadScene("Game");
    }


}
