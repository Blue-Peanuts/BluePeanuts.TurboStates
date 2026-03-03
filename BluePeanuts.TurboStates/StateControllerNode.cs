using Godot;

namespace BluePeanuts.TurboStates;

public sealed class StateControllerNode : Node
{
    private readonly IStateController _stateController;

    public StateControllerNode() : this(new StateController())
    {
    }

    internal StateControllerNode(IStateController stateController)
    {
        _stateController = stateController;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        _stateController.Process(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        _stateController.PhysicsProcess(delta);
    }

    public void SetState(IState? state) => _stateController.SetState(state);

    public void EmptyState() => _stateController.EmptyState();
}