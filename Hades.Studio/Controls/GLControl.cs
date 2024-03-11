using System.Numerics;
using Avalonia.Controls;
using Avalonia.OpenGL;
using Avalonia.OpenGL.Controls;
using Hades.Studio.Rendering;

namespace Hades.Studio.Controls;

public class GLControl : OpenGlControlBase
{
    private GLRenderer? _renderer;
    
    protected override void OnOpenGlInit(GlInterface gl)
    {
        _renderer = new GLRenderer(gl.GetProcAddress);
    }

    protected override void OnOpenGlRender(GlInterface gl, int fb)
    {
        _renderer!.Render();
    }

    protected override void OnOpenGlDeinit(GlInterface gl)
    {
        _renderer?.Dispose();
    }

    protected override void OnSizeChanged(SizeChangedEventArgs e)
    {
        _renderer?.Viewport(Bounds);
    }
}