using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.CodeAnalysis;
using System.Reflection;
using Werewolf.Engine.Editor;

namespace Werewolf.Engine.Scripting
{
    public class ScriptCompiler
    {
        public object ClassInstance { get; private set; }
        public bool HasCompiled { get; private set; }

        public bool ShouldHold { get; private set; }

        public bool Compile(Sprite2D owner)
        {
            HasCompiled = false;
            ShouldHold = false;

            if (owner.AttachedScript == "" || owner.AttachedScript == null)
                return true;

            var compilationOptions = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary);

            // Add necessary references
            var references = AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly => !assembly.IsDynamic && !string.IsNullOrEmpty(assembly.Location))
                .Select(assembly => MetadataReference.CreateFromFile(assembly.Location))
                .ToList();

            // Add reference to Epicity.Engine assembly (replace "Epicity.Engine" with the actual assembly name)
            // references.Add(MetadataReference.CreateFromFile("path_to_Epicity.Engine.dll"));

            // Create compilation
            var syntaxTree = CSharpSyntaxTree.ParseText(owner.AttachedScript);
            var compilation = CSharpCompilation.Create("DynamicAssembly")
                .WithOptions(compilationOptions)
                .AddReferences(references)
                .AddSyntaxTrees(syntaxTree);

            // Compile the code
            using (var ms = new System.IO.MemoryStream())
            {
                EmitResult result = compilation.Emit(ms);

                // Check for compilation errors
                if (!result.Success)
                {
                    string error = "";
                    foreach (var diagnostic in result.Diagnostics)
                    {
                        if (diagnostic.Severity == DiagnosticSeverity.Error)
                        {
                            error += diagnostic.GetMessage();
                        }
                    }

                    LunaErrorBox errBox = new LunaErrorBox(error, owner.AttachedScript, owner.AttachedScriptFilePath);
                    errBox.ShowDialog();

                    ShouldHold = true;
                    return false;
                }
                else
                {
                    // Load the compiled assembly
                    ms.Seek(0, System.IO.SeekOrigin.Begin);
                    var assembly = Assembly.Load(ms.ToArray());

                    // Create an instance of the Test class
                    var classType = assembly.GetType(owner.AttachedScriptName);
                    ClassInstance = Activator.CreateInstance(classType);

                    ShouldHold = false;
                    HasCompiled = true;
                    return true;
                }
            }
        }

        public void InvokeMethod(string methodName, object?[]? parameters = null)
        {
            if (!HasCompiled)
                return;

            var method = ClassInstance.GetType().GetMethod(methodName);
            if (method != null)
            {
                method.Invoke(ClassInstance, parameters);
            }
        }
    }
}
