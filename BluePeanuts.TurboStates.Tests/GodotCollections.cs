using twodog.xunit;

[CollectionDefinition("Godot", DisableParallelization = true)]
public class GodotCollection : ICollectionFixture<GodotHeadlessFixture>
{
}
