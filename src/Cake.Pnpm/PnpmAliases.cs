namespace Cake.Pnpm
{
    using Cake.Core;
    using Cake.Core.Annotations;
    using Cake.Core.IO;

    [CakeAliasCategory("Pnpm")]
    public static class PnpmAliases
    {
        [CakeMethodAlias]
        public static void Pnpm(this ICakeContext context)
        {
            Pnpm(context, new PnpmSettings());
        }

        [CakeMethodAlias]
        public static void Pnpm(this ICakeContext context, PnpmSettings settings)
        {
            var runner = new PnpmRunner(
                context.FileSystem,
                context.Environment,
                context.ProcessRunner,
                context.Tools);
            runner.Run(settings);
        }
    }
}
