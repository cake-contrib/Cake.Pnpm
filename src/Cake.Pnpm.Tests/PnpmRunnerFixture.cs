namespace Cake.Pnpm.Tests
{
    using Cake.Testing.Fixtures;

    public class PnpmRunnerFixture : ToolFixture<PnpmSettings>
    {
        public PnpmRunnerFixture()
            : base("Pnpm.exe")
        {
        }

        protected override void RunTool()
        {
            var tool = new PnpmRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Run(Settings);
        }
    }
}
