import { useEffect, useRef } from 'react'
import './App.css'

const WebGPUCanvas = () => {
  const canvasRef = useRef<HTMLCanvasElement>(null);

  useEffect(() => {
    const initWebGPU = async () => {
      if (!navigator.gpu) {
        console.log("No WebGPU.");
      }
      const canvas = canvasRef.current!;
      const adapter = await navigator.gpu.requestAdapter();

      if (!adapter) {
        console.log("No WebGPU.");
      }

      const device = await adapter!.requestDevice();

      if (!device) {
        console.log("No WebGPU.");
      }

      const context = canvas.getContext("webgpu") as GPUCanvasContext;
      const format = navigator.gpu.getPreferredCanvasFormat();

      context.configure({
        device,
        format,
        alphaMode: "opaque"
      });

      // Shaders (WGSL)
      const shaderModule = device.createShaderModule({
        code: `
          @vertex
          fn vs_main(@location(0) position: vec2f) -> @builtin(position) vec4f {
            return vec4f(position, 0.0, 1.0);
          }

          @fragment
          fn fs_main() -> @location(0) vec4f {
            return vec4f(1.0, 0.0, 0.0, 1.0); // red
          }
        `
      });

      // Pipeline
      const pipeline = device.createRenderPipeline({
        layout: "auto",
        vertex: {
          module: shaderModule,
          entryPoint: "vs_main",
          buffers: [
            {
              arrayStride: 8, // 2 * 4 bytes (vec2f)
              attributes: [{ shaderLocation: 0, offset: 0, format: "float32x2" }]
            }
          ]
        },
        fragment: {
          module: shaderModule,
          entryPoint: "fs_main",
          targets: [{ format }],
        },
        primitive: { topology: "triangle-list" },
      });

      // Vertex buffer
      const vertexData = new Float32Array([
        0.0, 0.5,  // Top
        -0.5, -0.5,  // Bottom left
        0.5, -0.5,  // Bottom right
      ]);

      const vertexBuffer = device.createBuffer({
        size: vertexData.byteLength,
        usage: GPUBufferUsage.VERTEX | GPUBufferUsage.COPY_DST,
        mappedAtCreation: true
      });

      new Float32Array(vertexBuffer.getMappedRange()).set(vertexData);
      vertexBuffer.unmap();

      // Render
      const encoder = device.createCommandEncoder();
      const pass = encoder.beginRenderPass({
        colorAttachments: [
          {
            view: context.getCurrentTexture().createView(),
            clearValue: { r: 0, g: 0, b: 0, a: 1 },
            loadOp: "clear",
            storeOp: "store"
          }
        ]
      });

      pass.setPipeline(pipeline);
      pass.setVertexBuffer(0, vertexBuffer);
      pass.draw(3, 1, 0, 0);
      pass.end();

      device.queue.submit([encoder.finish()]);
    }
    initWebGPU();
  });

  return <canvas ref={canvasRef} width={500} height={500} />;
};

function App() {

  return (
    <>
      <div style={{ justifyContent: "center", alignItems: "center", height: "100vh" }}>
        <WebGPUCanvas />
      </div>
    </>
  )
}

export default App
