namespace BluePeanuts.TurboStates.Fluent;

public class ParallelState : IState
{
    private readonly List<IState> _states;

    private bool _active = false;

    public ParallelState(params List<IState> states)
    {
        _states = states;
    }

    public void Enter()
    {
        _active = true;
        _states.ForEach((s) => s.Enter());
    }

    public void Exit()
    {
        _active = false;
        _states.ForEach((s) => s.Exit());
    }

    public void Process(double delta)
    {
        foreach (var state in _states)
        {
            state.Process(delta);
            if (!_active) return;
        }
    }

    public void PhysicsProcess(double delta)
    {
        foreach (var state in _states)
        {
            state.PhysicsProcess(delta);
            if (!_active) return;
        }
    }
}