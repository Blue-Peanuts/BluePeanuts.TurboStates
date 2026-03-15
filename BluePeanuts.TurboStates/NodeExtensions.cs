using Godot;

namespace BluePeanuts.TurboStates;

public static class NodeExtensions
{
    extension(Node node)
    {
        /// <summary>
        /// Creates a <see cref="StateControllerNode"/> as a child of the current node.
        /// </summary>
        /// <param name="initialState">
        /// An optional nullable <see cref="IState"/> to set as the initial state.
        /// </param>
        /// <returns>
        /// The created <see cref="StateControllerNode"/> instance.
        /// </returns>
        /// <remarks>
        /// If the parent node is already ready (see <see cref="Node.IsNodeReady"/>), the state is set immediately.
        /// Otherwise, the state assignment is deferred until the node's <see cref="Node.Ready"/> event fires.
        /// </remarks>
        public StateControllerNode AddStateControllerNode(IState? initialState = null)
        {
            var stateControllerNode = new StateControllerNode();
            node.AddChild(stateControllerNode);

            if (node.IsNodeReady())
            {
                stateControllerNode.SetState(initialState);
            }
            else
            {
                node.Ready += () => { stateControllerNode.SetState(initialState); };
            }

            return stateControllerNode;
        }
    }
}