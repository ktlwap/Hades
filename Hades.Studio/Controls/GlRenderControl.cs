using Avalonia.OpenGL;
using Avalonia.OpenGL.Controls;
using Avalonia.Threading;

namespace Hades.Studio.Controls;

public class GlRenderControl : OpenGlControlBase
{
    protected override void OnOpenGlRender(GlInterface gl, int fb)
    {
        Dispatcher.UIThread.Post(RequestNextFrameRendering, DispatcherPriority.Background);
    }
}
