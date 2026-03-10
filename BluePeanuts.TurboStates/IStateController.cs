namespace BluePeanuts.TurboStates;

public interface IStateController
{
    public void SetState(IState? state);

    public void Process(double delta);

    public void PhysicsProcess(double delta);
}