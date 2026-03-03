namespace BluePeanuts.TurboStates;

public sealed class StateController
{
    private IState? _currentState;

    public void SetState(IState? state)
    {
        _currentState?.Exit();

        _currentState = state;
        _currentState?.Enter();
    }

    public void EmptyState()
    {
        SetState(null);
    }

    public void Process(double delta)
    {
        _currentState?.Process(delta);
    }

    public void PhysicsProcess(double delta)
    {
        _currentState?.PhysicsProcess(delta);
    }
}
