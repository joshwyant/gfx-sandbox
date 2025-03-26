//
//  ViewController.swift
//  metal-triangle
//
//  Created by Josh W on 3/26/25.
//

import Cocoa
import MetalKit

class ViewController: NSViewController, MTKViewDelegate {
    func mtkView(_ view: MTKView, drawableSizeWillChange size: CGSize) {}
    
    func draw(in view: MTKView) {
        guard let drawable = view.currentDrawable,
              let descriptor = view.currentRenderPassDescriptor else { return }
        
        let commandBuffer = commandQueue.makeCommandBuffer()!
        let encoder = commandBuffer.makeRenderCommandEncoder(descriptor: descriptor)!
        
        encoder.setRenderPipelineState(pipelineState)
        encoder.setVertexBuffer(vertexBuffer, offset: 0, index: 0)
        encoder.drawPrimitives(type: .triangle, vertexStart: 0, vertexCount: 3)
        encoder.endEncoding()
        
        commandBuffer.present(drawable)
        commandBuffer.commit()
    }
    
    var metalView: MTKView!
    var device: MTLDevice!
    var commandQueue: MTLCommandQueue!
    var pipelineState: MTLRenderPipelineState!
    var vertexBuffer: MTLBuffer!

    override func viewDidLoad() {
        super.viewDidLoad()

        device = MTLCreateSystemDefaultDevice()!
        metalView = MTKView(frame: self.view.bounds, device: device)
        metalView.clearColor = MTLClearColor(red: 0.0, green: 0, blue: 0, alpha: 1)
        metalView.delegate = self
        view.addSubview(metalView)
        
        commandQueue = device.makeCommandQueue()!
        
        let vertices: [Float] = [
            0.0, 0.5,
            -0.5, -0.5,
            0.5, -0.5
        ]
        vertexBuffer = device.makeBuffer(
            bytes: vertices, length: MemoryLayout<Float>.size * vertices.count, options: []
        )
        
        // Compile shaders
        let library = device.makeDefaultLibrary()
        let vertexFunc = library?.makeFunction(name: "vs_main")
        let fragmentFunc = library?.makeFunction(name: "fs_main")
        
        let pipelineDescriptor = MTLRenderPipelineDescriptor()
        pipelineDescriptor.vertexFunction = vertexFunc
        pipelineDescriptor.fragmentFunction = fragmentFunc
        pipelineDescriptor.colorAttachments[0].pixelFormat = metalView.colorPixelFormat
        
        pipelineState = try! device.makeRenderPipelineState(descriptor: pipelineDescriptor)
    }

}

