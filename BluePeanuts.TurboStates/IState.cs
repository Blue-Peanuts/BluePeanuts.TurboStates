namespace BluePeanuts.TurboStates;

public interface IState
{
    public void Enter();
    public void Exit();
    public void Process(double delta);
    public void PhysicsProcess(double delta);
}