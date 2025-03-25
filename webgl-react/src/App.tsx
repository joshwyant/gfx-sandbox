import { useRef, useEffect, useState } from 'react'
import './App.css'

const WebGLCanvas = () => {
  const canvasRef = useRef<HTMLCanvasElement>(null)

  useEffect(() => {
    const canvas = canvasRef.current
    const gl = canvas?.getContext('webgl')
    if (!gl) {
      console.error('Failed to get WebGL context')
      return
    }

    // Define shaders
    const vertexSrc = `
      attribute vec2 position;
      void main() {
        gl_Position = vec4(position, 0.0, 1.0);
      }
    `;

    const fragmentSrc = `
      void main() {
        gl_FragColor = vec4(1.0, 0.0, 0.0, 1.0); //red
      }
    `;

    // Compile shaders
    function compileShader(type: number, source: string) {
      if (!gl) return null;
      const shader = gl.createShader(type)!;
      gl.shaderSource(shader, source);
      gl.compileShader(shader);
      if (!gl.getShaderParameter(shader, gl.COMPILE_STATUS)) {
        console.error(gl.getShaderInfoLog(shader));
        return null;
      }
      return shader;
    }

    const vertexShader = compileShader(gl.VERTEX_SHADER, vertexSrc)!;
    const fragmentShader = compileShader(gl.FRAGMENT_SHADER, fragmentSrc)!;

    // Link program
    const program = gl.createProgram();
    gl.attachShader(program, vertexShader);
    gl.attachShader(program, fragmentShader);
    gl.linkProgram(program);
    gl.useProgram(program);

    // New buffer
    const vertices = new Float32Array([
      0.0, 0.5, // Top
      -0.5, -0.5, // Bottom left
      0.5, -0.5, // Bottom right
    ]);

    const buffer = gl.createBuffer();
    gl.bindBuffer(gl.ARRAY_BUFFER, buffer);
    gl.bufferData(gl.ARRAY_BUFFER, vertices, gl.DYNAMIC_DRAW);

    const positionLoc = gl.getAttribLocation(program, "position");
    gl.enableVertexAttribArray(positionLoc);
    gl.vertexAttribPointer(positionLoc, 2, gl.FLOAT, false, 0, 0);

    // Render
    gl.viewport(0, 0, canvas!.width, canvas!.height);
    gl.clearColor(0, 0, 0, 1);

    function renderLoop() {
      if (!gl) return;
      vertices[1] += 0.01;
      gl.bindBuffer(gl.ARRAY_BUFFER, buffer);
      gl.bufferData(gl.ARRAY_BUFFER, vertices, gl.DYNAMIC_DRAW);
      gl.clear(gl.COLOR_BUFFER_BIT);
      gl.drawArrays(gl.TRIANGLES, 0, 3);
      requestAnimationFrame(renderLoop);
    }
    renderLoop();
  }, []);

  return <canvas ref={canvasRef} width={500} height={500} />
}

function App() {
  return (
    <>
      <div style={{ justifyContent: "center", height: "100vh", alignItems: "center" }}>
        <WebGLCanvas />
      </div>
    </>
  )
}

export default App
