using System.Reflection;

namespace AmlBatchProcessor.Application;
public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}