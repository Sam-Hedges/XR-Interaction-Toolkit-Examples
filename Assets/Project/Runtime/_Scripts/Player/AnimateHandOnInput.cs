using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class AnimateHandOnInput : MonoBehaviour
{
    [SerializeField] private InputActionProperty pinchAnimationAction;
    [SerializeField] private InputActionProperty gripAnimationAction;
    private Animator animator;
    private static readonly int Trigger = Animator.StringToHash("Trigger");
    private static readonly int Grip = Animator.StringToHash("Grip");

    void Awake() {
        animator = GetComponent<Animator>();
    }
    
    void Update() {
        SetPinchAnimationValue(pinchAnimationAction.action.ReadValue<float>());
        SetGripAnimationValue(gripAnimationAction.action.ReadValue<float>());
    }

    void SetPinchAnimationValue(float triggerValue) {
        animator.SetFloat(Trigger, triggerValue);
    }
    
    void SetGripAnimationValue(float triggerValue) {
        animator.SetFloat(Grip, triggerValue);
    }
}
