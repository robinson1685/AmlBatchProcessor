using System.Reflection;

namespace AmlBatchProcessor.Domain;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}