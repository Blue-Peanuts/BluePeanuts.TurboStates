using NSubstitute;
using twodog.xunit;

namespace BluePeanuts.TurboStates.Tests;

[Collection("Godot")]
public class StateControllerNodeTests
{
    private readonly GodotHeadlessFixture _godot;

    public StateControllerNodeTests(GodotHeadlessFixture godot)
    {
        _godot = godot;
    }

    [Fact]
    public void Process_IsCalledDuringIteration()
    {
        var controller = Substitute.For<IStateController>();
        var node = new StateControllerNode(controller);

        _godot.Tree.Root.AddChild(node);
        _godot.GodotInstance.Iteration();

        controller.Received(1).Process(Arg.Any<double>());

        node.QueueFree();
    }

    [Fact]
    public void PhysicsProcess_IsCalledDuringIteration()
    {
        var controller = Substitute.For<IStateController>();
        var node = new StateControllerNode(controller);

        _godot.Tree.Root.AddChild(node);
        _godot.GodotInstance.Iteration();

        controller.Received().PhysicsProcess(Arg.Any<double>());

        node.QueueFree();
    }

    [Fact]
    public void SetState_CallsControllerSetState()
    {
        var controller = Substitute.For<IStateController>();
        var node = new StateControllerNode(controller);

        var state = Substitute.For<IState>();

        node.SetState(state);
        controller.Received(1).SetState(state);

        // Also test EmptyState
        node.EmptyState();
        controller.Received(1).SetState(null);
    }
}
