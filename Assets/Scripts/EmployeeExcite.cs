using UnityEngine;

public class EmployeeExcite : MonoBehaviour
{
    private Animator _animator;
    private static readonly int Excite = Animator.StringToHash("Excite");
    public string acceptableLetters;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void TriggerEmployee()
    {
        _animator.SetTrigger(Excite);
    }
}
