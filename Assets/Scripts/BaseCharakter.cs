using UnityEngine;
using System;
using DG.Tweening;

public class BaseCharakter : MonoBehaviour
{
    public virtual void MoveTo(Vector3 targetPosition, Action OnComplete = null)
    {
        DOTween.Kill(GetInstanceID());
        transform.DOMove(new Vector3(targetPosition.x, 0, targetPosition.z), 10f).SetId(GetInstanceID()).SetSpeedBased(true).OnComplete(() =>
        {
            if (OnComplete != null)
            {
                OnComplete();
            }
        });
    }
}
