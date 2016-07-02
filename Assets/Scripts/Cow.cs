using System;
using UnityEngine;

public class Cow : BaseCharakter {


    public void Unsubscribe(Dog dog)
    {
        dog.OnMoveToDog -= MoveToDog;
        dog.OnCorral -= MoveCorral;
    }

    public void Subscribe(Dog dog)
    {
        dog.OnMoveToDog += MoveToDog;
        dog.OnCorral += MoveCorral;
    }
    public void MoveCorral(Dog dog)
    {
        Unsubscribe(dog);
        MoveTo(CharacterSpawnManager.Instance.CoralEnter.position,
            () => {

                MoveTo(CharacterSpawnManager.Instance.RandomCorelPosition());
        });
    }

    public void MoveToDog(Dog dog, Action OnComplete = null)
    {
      MoveTo(  CharacterSpawnManager.Instance.RandomPositionAroundDog(dog), OnComplete);
    }

    public override void MoveTo(Vector3 targetPosition, Action OnComplete = null)
    {
        var direction = targetPosition - transform.position;
        var localDirection = transform.InverseTransformDirection(direction);

        Debug.Log(localDirection.x + "`````x````````" + localDirection.y + "`````y````````" + localDirection.z + "`````z````````");

        base.MoveTo(targetPosition, OnComplete);
    }
}
