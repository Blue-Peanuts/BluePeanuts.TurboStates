namespace BluePeanuts.TurboStates.Fluent;

public class DelegateState : IState
{
    private readonly Action? _enterAction;
    private readonly Action? _exitAction;
    private readonly ProcessDelegate? _processAction;
    private readonly ProcessDelegate? _physicsProcessAction;

    private double _processTimeElapsed = 0;
    private double _physicsProcessTimeElapsed = 0;

    public DelegateState(
        Action? enterAction = null,
        Action? exitAction = null,
        ProcessDelegate? processAction = null,
        ProcessDelegate? physicsProcessAction = null)
    {
        _enterAction = enterAction;
        _exitAction = exitAction;
        _processAction = processAction;
        _physicsProcessAction = physicsProcessAction;
    }

    public void Enter()
    {
        _processTimeElapsed = 0;
        _physicsProcessTimeElapsed = 0;
        _enterAction?.Invoke();
    }

    public void Exit()
    {
        _exitAction?.Invoke();
    }

    public void Process(double delta)
    {
        _processTimeElapsed += delta;
        _processAction?.Invoke(delta, _processTimeElapsed);
    }

    public void PhysicsProcess(double delta)
    {
        _physicsProcessTimeElapsed += delta;
        _physicsProcessAction?.Invoke(delta, _physicsProcessTimeElapsed);
    }
}