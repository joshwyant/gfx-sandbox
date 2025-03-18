import React, { useRef, useState } from "react";
import { Canvas, useFrame } from "@react-three/fiber";
import { OrbitControls } from "@react-three/drei";
import { Mesh } from "three";

const Box = () => {
  const ref = useRef();
  useFrame(() => {
    //ref.current.rotation.x += 0.01;
    ref.current.rotation.y += 0.01;
  });
  const [color, setColor] = useState("hotpink");

  return (
    <mesh ref={ref}
     onClick={() => setColor(color === "hotpink" ? "blue" : "hotpink")}>
      <boxGeometry args={[1, 1, 1]} />
      <meshStandardMaterial color={color} />
    </mesh>
  );
};

const Plane = () => {
  return (
    <mesh rotation-x={-Math.PI / 2} position={[0, -0.5, 0]}>
      <planeGeometry args={[10, 10]} />
      <meshStandardMaterial color="gray" />
    </mesh>
  );
};

function App() {
  const handleClick = () => {
    alert("Button Clicked!");
  };

  return (
    <div>
      {/* 3D Scene */}
      <Canvas camera={{ position: [0, 5, 5], fov: 30 }} style={{ width: "100vw", height: "100vh", background: "black" }}>
        
        <ambientLight intensity={0.5} />
        {/* <directionalLight position={[2, 2, 2]} /> */}
        <pointLight position={[2, 2, 2]} />
        <Box />
        <Plane />
        <OrbitControls  />
      </Canvas>

      {/* Button */}
      <button onClick={handleClick} style={{ position: "absolute", top: "10px", left: "10px", zIndex: 1000 }}>Click Me</button>
    </div>
  );
}

export default App;
