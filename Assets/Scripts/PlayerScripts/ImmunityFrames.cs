//using System.Collections;
//using UnityEngine;

//public class ImmunityFrames : MonoBehaviour
//{
//    private bool isInvincible = false;

//    // Coroutine for becoming temporarily invincible
//    private IEnumerator BecomeTemporarilyInvincible(float duration)
//    {
//        isInvincible = true;
//        yield return new WaitForSeconds(duration);
//        isInvincible = false;
//    }

//    // Method to activate invincibility frames for a specified duration
//    public void ActivateInvincibility(float duration)
//    {
//        if (!isInvincible)
//        {
//            StartCoroutine(BecomeTemporarilyInvincible(duration));
//        }
//    }

//    // Method to check if the object is currently invincible
//    public bool IsInvincible()
//    {
//        return isInvincible;
//    }
//}

