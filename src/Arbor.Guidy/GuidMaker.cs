using System;
using Marten.Schema.Identity;

namespace Arbor.Guidy
{
    public static class GuidMaker
    {
        public static string FormatGuid(Guid guid)
        {
            return guid.ToString().ToUpperInvariant();
        }

        public static Guid GenerateNewGuid(bool standardGuid)
        {
            Guid resultGuid = standardGuid
                ? Guid.NewGuid()
                : CombGuidIdGeneration.NewGuid();

            return resultGuid;
        }
    }
}