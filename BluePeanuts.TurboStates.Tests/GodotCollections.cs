using twodog.xunit;

namespace BluePeanuts.TurboStates.Tests;

[CollectionDefinition("Godot", DisableParallelization = true)]
public class GodotCollection : ICollectionFixture<GodotHeadlessFixture>
{
}
