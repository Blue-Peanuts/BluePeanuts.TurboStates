using Godot;

namespace BluePeanuts.TurboStates.Fluent;

public class TaskState : IState
{
    private readonly Func<CancellationToken, Task> _enterAsyncAction;

    private CancellationTokenSource? _cts;

    public TaskState(Func<CancellationToken, Task> enterAsyncAction)
    {
        _enterAsyncAction = enterAsyncAction ?? throw new ArgumentNullException(nameof(enterAsyncAction));
    }

    public void Enter()
    {
        _ = EnterTask();
    }

    private async Task EnterTask()
    {
        try
        {
            _cts = new CancellationTokenSource();
            await _enterAsyncAction(_cts.Token);
        }
        catch (TaskCanceledException)
        {
        }
    }

    public void Exit()
    {
        _cts?.Cancel();
    }

    public void Process(double delta)
    {
    }

    public void PhysicsProcess(double delta)
    {
    }
}