using System;

public class Cow : BaseCharakter
{
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
            () =>
            {
                MoveTo(CharacterSpawnManager.Instance.RandomCorelPosition());
            });
    }

    public void MoveToDog(Dog dog, Action OnComplete = null)
    {
        MoveTo(CharacterSpawnManager.Instance.RandomPositionAroundDog(dog), OnComplete);
    }
}
