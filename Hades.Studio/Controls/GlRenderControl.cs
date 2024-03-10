using System;
using System.Numerics;
using Avalonia.OpenGL;
using Avalonia.OpenGL.Controls;
using Avalonia.Threading;
using Silk.NET.OpenGL;
using TrippyGL;
using DebugSeverity = TrippyGL.DebugSeverity;
using DebugSource = TrippyGL.DebugSource;
using DebugType = TrippyGL.DebugType;
using PrimitiveType = TrippyGL.PrimitiveType;

namespace Hades.Studio.Controls;

public class GlRenderControl : OpenGlControlBase
{
    private GL? _gl;
    private GraphicsDevice? _graphicsDevice;
    
    private VertexBuffer<VertexColor> _vertexBuffer;
    private SimpleShaderProgram _shaderProgram;

    protected override void OnOpenGlInit(GlInterface gl)
    {
        base.OnOpenGlInit(gl);
        
        _gl = GL.GetApi(gl.GetProcAddress);
        _graphicsDevice = new GraphicsDevice(_gl)
        {
#if DEBUG
            DebugMessagingEnabled = false
#endif
        };
        _graphicsDevice.DebugMessageReceived += OnDebugMessage;

        Span<VertexColor> vertexData = stackalloc VertexColor[]
        {
            new VertexColor(new Vector3(-0.5f, -0.5f, 0), new Color4b(255, 0, 0, 255)),
            new VertexColor(new Vector3(0, 0.5f, 0), new Color4b(0, 255, 0, 255)),
            new VertexColor(new Vector3(0.5f, -0.5f, 0), new Color4b(0, 0, 255, 255)),
        };
        
        _vertexBuffer = new VertexBuffer<VertexColor>(_graphicsDevice, vertexData, BufferUsage.StaticDraw);
        _shaderProgram = SimpleShaderProgram.Create<VertexColor>(_graphicsDevice);

        _graphicsDevice.ClearColor = new Vector4(0, 0, 0, 1);
        _graphicsDevice.BlendingEnabled = false;
        _graphicsDevice.DepthTestingEnabled = false;
    }

    protected override void OnOpenGlRender(GlInterface gl, int fb)
    {
        _graphicsDevice!.Clear(ClearBuffers.Color);
        _graphicsDevice.SetViewport((int) Bounds.X, (int) Bounds.Y, (uint) Bounds.Width, (uint) Bounds.Height);
        
        _graphicsDevice.VertexArray = _vertexBuffer;
        _graphicsDevice.ShaderProgram = _shaderProgram;
        _graphicsDevice.DrawArrays(PrimitiveType.Triangles, 0, 3);
        
        Dispatcher.UIThread.Post(RequestNextFrameRendering, DispatcherPriority.Background);
    }
    
    protected override void OnOpenGlDeinit(GlInterface gl)
    {
        _graphicsDevice?.Dispose();
    }
    
    private static void OnDebugMessage(DebugSource debugSource, DebugType debugType, int messageId, DebugSeverity debugSeverity, string message)
    {
        if (messageId != 131185 && messageId != 131186)
            Console.WriteLine(string.Concat("Debug message: source=", debugSource.ToString(), " type=", debugType.ToString(), " id=", messageId.ToString(), " severity=", debugSeverity.ToString(), " message=\"", message, "\""));
    }
}
