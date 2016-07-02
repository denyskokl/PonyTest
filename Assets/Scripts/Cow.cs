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
        Vector3 direction  = Vector3.Normalize( transform.InverseTransformDirection(targetPosition - transform.position));

        //Debug.Log(" dir x: "+ direction.x+ " dir y: " + direction.y + " dir z: " + direction.z  );
        if (direction.y > 0)
        {

            // it's moving up
        }
        else
        {
            // it's moving down
        }

       

        float ang = Vector2.Angle(transform.position, targetPosition);
        Vector3 cross = Vector3.Cross(transform.position, targetPosition);

        Debug.Log(ang + " ang" + cross.x + " cross.x  + " + cross.y + "  + cross.u " + cross.z + " --croezse z");
        base.MoveTo(targetPosition, OnComplete);
    }


}
