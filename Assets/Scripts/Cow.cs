using System;
using UnityEngine;

public class Cow : BaseCharakter {

    public void Unsubscribe(Dog dog)
    {
        dog.OnMoveTo -= MoveTo;
        dog.OnCorral -= MoveCorral;
    }

    public void Subscribe(Dog dog)
    {
        dog.OnMoveTo += MoveTo;
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
}
