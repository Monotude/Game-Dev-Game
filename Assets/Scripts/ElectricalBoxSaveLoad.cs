using UnityEngine;

public class ElectricalBoxSaveLoad : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private int electricalBoxNumber;

    private void Start()
    {
        animator = GetComponent<Animator>();

        if (ObjectiveManager.Instance.Objective.IsElectricalBoxOn(electricalBoxNumber))
        {
            animator.Play("LeverDown");
        }
    }
}
