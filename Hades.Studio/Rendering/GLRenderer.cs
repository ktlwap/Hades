using System;
using System.Drawing;
using Avalonia;
using Silk.NET.OpenGL;

namespace Hades.Studio.Rendering;

public class GLRenderer : IDisposable
{
    private readonly GL _gl;

    private VertexArrayObject<VertexPosition, uint> _vao;
    
    public GLRenderer(Func<string, IntPtr> getProcAddr)
    {
        _gl = GL.GetApi(getProcAddr);

        _vao = new VertexArrayObject<VertexPosition, uint>(_gl, null, null);
    }

    public void Render()
    {
        _gl.ClearColor(Color.DarkOrange);
        _gl.Clear(ClearBufferMask.ColorBufferBit);
    }

    public void Viewport(Rect bounds)
    {
        _gl.Viewport((int) bounds.X, (int) bounds.Y, (uint) bounds.X, (uint) bounds.Y);
    }

    public void Dispose()
    {
        // nothing to do
    }
}
