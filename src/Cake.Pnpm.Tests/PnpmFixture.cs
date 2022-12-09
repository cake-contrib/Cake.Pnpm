using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Testing;
using Cake.Testing.Fixtures;

namespace Cake.Pnpm.Tests;

internal abstract class PnpmFixture<TSettings> : PnpmFixture<TSettings, ToolFixtureResult>
    where TSettings : ToolSettings, new()
{
    protected override ToolFixtureResult CreateResult(FilePath path, ProcessSettings process)
    {
        return new ToolFixtureResult(path, process);
    }
}

internal abstract class PnpmFixture<TSettings, TFixtureResult> : ToolFixture<TSettings, TFixtureResult>
    where TSettings : ToolSettings, new()
    where TFixtureResult : ToolFixtureResult
{
    protected PnpmFixture()
        : base("pnpm.cmd")
    {
        Log.Verbosity = Verbosity.Normal;
    }

    protected ICakeLog Log { get; } = new FakeLog();
}

