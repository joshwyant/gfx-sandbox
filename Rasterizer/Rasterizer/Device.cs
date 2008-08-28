using System;
using Math3D;

namespace Rasterizer
{
    public class RasterizerException : Exception
    {
        public RasterizerException(string message) : base(message) { }
    }
    public class Viewport
    {
        internal Matrix vm;
        float w;
        float h;
        float x;
        float y;
        float minz;
        float maxz;
        public Viewport(float x, float y, float width, float height, float minz, float maxz)
        {
            w = width;
            h = height;
            this.x = x;
            this.y = y;
            this.minz = minz;
            this.maxz = maxz;
            buildmatrix();
        }
        public float X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
                buildmatrix();
            }
        }
        public float Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
                buildmatrix();
            }
        }
        public float Width
        {
            get
            {
                return w;
            }
            set
            {
                w = value;
                buildmatrix();
            }
        }
        public float Height
        {
            get
            {
                return h;
            }
            set
            {
                h = value;
                buildmatrix();
            }
        }
        public float MinZ
        {
            get
            {
                return minz;
            }
            set
            {
                minz = value;
                buildmatrix();
            }
        }
        public float MaxZ
        {
            get
            {
                return maxz;
            }
            set
            {
                maxz = value;
                buildmatrix();
            }
        }
        private void buildmatrix()
        {
            vm = new Matrix();
            vm.M11 = w * 0.5f;
            vm.M22 = -h * 0.5f;
            vm.M33 = maxz - minz;
            vm.M44 = 1.0f;
            vm.M41 = x + w * 0.5f;
            vm.M42 = y + h * 0.5f;
            vm.M43 = minz;
        }
    }
    public enum ShadingMode
    {
        Flat,
        Gouraud,
        Phong
    }
    public enum Fillmode
    {
        Point,
        Wireframe,
        Solid
    }
    public enum CullMode
    {
        None,
        Clockwise,
        CounterClockwise
    }
    public class RenderState
    {
        internal bool texenable = true;
        internal bool texlinear = false;
        internal bool culling = false;
        internal bool uvclamp = true;
        internal bool blendalpha = false;
        internal bool blendvertex = true;
        internal bool ztest;
        internal bool normalize_normals;
        public bool TextureEnable
        {
            get
            {
                return texenable;
            }
            set
            {
                texenable = value;
            }
        }
        public bool AlphaBlendEnable
        {
            get
            {
                return blendalpha;
            }
            set
            {
                blendalpha = value;
            }
        }
        public bool TextureFilterLinear
        {
            get
            {
                return texlinear;
            }
            set
            {
                texlinear = value;
            }
        }
        public bool CullFaces
        {
            get
            {
                return culling;
            }
            set
            {
                culling = value;
            }
        }
        public bool ClampTextureUV
        {
            get
            {
                return uvclamp;
            }
            set
            {
                uvclamp = value;
            }
        }
        public bool VertexBlendEnable
        {
            get
            {
                return blendvertex;
            }
            set
            {
                blendvertex = value;
            }
        }
        public bool ZBufferEnable
        {
            get
            {
                return ztest;
            }
            set
            {
                ztest = value;
            }
        }
        public bool NormalizeNormals
        {
            get
            {
                return normalize_normals;
            }
            set
            {
                normalize_normals = value;
            }
        }
    }
    public class Device
    {
        Matrix worldViewProjViewport;
        Matrix world;
        Matrix view;
        Matrix projection;
        RenderState rs;
        Viewport vp;
        System.Windows.Forms.Control ctrl;
    }
}
