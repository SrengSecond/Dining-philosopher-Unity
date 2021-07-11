using System.Runtime.CompilerServices;

// Allow internal visibility to the following assemblies
[assembly: InternalsVisibleTo("Unity.TextMeshPro")]
[assembly: InternalsVisibleTo("Unity.FontEngine")]

[assembly: InternalsVisibleTo("Unity.TextMeshPro.Tests")]
[assembly: InternalsVisibleTo("Unity.FontEngine.Tests")]

[assembly: InternalsVisibleTo("UnityEngine.UIElementsModule")]
[assembly: InternalsVisibleTo("Unity.UIElements.Text")]

#if UNITY_EDITOR
[assembly: InternalsVisibleTo("Unity.TextCore.Editor")]
[assembly: InternalsVisibleTo("Unity.TextCore.Editor.Tests")]
[assembly: InternalsVisibleTo("Unity.TextMeshPro.Editor")]
[assembly: InternalsVisibleTo("Unity.TextMeshPro.Editor.Tests")]
#endif
