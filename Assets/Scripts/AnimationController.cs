using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator ParentAnimator;
    public Animator AdolescentAnimator;
    
    // This function is responsible for starting the animation of the character
    public void StartCharacterAnimation(string character, string animation)
    {
        switch (character)
        {
            case "parent":
                StartAnimation(ParentAnimator, animation);
                HandleCharacterPosition(ParentAnimator, character, animation);
                break;

            case "adolescent":
                StartAnimation(AdolescentAnimator, animation);
                HandleCharacterPosition(AdolescentAnimator, character, animation);
                break;
        }
    }

    // This function stops all previous animations and starts the new animation
    private void StartAnimation(Animator animator, string animation)
    {
        StopAllPreviousAnimations(animator);
        animator.SetBool(animation, true);
    }

    // This function stops all previous animations
    private void StopAllPreviousAnimations(Animator animator)
    {
        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            animator.SetBool(parameter.name, false);
        }
    }

    // This function stops all dialog animations (these animations are used for dialogues only)
    public void StopPreviousTalkingAnimations()
    {
        ParentAnimator.SetBool("talking", false);
        ParentAnimator.SetBool("yelling", false);
        ParentAnimator.SetBool("arguing", false);
        AdolescentAnimator.SetBool("talking", false);
        AdolescentAnimator.SetBool("yelling", false);
    }

    // Walking variables
    private Quaternion walkingRotation = Quaternion.Euler(0, 200f, 0);
    private readonly Dictionary<string, Quaternion> idleRotations = new Dictionary<string, Quaternion>
    {
        { "parent", Quaternion.Euler(0, 123.6f, 0) },
        { "adolescent", Quaternion.Euler(0, 219.9f, 0) }
    };

    // Sitting variables
    private readonly Dictionary<string, Vector3> sitPositions = new Dictionary<string, Vector3>
    {
        { "parent", new Vector3(-2.19f, -3.82f, 11.89f) },
        { "adolescent", new Vector3(1.84f, -3.88f, 11.89f) }
    };
    private readonly Dictionary<string, Vector3> idlePositions = new Dictionary<string, Vector3>
    {
        { "parent", new Vector3(-1.56f, -4.97f, 5f) },
        { "adolescent", new Vector3(1.56f, -4.97f, 5f) }
    };

    // This function is responsible for changing the character's position based on the animation
    private void HandleCharacterPosition(Animator animator, string character, string animation)
    {
        // If the character is walking, the character's rotation will be changed to the walking rotation
        if (animation == "walk")
        {
            animator.GetComponent<Transform>().rotation = walkingRotation;
        }

        // If the character is sitting, the character's position will be changed to the sitting position
        else if ((animation == "sit") && sitPositions.TryGetValue(character, out Vector3 sittingPosition))
        {
            animator.GetComponent<Transform>().position = sittingPosition;
        }

        // If the character is idle, the character's position and rotation will be changed to the idle position and rotation
        else if (idleRotations.TryGetValue(character, out Quaternion idleRotation) && idlePositions.TryGetValue(character, out Vector3 idlePosition))
        {
            animator.GetComponent<Transform>().position = idlePosition;
            animator.GetComponent<Transform>().rotation = idleRotation;
        }
    }
}
