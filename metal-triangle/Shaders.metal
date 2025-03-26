//
//  Shaders.metal
//  metal-triangle
//
//  Created by Josh W on 3/26/25.
//

#include <metal_stdlib>
using namespace metal;

vertex float4 vs_main(const device float2* positions [[buffer(0)]], uint id [[vertex_id]]) {
    return float4(positions[id], 0.0, 1.0);
}

fragment float4 fs_main() {
    return float4(1.0, 0.0, 0.0, 1.0); // Red
}
