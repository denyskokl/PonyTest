using UnityEngine;
using System.Collections;

public class BaseCharakter : MonoBehaviour
{
    public Coroutine LerpCourotine;

    public virtual void MoveTo(Vector3 targetPosition)
    {
        if(LerpCourotine != null)
        {
            StopCoroutine(LerpCourotine);
            LerpCourotine = null;
        }
        LerpCourotine = StartCoroutine(LerpObject(targetPosition, transform.position, 2f));
    }
    IEnumerator LerpObject(Vector3 targetPosition, Vector3 startPosition, float duration)
    {
        float i = 0;
        float rate = 1f / duration;

        while (i < 1)
        {
            i += Time.deltaTime * rate;
            transform.position = Vector3.Lerp(startPosition, targetPosition, i);
            if (targetPosition == transform.position)
            {
                Debug.Log("FINISH LERP");
                yield break;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
