using System.Numerics;
using System.Runtime.InteropServices;

namespace Hades.Studio.Rendering;

[StructLayout(LayoutKind.Sequential)]
public struct VertexPosition
{
    public Vector3 Position;
}