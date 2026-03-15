using NSubstitute;
using Xunit;

namespace BluePeanuts.TurboStates.Tests;

public class StateControllerTests
{
    [Fact]
    public void SetState_CallsEnterOnNewState()
    {
        var controller = new StateController();
        var state = Substitute.For<IState>();

        controller.SetState(state);

        state.Received(1).Enter();
    }

    [Fact]
    public void SetState_CallsExitOnPreviousState()
    {
        var controller = new StateController();
        var stateA = Substitute.For<IState>();
        var stateB = Substitute.For<IState>();

        controller.SetState(stateA);
        controller.SetState(stateB);

        stateA.Received(1).Exit();
        stateB.Received(1).Enter();
    }

    [Fact]
    public void EmptyState_ExitsCurrentState()
    {
        var controller = new StateController();
        var state = Substitute.For<IState>();

        controller.SetState(state);
        controller.EmptyState();

        state.Received(1).Exit();
    }

    [Fact]
    public void Process_ForwardsDeltaToCurrentState()
    {
        var controller = new StateController();
        var state = Substitute.For<IState>();

        controller.SetState(state);

        controller.Process(0.5);

        state.Received(1).Process(0.5);
    }

    [Fact]
    public void PhysicsProcess_ForwardsDeltaToCurrentState()
    {
        var controller = new StateController();
        var state = Substitute.For<IState>();

        controller.SetState(state);

        controller.PhysicsProcess(0.25);

        state.Received(1).PhysicsProcess(0.25);
    }

    [Fact]
    public void Process_DoesNothing_WhenStateIsNull()
    {
        var controller = new StateController();

        controller.Process(0.5);
        controller.PhysicsProcess(0.5);
    }
}