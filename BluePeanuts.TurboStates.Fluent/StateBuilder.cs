namespace BluePeanuts.TurboStates.Fluent;

public class StateBuilder
{
    private readonly List<IState> _states = [];

    public StateBuilder State(IState state)
    {
        _states.Add(state);
        return this;
    }

    public IState Build()
    {
        return new ParallelState(_states);
    }


    public StateBuilder Add(IState state)
    {
        _states.Add(state);
        return this;
    }

    public StateBuilder Enter(Action action) => Add(new DelegateState(enterAction: action));

    public StateBuilder Exit(Action action) => Add(new DelegateState(exitAction: action));

    public StateBuilder Process(ProcessDelegate process) => Add(new DelegateState(processAction: process));

    public StateBuilder PhysicsProcess(ProcessDelegate process) => Add(new DelegateState(processAction: process));

    public StateBuilder EnterAsync(Func<CancellationToken, Task> asyncAction) => Add(new TaskState(asyncAction));

    public StateBuilder ProcessOnceWhen(TimeElapsedPredicateDelegate condition, Action action)
    {
        bool called = false;
        return Process((_, timeElapsed) =>
        {
            if (called || !condition(timeElapsed))
                return;
            called = true;
            action();
        });
    }

    public StateBuilder PhysicsProcessOnceWhen(TimeElapsedPredicateDelegate condition, Action action)
    {
        bool called = false;
        return PhysicsProcess((_, timeElapsed) =>
        {
            if (called || !condition(timeElapsed))
                return;
            called = true;
            action();
        });
    }

    public StateBuilder ProcessOnceAfterTimeElapsed(double timeElapsed, Action action) =>
        ProcessOnceWhen((t) => t >= timeElapsed, action);

    public StateBuilder PhysicsProcessOnceAfterTimeElapsed(double timeElapsed, Action action) =>
        PhysicsProcessOnceWhen((t) => t >= timeElapsed, action);
}